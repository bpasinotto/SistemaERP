using System.Globalization;
using System.Reflection.Metadata;
using Microsoft.IdentityModel.Tokens;
using SistemaERP.Negocio;
using SistemaERP.RJControls;

namespace SistemaERP.Apresentacao
{
    public partial class FormCadClientes : FormBase
    {
        string Id = "";
        public FormCadClientes()
        {
            InitializeComponent();
            btnAtivaInativa.Visible = false;
        }

        public FormCadClientes(List<string> lista)
        {
            InitializeComponent();

            // Preencher campos com dados do cliente
            Id = lista[0];
            txtCNPJ.Texts = lista[1];
            txtRazao.Texts = lista[2];
            txtFantasia.Texts = lista[3];
            txtEmail.Texts = lista[4];
            txtTelefone.Texts = lista[5];
            txtCEP.Texts = lista[6];
            txtRua.Texts = lista[7];
            txtNumero.Texts = lista[8];
            txtBairro.Texts = lista[9];
            txtComplemento.Texts = lista[10];
            txtCidade.Texts = lista[11];
            txtEstado.Texts = lista[12];
            txtObs.Texts = lista[13];
            if (lista[14] == "False")
            {
                btnAtivaInativa.Text = "Ativar Cliente";
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controlar o tamanho máximo de 14 caracteres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && txtCNPJ.Texts.Replace(".", "").Replace("/", "").Replace("-", "").Length >= 14)
            {
                e.Handled = true;
            }
        }


