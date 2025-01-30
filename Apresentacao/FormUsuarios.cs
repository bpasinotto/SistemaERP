using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaERP.Negocio;
using Syncfusion.WinForms.DataGrid;

namespace SistemaERP.Apresentacao;
public partial class FormUsuarios : Form
{
    private SfDataGrid sfDataGrid;

    private DataTable dt;

    public FormUsuarios()
    {
        InitializeComponent();

        //sfDataGrid = new SfDataGrid();
        //sfDataGrid.Dock = DockStyle.Fill;

        //// Adiciona o controle ao formulário
        //pnMeio.Controls.Add(sfDataGrid);


        // Busca todos os usuários e atribui ao DataTable
        UsuariosServico usuariosServico = new UsuariosServico();
        dt = new DataTable();
        dt = usuariosServico.RetornaTodosUsuarios();

        dgUsuarios.DataSource = dt;

        //// Atribui ao grid
        //sfDataGrid.DataSource = dt;
        //sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
        //sfDataGrid.AllowEditing = false;



    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        // Abre o form de cadastro de usuário com os dados do usuário selecionado no dgUsuarios
        FormCadUsuarios formCadUsuarios = new FormCadUsuarios();
        formCadUsuarios.ShowDialog();


    }

    private void btnNovo_Click(object sender, EventArgs e)
    {
        // Abre o form de cadastro de usuário
        FormCadUsuarios formCadUsuarios = new FormCadUsuarios();
        formCadUsuarios.ShowDialog();

        // Atualiza a lista
        UsuariosServico usuariosServico = new UsuariosServico();
        dt = new DataTable();
        dt = usuariosServico.RetornaTodosUsuarios();

        dgUsuarios.DataSource = dt;

    }
}
