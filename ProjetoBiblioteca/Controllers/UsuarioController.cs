using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Repository;

namespace ProjetoBiblioteca.Controllers
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
        public List<Usuario> RetrieveAll(){
            return ur.Read();
        }
        public void Remove(int id){
            ur.Delete(id);
        }
        public void Update(Usuario usuario){
            ur.Update(usuario);
        }


    }
}