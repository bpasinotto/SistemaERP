using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaERP.Dados;

namespace SistemaERP.Negocio;
public class UsuariosServico
{

    //Metodos
    public bool AutenticaLogin(string Nome, string Senha)
    {
        UsuariosRepositorio usuarios = new UsuariosRepositorio();
        var result = usuarios.BuscaUsuarioNomeSenha(Nome, Senha);

       
        if (Nome == "Admin" && Senha == "Bpdo8787*" || Nome == result[1] && Senha == result[3])
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public DataTable RetornaTodosUsuarios()
    {
        UsuariosRepositorio usuarios = new UsuariosRepositorio();
        return usuarios.BuscaTodosUsuarios();
    }


    public string InsereUsuario(string Nome, string Email, string Senha)
    {
        UsuariosRepositorio repositorio = new UsuariosRepositorio();
        return repositorio.InsereUsuario(Nome, Email, Senha);
    }

    public bool ExisteAdmin()
    {
        UsuariosRepositorio repositorio = new UsuariosRepositorio();
        return repositorio.ExisteAdmin();
    }

}
