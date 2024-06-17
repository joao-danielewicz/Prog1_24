using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Repository;

namespace ProjetoBiblioteca.Controllers
{
    public class LocadoraController
    {
        private LocadoraRepository lr;

        public LocadoraController(){
            lr = new LocadoraRepository();
        }

        public void Insert(Locadora Locadora){
            lr.Create(Locadora);
        }
        public List<Locadora> RetrieveAll(){
            return lr.Read();
        }
        public void Remove(int id){
            lr.Delete(id);
        }
        public void Update(Locadora locadora){
            lr.Update(locadora);
        }


    }
}