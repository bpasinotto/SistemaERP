using System.Data;
using SistemaERP.Negocio;

namespace SistemaERP.Apresentacao;
public partial class FormUsuarios : FormBase2
{
    private DataTable dt;

    public FormUsuarios()
    {
        InitializeComponent();
    }

    private void FormUsuarios_Load(object sender, EventArgs e)
    {
        PreencheGrid();
    }

    internal void MudaCorGrid(string tema)
    {
        if (tema == "Escuro")
        {
            dgUsuarios.BackColor = Color.FromArgb(44, 44, 44);
            dgUsuarios.Style.CellStyle.BackColor = Color.FromArgb(44, 44, 44);
            dgUsuarios.Style.CellStyle.TextColor = Color.White;
            dgUsuarios.Style.HeaderStyle.BackColor = Color.LightGray;
            dgUsuarios.Style.CurrentCellStyle.BackColor = Color.LightGray;
            dgUsuarios.Style.SelectionStyle.BackColor = Color.LightGray;
        }
        else
        {
            dgUsuarios.BackColor = Color.White;
            dgUsuarios.Style.CellStyle.BackColor = Color.White;
            dgUsuarios.Style.CellStyle.TextColor = Color.FromArgb(44, 44, 44);
            dgUsuarios.Style.HeaderStyle.BackColor = Color.LightGray;
            dgUsuarios.Style.CurrentCellStyle.BackColor = Color.LightGray;
            dgUsuarios.Style.SelectionStyle.BackColor = Color.LightGray;
        }
    }

    private void PreencheGrid()
    {
        // Busca todos os usuários e atribui ao DataTable
        UsuariosServico usuariosServico = new UsuariosServico();
        dt = new DataTable();
        dt = usuariosServico.RetornaTodosUsuarios(cbInativos.Checked);

        dgUsuarios.DataSource = dt;
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        var idUsuario = 0;

        // Verifica se há alguma linha selecionada
        if (dgUsuarios.SelectedItems.Count > 0)
        {
            // Acessa o primeiro item selecionado
            var linhaSelecionada = dgUsuarios.SelectedItems[0];

            // Faz o cast para DataRow
            if (linhaSelecionada is DataRowView rowView)
            {
                idUsuario = Convert.ToInt32(rowView["Id"]);            
            }

            if (idUsuario == 1)
            {
                FormMensagem mensagem = new FormMensagem("Atenção", "Não é possivel editar esse usuário.");
                mensagem.ShowDialog();
                return;
            }
            else
            {
                UsuariosServico usuariosServico = new UsuariosServico();
                var dadosUsuario = usuariosServico.BuscaUsuarioId(idUsuario);

                //Abre o form de cadastro de usuário com os dados do usuário selecionado no dgUsuarios
                FormAlteraUsuarios formAlteraUsuarios = new FormAlteraUsuarios(dadosUsuario);
                formAlteraUsuarios.ShowDialog();

                // Atualiza a lista            
                PreencheGrid();
            }
           
        }
        else
        {
            FormMensagem mensagem = new FormMensagem("Atenção", "Selecione um usuário para editar.");
            mensagem.ShowDialog();
        }


    }

    private void btnNovo_Click(object sender, EventArgs e)
    {
        // Abre o form de cadastro de usuário
        FormCadUsuarios formCadUsuarios = new FormCadUsuarios();
        formCadUsuarios.ShowDialog();

        // Atualiza a lista
        PreencheGrid();
    }

    private void cbInativos_CheckedChanged(object sender, EventArgs e)
    {
        PreencheGrid();
    }

    private void txtPesquisa__TextChanged(object sender, EventArgs e)
    {
        string filtro = txtPesquisa.Texts.Trim();
        if (string.IsNullOrEmpty(filtro))
        {
            PreencheGrid();
        }
        else
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Join(" OR ", dt.Columns.Cast<DataColumn>()
                .Select(c => $"CONVERT([{c.ColumnName}], System.String) LIKE '%{filtro}%'"));
            dgUsuarios.DataSource = dv.ToTable();
        }
    }
}
