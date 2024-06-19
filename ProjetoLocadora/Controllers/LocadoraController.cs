using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Repository;

namespace ProjetoLocadora.Controllers
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
        public Locadora? Retrieve(int id){
            return lr.Read(id);
        }
        public List<Locadora> Retrieve(string termoBusca){
            return lr.Read(termoBusca);
        }
        public List<Locadora> RetrieveAll(){
            return lr.Read();
        }
        public bool Remove(int id){
            return lr.Delete(id);
        }
        public void Update(Locadora locadora){
            lr.Update(locadora);
        }
    }
}