using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackAngular.Models;

namespace BackAngular.Service
{
    public interface IUsuarioService
    {
        List<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        void AddUsuario(Usuario item);        
        bool UsuarioExists(int id);
    }
}
