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
        if (!ativo)
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
        decimal quantidadeTotalProduto = decimal.Round(quantidadeInformada + quantidadeJaNaVenda, 3);

        if (quantidadeTotalProduto > estoqueAtual)
        {
            mensagemErro = $"Estoque insuficiente para o produto '{nomeProduto}'. Disponível: {estoqueAtual:0.###} {un}.";
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

