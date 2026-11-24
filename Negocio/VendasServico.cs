using System.Data;
using SistemaERP.Dados;
using SistemaERP.Modelo;

namespace SistemaERP.Negocio;

public class VendasServico
{
    private readonly VendasRepositorio _vendasRepositorio;
    private readonly ProdutosRepositorio _produtosRepositorio;
    private readonly ClientesRepositorio _clientesRepositorio;
    private readonly UsuariosRepositorio _usuariosRepositorio;

    public VendasServico()
    {
        _vendasRepositorio = new VendasRepositorio();
        _produtosRepositorio = new ProdutosRepositorio();
        _clientesRepositorio = new ClientesRepositorio();
        _usuariosRepositorio = new UsuariosRepositorio();
    }

    /// <summary>
    /// Calcula o subtotal de um item arredondado para 2 casas decimais
    /// </summary>
    public static decimal CalcularSubtotalItem(decimal quantidade, decimal valorUnitario)
    {
        if (quantidade <= 0 || valorUnitario <= 0)
            return 0m;

        return decimal.Round(quantidade * valorUnitario, 2, MidpointRounding.AwayFromZero);
    }

    /// <summary>
    /// Valida um item individual antes de adicioná-lo à venda (verificando produto ativo, unidade de medida, preço e estoque disponível)
    /// </summary>
    public bool ValidarItemVenda(int idProduto, decimal quantidadeInformada, decimal valorUnitario, decimal quantidadeJaNaVenda, out string mensagemErro)
    {
        return ValidarItemVenda(idProduto, quantidadeInformada, valorUnitario, quantidadeJaNaVenda, estoqueJaReservadoNaVenda: 0m, permitirProdutoInativoSeMantido: false, out mensagemErro);
    }

    /// <summary>
    /// Valida um item individual considerando o estoque já reservado pela própria venda em edição
    /// </summary>
    public bool ValidarItemVenda(
        int idProduto,
        decimal quantidadeInformada,
        decimal valorUnitario,
        decimal quantidadeJaNaVenda,
        decimal estoqueJaReservadoNaVenda,
        bool permitirProdutoInativoSeMantido,
        out string mensagemErro)
    {
        if (idProduto <= 0)
        {
            mensagemErro = "Selecione um produto válido.";
            return false;
        }

        DataRow? produto = _produtosRepositorio.ConsultaProdutoPorId(idProduto);
        if (produto == null)
        {
            mensagemErro = "Produto não encontrado.";
            return false;
        }

        bool ativo = Convert.ToBoolean(produto["Ativo"]);
        string nomeProduto = produto["Nome"]?.ToString() ?? $"ID {idProduto}";
        decimal quantidadeTotalProduto = decimal.Round(quantidadeInformada + quantidadeJaNaVenda, 3);

        if (!ativo && (!permitirProdutoInativoSeMantido || quantidadeTotalProduto > estoqueJaReservadoNaVenda))
        {
            mensagemErro = $"O produto '{nomeProduto}' está inativo.";
            return false;
        }

        string un = produto["Un"]?.ToString() ?? string.Empty;
        if (!ProdutosServico.ValidarQuantidadePorUnidade(quantidadeInformada, un, permitirZero: false, out mensagemErro))
        {
            return false;
        }

        if (valorUnitario <= 0)
        {
            mensagemErro = "O preço unitário deve ser maior que zero.";
            return false;
        }

        decimal estoqueAtual = Convert.ToDecimal(produto["Estoque"]);
        decimal estoqueDisponivelEfetivo = decimal.Round(estoqueAtual + estoqueJaReservadoNaVenda, 3);

        if (quantidadeTotalProduto > estoqueDisponivelEfetivo)
        {
            mensagemErro = $"Estoque insuficiente para o produto '{nomeProduto}'. Disponível: {estoqueDisponivelEfetivo:0.###} {un}.";
            return false;
        }

        mensagemErro = string.Empty;
        return true;
    }