        private async void btnBuscaCnpj_Click(object sender, EventArgs e)
        {
            var retorno = await new ClientesServico().ValidaDocumentoAsync(txtCNPJ.Texts);

            if (txtCNPJ.Texts.IsNullOrEmpty())
            {
                return;
            }
            else if (!txtCNPJ.Texts.IsNullOrEmpty() && txtCNPJ.Texts.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "").Length == 14)
            {
                if (retorno[0] == "2")
                {
                    new FormMensagem("Documento", "CNPJ inválido.").ShowDialog();
                }
                else if (retorno[0] == "4")
                {
                    new FormMensagem("Erro", "Aguarde 1 minuto e tente novamente.").ShowDialog();
                }
                else if (retorno[0] == "5")
                {
                    new FormMensagem("Erro", "Verifique sua conexão com a internet.").ShowDialog();
                }
                else
                {
                    txtCNPJ.Texts = retorno[0].ToString();
                    txtRazao.Texts = retorno[1].ToString();
                    txtFantasia.Texts = retorno[2].ToString();
                    txtTelefone.Texts = retorno[3].ToString();
                    txtEmail.Texts = retorno[4].ToString();
                    txtCEP.Texts = retorno[5].ToString();
                    txtRua.Texts = retorno[6].ToString();
                    txtNumero.Texts = retorno[7].ToString();
                    txtBairro.Texts = retorno[8].ToString();
                    txtComplemento.Texts = retorno[9].ToString();
                    txtCidade.Texts = retorno[10].ToString();
                    txtEstado.Texts = retorno[11].ToString();
                    txtObs.Focus();
                }

            }
            else if (!txtCNPJ.Texts.IsNullOrEmpty() && txtCNPJ.Texts.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "").Length == 11)
            {
                if (retorno[0] == "1")
                {
                    new FormMensagem("Documento", "CPF inválido.").ShowDialog();
                }
                else
                {
                    txtCNPJ.Texts = retorno[0];
                }

            }
            else if (!txtCNPJ.Texts.IsNullOrEmpty() && txtCNPJ.Texts.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "").Length < 11)
            {
                new FormMensagem("Documento", "Está faltando números.").ShowDialog();
            }
            else
            {
                new FormMensagem("Documento", "Documento inválido.").ShowDialog();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!txtRazao.Texts.IsNullOrEmpty())
            {
                if (Id != "")
                {
                    var sucesso = new ClientesServico().AlteraCliente(Id, txtCNPJ.Texts, txtRazao.Texts, txtFantasia.Texts, txtEmail.Texts, txtTelefone.Texts, txtCEP.Texts, txtRua.Texts, txtNumero.Texts, txtBairro.Texts, txtComplemento.Texts, txtCidade.Texts, txtEstado.Texts, txtObs.Texts);
                    var mensagem = new FormMensagem(sucesso ? "Sucesso" : "Falha", sucesso ? "Cliente atualizado com sucesso." : "Falha na atualização do cliente.");
                    mensagem.ShowDialog();
                    if (sucesso) Close();
                }
                else
                {
                    var sucesso = new ClientesServico().InsereCliente(txtCNPJ.Texts, txtRazao.Texts, txtFantasia.Texts, txtEmail.Texts, txtTelefone.Texts, txtCEP.Texts, txtRua.Texts, txtNumero.Texts, txtBairro.Texts, txtComplemento.Texts, txtCidade.Texts, txtEstado.Texts, txtObs.Texts);
                    var mensagem = new FormMensagem(sucesso ? "Sucesso" : "Falha", sucesso ? "Cliente cadastrado com sucesso." : "Falha no cadastro do cliente.");
                    mensagem.ShowDialog();
                    if (sucesso) LimparCampos();
                }
            }
            else
            {
                new FormMensagem("Atenção", "Preencha o campo obrigatório 'Razão Social'").ShowDialog();
            }

        }

        private void LimparCampos()
        {
            txtCNPJ.Texts = string.Empty;
            txtRazao.Texts = string.Empty;
            txtFantasia.Texts = string.Empty;
            txtTelefone.Texts = string.Empty;
            txtEmail.Texts = string.Empty;
            txtCEP.Texts = string.Empty;
            txtRua.Texts = string.Empty;
            txtNumero.Texts = string.Empty;
            txtBairro.Texts = string.Empty;
            txtComplemento.Texts = string.Empty;
            txtCidade.Texts = string.Empty;
            txtEstado.Texts = string.Empty;
            txtObs.Texts = string.Empty;
            txtCNPJ.Focus();
        }

        private void txtCNPJ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscaCnpj_Click(sender, e);
            }
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            var telefone = txtTelefone.Texts;
            // Adicionar máscara de telefone
            if (telefone.Length == 11)
            {
                txtTelefone.Texts = Convert.ToUInt64(telefone).ToString(@"(00) 00000-0000");
            }
            else if (telefone.Length == 10)
            {
                txtTelefone.Texts = Convert.ToUInt64(telefone).ToString(@"(00) 0000-0000");
            }
        }

        private void btnAtivaInativa_Click(object sender, EventArgs e)
        {
            var sucesso = new ClientesServico().InativaAtivaCliente(Id, btnAtivaInativa.Text == "Ativar Cliente");
            var mensagem = new FormMensagem(sucesso ? "Sucesso" : "Falha", sucesso ? "Cliente atualizado com sucesso." : "Falha na atualização do cliente.");
            mensagem.ShowDialog();
            if (sucesso) Close();
        }

        private async void btnBuscaCep_Click(object sender, EventArgs e)
        {
            string cep = txtCEP.Texts.Replace("-", "").Replace(".", "").Trim();

            if(cep.IsNullOrEmpty())
            {
                return;
            }
            else if (cep.Length != 8 || !long.TryParse(cep, out _))
            {
                new FormMensagem("Erro", "CEP inválido.").ShowDialog();
                return;
            }

            var clientesServico = new ClientesServico();
            var endereco = await clientesServico.ConsultaCepAsync(cep);

            if (endereco.ContainsKey("erro"))
            {
                new FormMensagem("Erro", endereco["erro"]).ShowDialog();
            }
            else
            {
                txtRua.Texts = endereco["logradouro"];
                txtBairro.Texts = endereco["bairro"];
                txtCidade.Texts = endereco["localidade"];
                txtEstado.Texts = endereco["uf"];
                txtComplemento.Texts = endereco["complemento"];
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controlar o tamanho máximo de 8 caracteres
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsDigit(e.KeyChar) && txtCEP.Texts.Replace("-", "").Length >= 8)
            {
                e.Handled = true;
            }
        }

        private void txtCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscaCep_Click(sender, e);
            }
        }
    }
}
