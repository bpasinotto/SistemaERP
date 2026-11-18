using System.Data;
using System.Globalization;
using SistemaERP.Modelo;
using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao;

public partial class FormCadVendas : FormBase
{
    private static readonly CultureInfo CulturaPtBr = new("pt-BR");

    private readonly VendasServico _vendasServico = new();
    private readonly ProdutosServico _produtosServico = new();
    private readonly ClientesServico _clientesServico = new();
    private readonly List<VendaItem> _itensVenda = new();

    private readonly int _vendaIdVisualizacao;
    private readonly bool _somenteVisualizacao;

    private int _idClienteSelecionado;
    private int _idProdutoSelecionado;
    private string _nomeProdutoSelecionado = string.Empty;
    private string _unidadeProdutoSelecionado = string.Empty;
    private bool _atualizandoCamposProduto;
    private bool _salvandoVenda;

    public FormCadVendas()
    {
        InitializeComponent();
        ConfigurarGridItens();
        CarregarVendedores();
        LimparCamposLancamentoProduto();
        AtualizarTotalGeral();
        this.Load += FormCadVendas_Load;
    }

    public FormCadVendas(int idVenda) : this()
    {
        _vendaIdVisualizacao = idVenda;
        _somenteVisualizacao = idVenda > 0;
    }

    private void FormCadVendas_Load(object? sender, EventArgs e)
    {
        AplicarTemaGridItens();

        if (_somenteVisualizacao && _vendaIdVisualizacao > 0)
        {
            CarregarVendaParaVisualizacao(_vendaIdVisualizacao);
        }
    }