    /// <summary>
    /// Valida e registra uma nova venda com situação padrão "Concluída" e baixa transacional de estoque
    /// </summary>
    public bool CadastraVenda(Venda venda, out string mensagemErro)
    {
        if (venda == null)
        {
            mensagemErro = "Dados da venda não informados.";
            return false;
        }

        if (venda.IdCliente <= 0)
        {
            mensagemErro = "Selecione um cliente válido para a venda.";
            return false;
        }

        var dadosCliente = _clientesRepositorio.BuscaClienteId(venda.IdCliente);
        if (dadosCliente == null || dadosCliente.Count == 0)
        {
            mensagemErro = "O cliente informado não foi encontrado.";
            return false;
        }

        if (dadosCliente.Count > 14 && string.Equals(dadosCliente[14], "False", StringComparison.OrdinalIgnoreCase))
        {
            mensagemErro = "O cliente selecionado está inativo.";
            return false;
        }

        if (venda.IdUsuario <= 0)
        {
            mensagemErro = "Selecione o vendedor responsável pela venda.";
            return false;
        }

        var dadosUsuario = _usuariosRepositorio.BuscaUsuarioId(venda.IdUsuario);
        if (dadosUsuario == null || dadosUsuario.Count == 0)
        {
            mensagemErro = "O vendedor selecionado não foi encontrado.";
            return false;
        }

        if (venda.Itens == null || venda.Itens.Count == 0)
        {
            mensagemErro = "Adicione pelo menos um produto à venda.";
            return false;
        }

        // Valida cada item e o total acumulado por produto contra o estoque e a unidade de medida
        var quantidadeAcumuladaPorProduto = new Dictionary<int, decimal>();
        decimal valorTotalCalculado = 0m;

        foreach (var item in venda.Itens)
        {
            quantidadeAcumuladaPorProduto.TryGetValue(item.IdProduto, out decimal qtdAnterior);

            if (!ValidarItemVenda(item.IdProduto, item.Quantidade, item.ValorUnitario, qtdAnterior, out mensagemErro))
            {
                return false;
            }

            item.Quantidade = decimal.Round(item.Quantidade, 3);
            item.ValorUnitario = decimal.Round(item.ValorUnitario, 2);
            item.ValorTotalItem = CalcularSubtotalItem(item.Quantidade, item.ValorUnitario);

            if (item.ValorTotalItem <= 0)
            {
                mensagemErro = "O subtotal de cada item da venda deve ser maior que zero.";
                return false;
            }

            quantidadeAcumuladaPorProduto[item.IdProduto] = qtdAnterior + item.Quantidade;
            valorTotalCalculado += item.ValorTotalItem;
        }

        venda.ValorTotal = decimal.Round(valorTotalCalculado, 2);
        if (venda.ValorTotal <= 0)
        {
            mensagemErro = "O valor total da venda deve ser maior que zero.";
            return false;
        }

        venda.Situacao = "Concluída";
        if (venda.DataVenda == default)
        {
            venda.DataVenda = DateTime.Now;
        }

        return _vendasRepositorio.InsereVenda(venda, out mensagemErro);
    }

