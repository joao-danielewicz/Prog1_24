using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Data;
using System.Reflection.Metadata;

namespace ProjetoLocadora.Repository
{
    public class ItemRepository{
        public void Create(Item item, bool autoGenerateId = true){
            if(autoGenerateId)
                item.ItemId = GetNextId();

            DataSet.Itens.Add(item);
        }
        public Item? Read(int id, int locadoraId){
            foreach(var item in DataSet.Itens){
                if(item.ItemId == id && item.LocadoraId == locadoraId){
                    return item;
                }
            }
            return null;
        }
        public List<Item> Read(string termoBusca, int locadoraId){
            List<Item> itens = new();
            foreach(var item in Read(locadoraId)){
                if(item.Titulo.ToLower().Contains(termoBusca.ToLower())){
                    itens.Add(item);
                }
            }
            return itens;
        }
        public List<Item> Read(int locadoraId){
            List<Item> result = new();
            foreach(var item in DataSet.Itens){
                if(item.LocadoraId == locadoraId){
                    result.Add(item);
                }
            }
            return result;
        }
        public void Update(Item item){
            Delete(item.ItemId);
            Create(item, false);
        }
        public bool Delete(int id){
            Item? item = DataSet.Itens.Find(i => i.ItemId == id);
            if(item != null){
                DataSet.Itens.Remove(item);
                return true;
            }else{
                return false;
            }
        }

        public bool Emprestar(Item item, int usuarioId){
            if(item.UsuarioId==0){
                item.UsuarioId = usuarioId;
                Update(item);
                return true;
            }else {
                return false;
            }
        }
        public void Devolver(Item item){
            item.UsuarioId=0;
            Update(item);
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


        public bool ImportFromTxt(string line, string delimiter){
            if(string.IsNullOrWhiteSpace(line))
                return false;

            string[] data = line.Split(delimiter);

            if(data.Count()<1)
                return false;
            
            Item item = new Item{
                ItemId = Convert.ToInt32(data[0] == null ? 0 : data[0]),
                Titulo = (data[1] == null ? string.Empty : data[1]),
                Diretor = data[2] ?? string.Empty,
                Genero = data[3] ?? string.Empty,
                Tipo = (TiposMidia)Convert.ToInt32(data[4] == null ? 0 : data[4]),
                Estudio = data[5] ?? string.Empty,
                Lancamento = Convert.ToDateTime(data[6] == null ? DateTime.Now : data[6]),
                DataCadastro = Convert.ToDateTime(data[7] == null ? DateTime.Now : data[7]),
                LocadoraId = Convert.ToInt32(data[8] == null ? 0 : data[8]),
            };

            Create(item, false);

            return true; 
        }
    }
}