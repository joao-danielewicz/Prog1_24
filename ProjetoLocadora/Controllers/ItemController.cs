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
        public Item Retrieve(int id){
            return ir.Read(id);
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