using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Repository;

namespace ProjetoBiblioteca.Controllers
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
        public List<Item> RetrieveAll(){
            return ir.Read();
        }
        public void Remove(int id){
            ir.Delete(id);
        }
        public void Update(Item item){
            ir.Update(item);
        }


    }
}