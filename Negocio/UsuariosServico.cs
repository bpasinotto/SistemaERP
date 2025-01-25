using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaERP.Dados;

namespace SistemaERP.Negocio;
public class UsuariosServico
{
    
    //Metodos
    public bool Autenticar(string Nome, string Senha)
    {
        UsuariosRepositorio usuarios = new UsuariosRepositorio();
        var result = usuarios.Dados(Nome, Senha);
                
        if (result == null)
        {
            return false;
        }
        else
        {
            if (Nome == result[1] && Senha == result[3])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
    

}