    /// <summary>
    /// Valida e atualiza uma venda concluída (cabeçalho, observação e itens) com ajuste transacional de estoque pela diferença
    /// </summary>
    public bool AtualizaVenda(Venda venda, out string mensagemErro)
    {
        if (venda == null || venda.Id <= 0)
        {
            mensagemErro = "Venda inválida para alteração.";
            return false;
        }

        var vendaOriginal = _vendasRepositorio.ConsultaVendaPorId(venda.Id);
        if (vendaOriginal == null)
        {
            mensagemErro = "Venda não encontrada.";
            return false;
        }

        if (!string.Equals(vendaOriginal.Situacao, "Concluída", StringComparison.OrdinalIgnoreCase))
        {
            mensagemErro = $"Somente vendas com situação 'Concluída' podem ser alteradas. Situação atual: '{vendaOriginal.Situacao}'.";
            return false;
        }

        if (venda.IdCliente <= 0)
        {
            mensagemErro = "Selecione um cliente válido para a venda.";
            return false;
        }

        var dadosCliente = _clientesRepositorio.BuscaClienteId(venda.IdCliente);
        if (dadosCliente == null || dadosCliente.Count == 0)
        {
            mensagemErro = "O cliente informado não foi encontrado.";
            return false;
        }

        bool clienteInativo = dadosCliente.Count > 14 &&
            string.Equals(dadosCliente[14], "False", StringComparison.OrdinalIgnoreCase);

        if (clienteInativo && venda.IdCliente != vendaOriginal.IdCliente)
        {
            mensagemErro = "O cliente selecionado está inativo.";
            return false;
        }

        if (venda.IdUsuario <= 0)
        {
            mensagemErro = "Selecione o vendedor responsável pela venda.";
            return false;
        }

        var dadosUsuario = _usuariosRepositorio.BuscaUsuarioId(venda.IdUsuario);
        if (dadosUsuario == null || dadosUsuario.Count == 0)
        {
            mensagemErro = "O vendedor selecionado não foi encontrado.";
            return false;
        }

        if (venda.Itens == null || venda.Itens.Count == 0)
        {
            mensagemErro = "A venda deve conter pelo menos um produto.";
            return false;
        }

        var qtdOriginalPorProduto = vendaOriginal.Itens
            .GroupBy(i => i.IdProduto)
            .ToDictionary(g => g.Key, g => decimal.Round(g.Sum(x => x.Quantidade), 3));

        var quantidadeAcumuladaPorProduto = new Dictionary<int, decimal>();
        decimal valorTotalCalculado = 0m;

        foreach (var item in venda.Itens)
        {
            quantidadeAcumuladaPorProduto.TryGetValue(item.IdProduto, out decimal qtdAnteriorNaLista);
            qtdOriginalPorProduto.TryGetValue(item.IdProduto, out decimal qtdReservadaOriginal);

            if (!ValidarItemVenda(
                item.IdProduto,
                item.Quantidade,
                item.ValorUnitario,
                qtdAnteriorNaLista,
                qtdReservadaOriginal,
                permitirProdutoInativoSeMantido: qtdReservadaOriginal > 0,
                out mensagemErro))
            {
                return false;
            }

            item.Quantidade = decimal.Round(item.Quantidade, 3);
            item.ValorUnitario = decimal.Round(item.ValorUnitario, 2);
            item.ValorTotalItem = CalcularSubtotalItem(item.Quantidade, item.ValorUnitario);

            if (item.ValorTotalItem <= 0)
            {
                mensagemErro = "O subtotal de cada item da venda deve ser maior que zero.";
                return false;
            }

            quantidadeAcumuladaPorProduto[item.IdProduto] = decimal.Round(qtdAnteriorNaLista + item.Quantidade, 3);
            valorTotalCalculado += item.ValorTotalItem;
        }

        venda.ValorTotal = decimal.Round(valorTotalCalculado, 2);
        if (venda.ValorTotal <= 0)
        {
            mensagemErro = "O valor total da venda deve ser maior que zero.";
            return false;
        }

        if (!string.IsNullOrWhiteSpace(venda.Observacao) && venda.Observacao.Length > 255)
        {
            venda.Observacao = venda.Observacao[..255];
        }

        return _vendasRepositorio.AlteraVenda(venda, out mensagemErro);
    }

    /// <summary>
    /// Cancela uma venda concluída e estorna o estoque de todos os seus itens dentro de uma transação SQL
    /// </summary>
    public bool CancelaVenda(int idVenda, out string mensagemErro)
    {
        if (idVenda <= 0)
        {
            mensagemErro = "ID da venda inválido.";
            return false;
        }

        return _vendasRepositorio.CancelarVenda(idVenda, out mensagemErro);
    }

    /// <summary>
    /// Retorna todas as vendas dentro do período informado utilizando data final exclusiva (dataFim.Date.AddDays(1))
    /// </summary>
    public DataTable RetornaTodasVendas(DateTime? dataInicio = null, DateTime? dataFim = null)
    {
        DateTime? inicio = dataInicio?.Date;
        DateTime? fimExclusivo = dataFim?.Date.AddDays(1);

        return _vendasRepositorio.ConsultaTodasVendas(inicio, fimExclusivo);
    }

    /// <summary>
    /// Busca uma venda completa (cabeçalho e itens) pelo ID
    /// </summary>
    public Venda? BuscaVendaPorId(int idVenda)
    {
        if (idVenda <= 0)
            throw new ArgumentException("ID da venda inválido.");

        return _vendasRepositorio.ConsultaVendaPorId(idVenda);
    }
}

