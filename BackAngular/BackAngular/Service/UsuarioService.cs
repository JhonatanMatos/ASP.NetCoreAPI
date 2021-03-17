using BackAngular.Models;
using BackAngular.Service;
using System.Collections.Generic;
using System.Linq;

namespace BackAngular.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly List<Usuario> usuarios;

        public UsuarioService()
        {
            this.usuarios = new List<Usuario>
            {
                new Usuario { Id = 1, Nome = "" },
                new Usuario { Id = 2, Nome = "" },
                new Usuario { Id = 3, Nome = "Ana"}
            };
        }

        public void AddUsuario(Usuario item)
        {
            this.usuarios.Add(item);
        }

        public void DeleteUsuario(int id)
        {
            var model = this.usuarios.Where(m => m.Id == id).FirstOrDefault();
            this.usuarios.Remove(model);
        }

        public bool UsuarioExists(int id)
        {
            return this.usuarios.Any(m => m.Id == id);
        }

        public Usuario GetUsuario(int id)
        {
            return this.usuarios.Where(m => m.Id == id).FirstOrDefault();
        }

        public List<Usuario> GetUsuarios()
        {
            return this.usuarios.ToList();
        }

        public void UpdateUsuario(Usuario item)
        {
            var model = this.usuarios.Where(m => m.Id == item.Id).FirstOrDefault();

            model.Nome = item.Nome;
            model.Parcelas = item.Parcelas;
            model.Valor = item.Valor;
        }
    }
}
