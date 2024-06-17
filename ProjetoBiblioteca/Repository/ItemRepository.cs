using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Data;

namespace ProjetoBiblioteca.Repository
{
    public class ItemRepository{
        public void Create(Item item, bool autoGenerateId = true){
            if(autoGenerateId)
                item.ItemId = this.GetNextId();

            DataSet.Itens.Add(item);
        }
        public Item Read(int id){
            foreach(var item in DataSet.Itens){
                if(item.ItemId == id){
                    return item;
                }
            }
            return null;
        }
        public List<Item> Read(){
            return DataSet.Itens;
        }
        public void Update(Item item){
            Delete(item.ItemId);
            Create(item, false);
        }
        public bool Delete(int id){
            Item item = DataSet.Itens.Find(i => i.ItemId == id);
            if(item != null){
                DataSet.Itens.Remove(item);
                return true;
            }else{
                return false;
            }
        }
        
        private int GetNextId(){
            int id = 0;
            foreach(var item in DataSet.Itens){
                if(item.ItemId>id){
                    id = item.ItemId;
                }
            }
            return ++id;
        }
    }
}