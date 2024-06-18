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
                locadora.LocadoraId = this.GetNextId();

            DataSet.Locadoras.Add(locadora);
        }
        public Locadora Read(int id){
            foreach(var loc in DataSet.Locadoras){
                if(loc.LocadoraId == id){
                    return loc;
                }
            }
            return null;
        }
        public List<Locadora> Read(){
            return DataSet.Locadoras;
        }
        public void Update(Locadora locadora){
            Delete(locadora.LocadoraId);
            Create(locadora, false);
        }
        public bool Delete(int id){
            Locadora locadora = DataSet.Locadoras.Find(i => i.LocadoraId == id);
            if(locadora != null){
                DataSet.Locadoras.Remove(locadora);
                return true;
            }else{
                return false;
            }
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
    }
}