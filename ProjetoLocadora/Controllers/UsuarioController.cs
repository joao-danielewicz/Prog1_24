using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Repository;

namespace ProjetoLocadora.Controllers
{
    public class UsuarioController
    {
        private UsuarioRepository ur;

        public UsuarioController(){
            ur = new UsuarioRepository();
        }

        public void Insert(Usuario usuario){
            ur.Create(usuario);
        }
        public Usuario? Retrieve(int id, int locadoraId){
            return ur.Read(id, locadoraId);
        }
        public List<Usuario> Retrieve(string termoBusca, int locadoraId){
            return ur.Read(termoBusca, locadoraId);
        }
        public List<Usuario> RetrieveAll(int locadoraId){
            return ur.Read(locadoraId);
        }
        public bool Remove(int id){
            return ur.Delete(id);
        }
        public void Update(Usuario usuario){
            ur.Update(usuario);
        }
    }
}