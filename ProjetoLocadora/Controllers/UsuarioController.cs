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
        public Usuario? Retrieve(int id){
            return ur.Read(id);
        }
        public List<Usuario> Retrieve(string termoBusca){
            return ur.Read(termoBusca);
        }
        public List<Usuario> RetrieveAll(){
            return ur.Read();
        }
        public bool Remove(int id){
            return ur.Delete(id);
        }
        public void Update(Usuario usuario){
            ur.Update(usuario);
        }


    }
}