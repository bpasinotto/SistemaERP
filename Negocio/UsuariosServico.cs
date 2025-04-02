using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaERP.Dados;
using System.Text.RegularExpressions;

namespace SistemaERP.Negocio;
public class UsuariosServico
{

    //Metodos
    internal int AutenticaLogin(string Nome, string Senha)
    {        
        var resultado = new UsuariosRepositorio().BuscaUsuarioNomeSenha(Nome, Senha);

        // Se o resultado no index 1 for igual a 1 retorna o id do usuário, senão retorna 0
        if (resultado[1] == 1)
        {
            return resultado[0];
        }
        else
        {
            return 0;
        }


    }

    public bool ValidarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Define um padrão de regex para validar o formato do email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            // Verifica se o email corresponde ao padrão
            return regex.IsMatch(email);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    // Validar senha do cadastro de usuário
    public bool ValidarSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            return false;
        try
        {
            // Verifica se a senha tem mais de 3 caracteres
            return senha.Length > 3;
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    // Validar nome do cadastro de usuário
    public bool ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return false;
        try
        {
            // Verifica se o nome tem mais de 2 caracteres
            return nome.Length > 2;
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    public DataTable RetornaTodosUsuarios(bool Inativos)
    {
        var Status = 1;
        if (Inativos)
        {
            Status = 0;
        }

        UsuariosRepositorio usuarios = new UsuariosRepositorio();
        return usuarios.BuscaTodosUsuarios(Status);
    }


    public bool InsereUsuario(string Nome, string Email, string Senha)
    {        
        return new UsuariosRepositorio().InsereUsuario(Nome, Email, Senha);
    }

    public int ExisteAdmin()
    {
        UsuariosRepositorio repositorio = new UsuariosRepositorio();
        return repositorio.ExisteAdmin();
    }

    public List<string> BuscaUsuarioId(int Id)
    {
        UsuariosRepositorio repositorio = new UsuariosRepositorio();
        return repositorio.BuscaUsuarioId(Id);
    }


    public bool AlterarUsuario(string Id, string Nome, string Email, string Senha)
    {       
        UsuariosRepositorio repositorio = new UsuariosRepositorio();
        return repositorio.AlterarUsuario(Id, Nome, Email, Senha);
    }


    //Inativa e ativa um usuário
    public bool InativaAtivaUsuario(string Id, bool Inativar)
    {
        UsuariosRepositorio repositorio = new UsuariosRepositorio();
        return repositorio.InativarAtivarUsuario(Id, Inativar);
    }

}
