using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Data;

namespace ProjetoLocadora.Repository
{
    public class LocadoraRepository{
        public void Create(Locadora locadora, bool autoGenerateId = true){
            if(autoGenerateId)
                locadora.LocadoraId = GetNextId();

            DataSet.Locadoras.Add(locadora);
        }
        public Locadora? Read(int id){
            foreach(var loc in DataSet.Locadoras){
                if(loc.LocadoraId == id){
                    return loc;
                }
            }
            return null;
        }
        public List<Locadora> Read(string termoBusca){
            List<Locadora> locadoras = new();
            foreach(var loc in Read()){
                if(loc.Nome.ToLower().Contains(termoBusca.ToLower())){
                    locadoras.Add(loc);
                }
            }
            return locadoras;
        }
        public List<Locadora> Read(){
            return DataSet.Locadoras;
        }
        public void Update(Locadora locadora){
            Delete(locadora.LocadoraId);
            Create(locadora, false);
        }
        public bool Delete(int id){
            Locadora? locadora = DataSet.Locadoras.Find(i => i.LocadoraId == id);
            if(locadora != null){
                DataSet.Locadoras.Remove(locadora);
                return true;
            }else{
                return false;
            }
        }

        public List<Item> ItensEmprestados(int locadoraId){
            List<Item> emprestados = new();
            foreach(Item item in DataSet.Itens){
                if(item.LocadoraId == locadoraId && item.UsuarioId!=0){
                    emprestados.Add(item);
                }
            }
            return emprestados;
        }
        
        private int GetNextId(){
            int id = 0;
            foreach(var loc in DataSet.Locadoras){
                if(loc.LocadoraId>id){
                    id = loc.LocadoraId;
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
            
            Locadora loc = new Locadora{
                LocadoraId = Convert.ToInt32(data[0] == null ? 0 : data[0]),
                Nome = data[1] == null ? string.Empty : data[1],
                Localizacao = data[2] == null ? string.Empty : data[2],
                Acervo = Convert.ToInt32(data[3] == null ? 0 : data[3])
            };

            Create(loc, false);

            return true; 
        }
    }
}