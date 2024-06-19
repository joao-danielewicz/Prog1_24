using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Repository;

namespace ProjetoLocadora.Controllers
{
    public class ItemController
    {
        private ItemRepository ir;

        public ItemController(){
            ir = new ItemRepository();
        }

        public void Insert(Item item){
            ir.Create(item);
        }
        public Item? Retrieve(int id){
            return ir.Read(id);
        }
        public List<Item> Retrieve (string termoBusca){
            return ir.Read(termoBusca);
        }
        public List<Item> RetrieveAll(){
            return ir.Read();
        }
        public bool Remove(int id){
            return ir.Delete(id);
        }
        public void Update(Item item){
            ir.Update(item);
        }
    }
}