    private void ConfigurarGridItens()
    {
        dgProdutosVenda.AutoGenerateColumns = false;
        dgProdutosVenda.AllowUserToAddRows = false;
        dgProdutosVenda.AllowUserToDeleteRows = false;
        dgProdutosVenda.AllowUserToOrderColumns = false;
        dgProdutosVenda.ReadOnly = true;
        dgProdutosVenda.MultiSelect = false;
        dgProdutosVenda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgProdutosVenda.RowHeadersVisible = false;
        dgProdutosVenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgProdutosVenda.Columns.Clear();

        dgProdutosVenda.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colIdProduto",
            HeaderText = "Cód.",
            DataPropertyName = "IdProduto",
            FillWeight = 12
        });

        dgProdutosVenda.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colNomeProduto",
            HeaderText = "Descrição",
            DataPropertyName = "NomeProduto",
            FillWeight = 34
        });

        dgProdutosVenda.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colUnidade",
            HeaderText = "UN",
            DataPropertyName = "Un",
            FillWeight = 10
        });

        dgProdutosVenda.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colQuantidade",
            HeaderText = "Qtd.",
            DataPropertyName = "Quantidade",
            FillWeight = 14,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "0.###",
                FormatProvider = CulturaPtBr,
                Alignment = DataGridViewContentAlignment.MiddleRight
            }
        });

        dgProdutosVenda.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colValorUnitario",
            HeaderText = "Preço Unit.",
            DataPropertyName = "ValorUnitario",
            FillWeight = 15,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C2",
                FormatProvider = CulturaPtBr,
                Alignment = DataGridViewContentAlignment.MiddleRight
            }
        });

        dgProdutosVenda.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colValorTotalItem",
            HeaderText = "Subtotal",
            DataPropertyName = "ValorTotalItem",
            FillWeight = 15,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "C2",
                FormatProvider = CulturaPtBr,
                Alignment = DataGridViewContentAlignment.MiddleRight
            }
        });

        dgProdutosVenda.KeyDown += DgProdutosVenda_KeyDown;
    }

    private void AplicarTemaGridItens()
    {
        string temaSalvo = Properties.Settings.Default.Tema;
        bool temaEscuro = string.Equals(temaSalvo, "Escuro", StringComparison.OrdinalIgnoreCase);

        dgProdutosVenda.EnableHeadersVisualStyles = false;
        dgProdutosVenda.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        dgProdutosVenda.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
        dgProdutosVenda.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.LightGray;
        dgProdutosVenda.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

        if (temaEscuro)
        {
            dgProdutosVenda.BackgroundColor = Color.FromArgb(44, 44, 44);
            dgProdutosVenda.DefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            dgProdutosVenda.DefaultCellStyle.ForeColor = Color.White;
            dgProdutosVenda.DefaultCellStyle.SelectionBackColor = Color.FromArgb(2, 89, 89);
            dgProdutosVenda.DefaultCellStyle.SelectionForeColor = Color.White;
            dgProdutosVenda.GridColor = Color.FromArgb(100, 100, 100);
        }
        else
        {
            dgProdutosVenda.BackgroundColor = Color.White;
            dgProdutosVenda.DefaultCellStyle.BackColor = Color.White;
            dgProdutosVenda.DefaultCellStyle.ForeColor = Color.FromArgb(44, 44, 44);
            dgProdutosVenda.DefaultCellStyle.SelectionBackColor = Color.FromArgb(2, 89, 89);
            dgProdutosVenda.DefaultCellStyle.SelectionForeColor = Color.White;
            dgProdutosVenda.GridColor = Color.LightGray;
        }
    }

    private void CarregarVendedores()
    {
        try
        {
            var usuariosServico = new UsuariosServico();
            var usuarios = usuariosServico.RetornaTodosUsuarios(false);

            cbVendedor.DataSource = usuarios;
            cbVendedor.DisplayMember = "Nome";
            cbVendedor.ValueMember = "Id";
            cbVendedor.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            new FormMensagem("Erro", $"Erro ao carregar vendedores: {ex.Message}").ShowDialog();
        }
    }

    private void CarregarVendaParaVisualizacao(int idVenda)
    {
        try
        {
            var venda = _vendasServico.BuscaVendaPorId(idVenda);
            if (venda == null)
            {
                new FormMensagem("Erro", "Venda não encontrada.").ShowDialog();
                Close();
                return;
            }

            this.Text = $"Visualização da Venda #{venda.Id} - {venda.DataVenda:dd/MM/yyyy HH:mm}";

            _idClienteSelecionado = venda.IdCliente;
            txtCodCliente.Texts = venda.IdCliente.ToString();
            lblNomeCliente.Text = venda.NomeCliente;

            if (cbVendedor.DataSource is DataTable dtUsuarios &&
                !dtUsuarios.AsEnumerable().Any(r => Convert.ToInt32(r["Id"]) == venda.IdUsuario))
            {
                DataRow novaLinha = dtUsuarios.NewRow();
                novaLinha["Id"] = venda.IdUsuario;
                novaLinha["Nome"] = venda.NomeUsuario;
                if (dtUsuarios.Columns.Contains("Email"))
                {
                    novaLinha["Email"] = string.Empty;
                }
                dtUsuarios.Rows.Add(novaLinha);
            }

            cbVendedor.SelectedValue = venda.IdUsuario;

            _itensVenda.Clear();
            _itensVenda.AddRange(venda.Itens);
            AtualizarGridItens();
            AtualizarTotalGeral();

            // Modo somente visualização: desabilita edição e gravação
            txtCodCliente.Enabled = false;
            btnBuscaCliente.Enabled = false;
            cbVendedor.Enabled = false;
            txtCodProduto.Enabled = false;
            btnBuscaProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtPrecoUnit.Enabled = false;
            btnAdicionarProduto.Visible = false;
            btnRemoverProduto.Visible = false;
            btnSalvar.Visible = false;
        }
        catch (Exception ex)
        {
            new FormMensagem("Erro", $"Erro ao carregar os detalhes da venda: {ex.Message}").ShowDialog();
            Close();
        }
    }

    #region -> Seleção de Cliente

    private void txtCodCliente__TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCodCliente.Texts))
        {
            _idClienteSelecionado = 0;
            lblNomeCliente.Text = "Nome do Cliente";
        }
    }

    private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Aceita apenas dígitos, backspace e delete
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
        {
            e.Handled = true;
        }
    }

    private void txtCodCliente_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtCodCliente_Leave(txtCodCliente, EventArgs.Empty);
            if (_idClienteSelecionado > 0)
            {
                cbVendedor.Focus();
            }
            e.SuppressKeyPress = true;
        }
    }

    private void txtCodCliente_Leave(object sender, EventArgs e)
    {
        if (_somenteVisualizacao)
            return;

        if (!string.IsNullOrWhiteSpace(txtCodCliente.Texts) && int.TryParse(txtCodCliente.Texts.Trim(), out int clienteId) && clienteId > 0)
        {
            try
            {
                List<string> dadosCliente = _clientesServico.BuscaClienteId(clienteId);

                if (dadosCliente != null && dadosCliente.Count >= 3)
                {
                    bool clienteInativo = dadosCliente.Count > 14 &&
                        string.Equals(dadosCliente[14], "False", StringComparison.OrdinalIgnoreCase);

                    if (clienteInativo)
                    {
                        _idClienteSelecionado = 0;
                        lblNomeCliente.Text = "Cliente inativo";
                        new FormMensagem("Atenção", "O cliente informado está inativo e não pode ser utilizado em novas vendas.").ShowDialog();
                        txtCodCliente.Texts = string.Empty;
                        lblNomeCliente.Text = "Nome do Cliente";
                        return;
                    }

                    _idClienteSelecionado = clienteId;
                    lblNomeCliente.Text = dadosCliente[2];
                }
                else
                {
                    _idClienteSelecionado = 0;
                    lblNomeCliente.Text = "Cliente não encontrado";
                }
            }
            catch
            {
                _idClienteSelecionado = 0;
                lblNomeCliente.Text = "Erro ao consultar cliente";
            }
        }
        else
        {
            _idClienteSelecionado = 0;
            lblNomeCliente.Text = "Nome do Cliente";
        }
    }

    private void btnBuscaCliente_Click(object sender, EventArgs e)
    {
        if (_somenteVisualizacao)
            return;

        FormClientes formClientesBusca = new FormClientes(txtCodCliente);
        formClientesBusca.FormBorderStyle = FormBorderStyle.Sizable;
        formClientesBusca.ControlBox = true;

        string temaSalvo = Properties.Settings.Default.Tema;
        if (!string.IsNullOrEmpty(temaSalvo))
        {
            formClientesBusca.AplicaTema(temaSalvo);
            formClientesBusca.MudaCorGrid(temaSalvo);
        }

        formClientesBusca.ShowDialog();

        txtCodCliente_Leave(txtCodCliente, EventArgs.Empty);
    }

    #endregion

    #region -> Seleção de Produto

    private void txtCodProduto_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void txtCodProduto_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            CarregarProdutoPorCodigo(exibirMensagemErro: true);
            if (_idProdutoSelecionado > 0)
            {
                txtQuantidade.Focus();
            }
            e.SuppressKeyPress = true;
        }
    }

    private void txtCodProduto_Leave(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao || _atualizandoCamposProduto)
            return;

        if (string.IsNullOrWhiteSpace(txtCodProduto.Texts))
        {
            LimparDadosProdutoSelecionado();
            return;
        }

        CarregarProdutoPorCodigo(exibirMensagemErro: true);
    }

    private void btnBuscaProduto_Click(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao)
            return;

        FormProdutos formProdutosBusca = new FormProdutos(txtCodProduto);
        formProdutosBusca.FormBorderStyle = FormBorderStyle.Sizable;
        formProdutosBusca.ControlBox = true;

        string temaSalvo = Properties.Settings.Default.Tema;
        if (!string.IsNullOrEmpty(temaSalvo))
        {
            formProdutosBusca.AplicaTema(temaSalvo);
            formProdutosBusca.MudaCorGrid(temaSalvo);
        }

        formProdutosBusca.ShowDialog();

        if (!string.IsNullOrWhiteSpace(txtCodProduto.Texts))
        {
            CarregarProdutoPorCodigo(exibirMensagemErro: true);
            if (_idProdutoSelecionado > 0)
            {
                txtQuantidade.Focus();
            }
        }
    }

    private bool CarregarProdutoPorCodigo(bool exibirMensagemErro)
    {
        if (string.IsNullOrWhiteSpace(txtCodProduto.Texts) ||
            !int.TryParse(txtCodProduto.Texts.Trim(), out int produtoId) ||
            produtoId <= 0)
        {
            LimparDadosProdutoSelecionado();
            if (exibirMensagemErro && !string.IsNullOrWhiteSpace(txtCodProduto.Texts))
            {
                new FormMensagem("Atenção", "Informe um código de produto válido.").ShowDialog();
            }
            return false;
        }

        try
        {
            DataRow? produto = _produtosServico.BuscaProdutoPorId(produtoId);
            if (produto == null)
            {
                LimparDadosProdutoSelecionado();
                lblNomeProduto.Text = "Produto não encontrado";
                if (exibirMensagemErro)
                {
                    new FormMensagem("Atenção", "Produto não encontrado.").ShowDialog();
                }
                return false;
            }

            bool ativo = Convert.ToBoolean(produto["Ativo"]);
            if (!ativo)
            {
                LimparDadosProdutoSelecionado();
                lblNomeProduto.Text = "Produto inativo";
                if (exibirMensagemErro)
                {
                    new FormMensagem("Atenção", "O produto informado está inativo e não pode ser utilizado em vendas.").ShowDialog();
                }
                return false;
            }

            bool mesmoProduto = _idProdutoSelecionado == produtoId;

            _idProdutoSelecionado = produtoId;
            _nomeProdutoSelecionado = produto["Nome"]?.ToString() ?? string.Empty;
            _unidadeProdutoSelecionado = (produto["Un"]?.ToString() ?? string.Empty).Trim().ToUpperInvariant();
            decimal precoCadastrado = Convert.ToDecimal(produto["Preco"]);

            _atualizandoCamposProduto = true;
            try
            {
                lblNomeProduto.Text = $"{_nomeProdutoSelecionado} ({_unidadeProdutoSelecionado})";

                if (!mesmoProduto || !TentarConverterMoedaPtBr(txtPrecoUnit.Texts, out decimal precoAtual) || precoAtual <= 0)
                {
                    txtPrecoUnit.Texts = FormatarMoedaCampo(precoCadastrado);
                }

                // Se a unidade do novo produto exigir inteiro e a quantidade atual for inválida/fracionada, redefine para "1"
                if (!TentarConverterQuantidadePtBr(txtQuantidade.Texts, out decimal qtdAtual) ||
                    !ProdutosServico.ValidarQuantidadePorUnidade(qtdAtual, _unidadeProdutoSelecionado, permitirZero: false, out _))
                {
                    txtQuantidade.Texts = "1";
                }
            }
            finally
            {
                _atualizandoCamposProduto = false;
            }

            AtualizarSubtotalItem();
            return true;
        }
        catch (Exception ex)
        {
            LimparDadosProdutoSelecionado();
            if (exibirMensagemErro)
            {
                new FormMensagem("Erro", $"Erro ao consultar produto: {ex.Message}").ShowDialog();
            }
            return false;
        }
    }

    private void LimparDadosProdutoSelecionado()
    {
        _atualizandoCamposProduto = true;
        try
        {
            _idProdutoSelecionado = 0;
            _nomeProdutoSelecionado = string.Empty;
            _unidadeProdutoSelecionado = string.Empty;
            lblNomeProduto.Text = "Nome do Produto";
            txtPrecoUnit.Texts = "R$: 0,00";
            rjTextBox1.Texts = "R$: 0,00";
        }
        finally
        {
            _atualizandoCamposProduto = false;
        }
    }

    private void LimparCamposLancamentoProduto()
    {
        _atualizandoCamposProduto = true;
        try
        {
            _idProdutoSelecionado = 0;
            _nomeProdutoSelecionado = string.Empty;
            _unidadeProdutoSelecionado = string.Empty;
            txtCodProduto.Texts = string.Empty;
            lblNomeProduto.Text = "Nome do Produto";
            txtQuantidade.Texts = "1";
            txtPrecoUnit.Texts = "R$: 0,00";
            rjTextBox1.Texts = "R$: 0,00";
        }
        finally
        {
            _atualizandoCamposProduto = false;
        }
    }

    #endregion

    #region -> Quantidade, Preço Unitário e Cálculo de Subtotal (Cultura pt-BR)

    private static string FormatarMoedaCampo(decimal valor)
    {
        return $"R$: {valor.ToString("N2", CulturaPtBr)}";
    }

    private static bool TentarConverterMoedaPtBr(string? texto, out decimal valor)
    {
        valor = 0m;
        if (string.IsNullOrWhiteSpace(texto))
            return false;

        string limpo = texto
            .Replace("R$:", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Replace("R$", string.Empty, StringComparison.OrdinalIgnoreCase)
            .Trim();

        if (string.IsNullOrWhiteSpace(limpo) || limpo.Contains('-'))
            return false;

        return decimal.TryParse(
            limpo,
            NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
            CulturaPtBr,
            out valor);
    }

    private static bool TentarConverterQuantidadePtBr(string? texto, out decimal quantidade)
    {
        quantidade = 0m;
        if (string.IsNullOrWhiteSpace(texto))
            return false;

        string limpo = texto.Trim();
        if (limpo.Contains('-') || limpo.Contains('.'))
            return false;

        return decimal.TryParse(
            limpo,
            NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite,
            CulturaPtBr,
            out quantidade);
    }

    private void txtQuantidade_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (char.IsControl(e.KeyChar))
            return;

        bool exigeInteiro = string.IsNullOrWhiteSpace(_unidadeProdutoSelecionado) ||
                            ProdutosServico.UnidadeExigeInteiro(_unidadeProdutoSelecionado);

        if (exigeInteiro)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        else
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == ',' && txtQuantidade.Texts.Contains(','))
            {
                e.Handled = true;
                return;
            }

            int indiceVirgula = txtQuantidade.Texts.IndexOf(',');
            if (char.IsDigit(e.KeyChar) && indiceVirgula >= 0 && txtQuantidade.SelectionStart > indiceVirgula)
            {
                string casasDecimais = txtQuantidade.Texts[(indiceVirgula + 1)..];
                if (casasDecimais.Length >= 3)
                {
                    e.Handled = true;
                }
            }
        }
    }

    private void txtQuantidade_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtPrecoUnit.Focus();
            e.SuppressKeyPress = true;
        }
    }

    private void txtQuantidade__TextChanged(object? sender, EventArgs e)
    {
        if (_atualizandoCamposProduto)
            return;

        AtualizarSubtotalItem();
    }

    private void txtQuantidade_Leave(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao || _atualizandoCamposProduto)
            return;

        if (TentarConverterQuantidadePtBr(txtQuantidade.Texts, out decimal qtd) && qtd > 0)
        {
            _atualizandoCamposProduto = true;
            try
            {
                txtQuantidade.Texts = qtd.ToString("0.###", CulturaPtBr);
            }
            finally
            {
                _atualizandoCamposProduto = false;
            }
        }

        AtualizarSubtotalItem();
    }

    private void txtPrecoUnit_Enter(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao || _atualizandoCamposProduto)
            return;

        if (TentarConverterMoedaPtBr(txtPrecoUnit.Texts, out decimal preco))
        {
            _atualizandoCamposProduto = true;
            try
            {
                txtPrecoUnit.Texts = preco > 0 ? preco.ToString("N2", CulturaPtBr) : string.Empty;
                txtPrecoUnit.SelectionStart = txtPrecoUnit.Texts.Length;
            }
            finally
            {
                _atualizandoCamposProduto = false;
            }
        }
    }

    private void txtPrecoUnit_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (char.IsControl(e.KeyChar))
            return;

        if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
        {
            e.Handled = true;
            return;
        }

        string textoAtual = txtPrecoUnit.Texts;
        if (e.KeyChar == ',' && textoAtual.Contains(','))
        {
            e.Handled = true;
            return;
        }

        int indiceVirgula = textoAtual.IndexOf(',');
        if (char.IsDigit(e.KeyChar) && indiceVirgula >= 0 && txtPrecoUnit.SelectionStart > indiceVirgula)
        {
            string casasDecimais = textoAtual[(indiceVirgula + 1)..];
            if (casasDecimais.Length >= 2)
            {
                e.Handled = true;
            }
        }
    }

    private void txtPrecoUnit_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            txtPrecoUnit_Leave(txtPrecoUnit, EventArgs.Empty);
            btnAdicionarProduto_Click(btnAdicionarProduto, EventArgs.Empty);
            e.SuppressKeyPress = true;
        }
    }

    private void txtPrecoUnit__TextChanged(object? sender, EventArgs e)
    {
        if (_atualizandoCamposProduto)
            return;

        AtualizarSubtotalItem();
    }

    private void txtPrecoUnit_Leave(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao || _atualizandoCamposProduto)
            return;

        _atualizandoCamposProduto = true;
        try
        {
            if (TentarConverterMoedaPtBr(txtPrecoUnit.Texts, out decimal preco) && preco >= 0)
            {
                txtPrecoUnit.Texts = FormatarMoedaCampo(decimal.Round(preco, 2));
            }
            else
            {
                txtPrecoUnit.Texts = "R$: 0,00";
            }
        }
        finally
        {
            _atualizandoCamposProduto = false;
        }

        AtualizarSubtotalItem();
    }

    private void AtualizarSubtotalItem()
    {
        if (TentarConverterQuantidadePtBr(txtQuantidade.Texts, out decimal quantidade) &&
            quantidade > 0 &&
            TentarConverterMoedaPtBr(txtPrecoUnit.Texts, out decimal valorUnitario) &&
            valorUnitario > 0)
        {
            if (!string.IsNullOrWhiteSpace(_unidadeProdutoSelecionado) &&
                !ProdutosServico.ValidarQuantidadePorUnidade(quantidade, _unidadeProdutoSelecionado, permitirZero: false, out _))
            {
                rjTextBox1.Texts = "R$: 0,00";
                return;
            }

            decimal subtotal = VendasServico.CalcularSubtotalItem(quantidade, valorUnitario);
            rjTextBox1.Texts = FormatarMoedaCampo(subtotal);
        }
        else
        {
            rjTextBox1.Texts = "R$: 0,00";
        }
    }

    #endregion

    #region -> Adição e Remoção de Itens na Venda

    private void btnAdicionarProduto_Click(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao)
            return;

        // Caso o usuário tenha digitado o código do produto e clicado direto em Adicionar
        if (!string.IsNullOrWhiteSpace(txtCodProduto.Texts) &&
            (!int.TryParse(txtCodProduto.Texts.Trim(), out int codDigitado) || codDigitado != _idProdutoSelecionado))
        {
            if (!CarregarProdutoPorCodigo(exibirMensagemErro: true))
                return;
        }

        if (_idProdutoSelecionado <= 0)
        {
            new FormMensagem("Atenção", "Selecione um produto válido antes de adicionar à venda.").ShowDialog();
            txtCodProduto.Focus();
            return;
        }

        if (!TentarConverterQuantidadePtBr(txtQuantidade.Texts, out decimal quantidade) || quantidade <= 0)
        {
            new FormMensagem("Atenção", "Informe uma quantidade válida e maior que zero.").ShowDialog();
            txtQuantidade.Focus();
            return;
        }

        if (!ProdutosServico.ValidarQuantidadePorUnidade(quantidade, _unidadeProdutoSelecionado, permitirZero: false, out string erroUnidade))
        {
            new FormMensagem("Atenção", erroUnidade).ShowDialog();
            txtQuantidade.Focus();
            return;
        }

        if (!TentarConverterMoedaPtBr(txtPrecoUnit.Texts, out decimal precoUnitario) || precoUnitario <= 0)
        {
            new FormMensagem("Atenção", "Informe um preço unitário válido e maior que zero.").ShowDialog();
            txtPrecoUnit.Focus();
            return;
        }

        precoUnitario = decimal.Round(precoUnitario, 2);
        quantidade = decimal.Round(quantidade, 3);

        decimal quantidadeJaAdicionada = _itensVenda
            .Where(i => i.IdProduto == _idProdutoSelecionado)
            .Sum(i => i.Quantidade);

        if (!_vendasServico.ValidarItemVenda(_idProdutoSelecionado, quantidade, precoUnitario, quantidadeJaAdicionada, out string mensagemErro))
        {
            new FormMensagem("Atenção", mensagemErro).ShowDialog();
            return;
        }

        decimal subtotalItem = VendasServico.CalcularSubtotalItem(quantidade, precoUnitario);
        if (subtotalItem <= 0)
        {
            new FormMensagem("Atenção", "O subtotal do item deve ser maior que zero.").ShowDialog();
            return;
        }

        // Se o produto já estiver na grade com o mesmo preço unitário, acumula a quantidade na mesma linha
        var itemExistente = _itensVenda.FirstOrDefault(i => i.IdProduto == _idProdutoSelecionado && i.ValorUnitario == precoUnitario);
        if (itemExistente != null)
        {
            itemExistente.Quantidade = decimal.Round(itemExistente.Quantidade + quantidade, 3);
            itemExistente.ValorTotalItem = VendasServico.CalcularSubtotalItem(itemExistente.Quantidade, itemExistente.ValorUnitario);
        }
        else
        {
            _itensVenda.Add(new VendaItem
            {
                IdProduto = _idProdutoSelecionado,
                NomeProduto = _nomeProdutoSelecionado,
                Un = _unidadeProdutoSelecionado,
                Quantidade = quantidade,
                ValorUnitario = precoUnitario,
                ValorTotalItem = subtotalItem
            });
        }

        AtualizarGridItens();
        AtualizarTotalGeral();
        LimparCamposLancamentoProduto();
        txtCodProduto.Focus();
    }

    private void btnRemoverProduto_Click(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao)
            return;

        if (dgProdutosVenda.CurrentRow == null || dgProdutosVenda.CurrentRow.Index < 0 || dgProdutosVenda.CurrentRow.Index >= _itensVenda.Count)
        {
            new FormMensagem("Atenção", "Selecione um produto na grade para remover.").ShowDialog();
            return;
        }

        int indice = dgProdutosVenda.CurrentRow.Index;
        _itensVenda.RemoveAt(indice);

        AtualizarGridItens();
        AtualizarTotalGeral();
    }

    private void DgProdutosVenda_KeyDown(object? sender, KeyEventArgs e)
    {
        if (!_somenteVisualizacao && e.KeyCode == Keys.Delete && dgProdutosVenda.CurrentRow != null)
        {
            btnRemoverProduto_Click(sender, EventArgs.Empty);
            e.Handled = true;
        }
    }

    private void AtualizarGridItens()
    {
        dgProdutosVenda.DataSource = null;
        if (_itensVenda.Count > 0)
        {
            dgProdutosVenda.DataSource = _itensVenda.ToList();
        }
    }

    private void AtualizarTotalGeral()
    {
        decimal totalGeral = _itensVenda.Sum(i => i.ValorTotalItem);
        lblTotalGeral.Text = $"R$ {totalGeral.ToString("N2", CulturaPtBr)}";
    }

    #endregion

    #region -> Gravação da Venda

    private void btnSalvar_Click(object? sender, EventArgs e)
    {
        if (_somenteVisualizacao || _salvandoVenda)
            return;

        _salvandoVenda = true;
        btnSalvar.Enabled = false;

        try
        {
            // Revalida o cliente informado no campo txtCodCliente
            txtCodCliente_Leave(txtCodCliente, EventArgs.Empty);
            if (_idClienteSelecionado <= 0)
            {
                new FormMensagem("Atenção", "Selecione um cliente válido e ativo para a venda.").ShowDialog();
                txtCodCliente.Focus();
                return;
            }

            if (cbVendedor.SelectedIndex < 0 || cbVendedor.SelectedValue == null ||
                !int.TryParse(cbVendedor.SelectedValue.ToString(), out int idUsuario) || idUsuario <= 0)
            {
                new FormMensagem("Atenção", "Selecione o vendedor responsável pela venda.").ShowDialog();
                cbVendedor.Focus();
                return;
            }

            if (_itensVenda.Count == 0)
            {
                new FormMensagem("Atenção", "Adicione pelo menos um produto à venda.").ShowDialog();
                txtCodProduto.Focus();
                return;
            }

            var venda = new Venda
            {
                IdCliente = _idClienteSelecionado,
                IdUsuario = idUsuario,
                DataVenda = DateTime.Now,
                Situacao = "Concluída",
                ValorTotal = _itensVenda.Sum(i => i.ValorTotalItem),
                Itens = _itensVenda.Select(i => new VendaItem
                {
                    IdProduto = i.IdProduto,
                    NomeProduto = i.NomeProduto,
                    Un = i.Un,
                    Quantidade = i.Quantidade,
                    ValorUnitario = i.ValorUnitario,
                    ValorTotalItem = i.ValorTotalItem
                }).ToList()
            };

            bool sucesso = _vendasServico.CadastraVenda(venda, out string mensagemErro);

            if (sucesso)
            {
                new FormMensagem("Sucesso", "Venda registrada com sucesso!").ShowDialog();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                new FormMensagem("Atenção", string.IsNullOrWhiteSpace(mensagemErro) ? "Falha ao registrar a venda." : mensagemErro).ShowDialog();
            }
        }
        catch (Exception ex)
        {
            new FormMensagem("Erro", $"Erro inesperado ao salvar a venda: {ex.Message}").ShowDialog();
        }
        finally
        {
            _salvandoVenda = false;
            if (!IsDisposed)
            {
                btnSalvar.Enabled = true;
            }
        }
    }

    private void btnVoltar_Click(object sender, EventArgs e)
    {
        Close();
    }

    #endregion
}
