using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Data;

namespace ProjetoLocadora.Repository
{
    public class UsuarioRepository{
        // --------------------------------- CRUD -------------------------------------
        public void Create(Usuario usuario, bool autoGenerateId = true){
            if(autoGenerateId)
                usuario.UsuarioId = this.GetNextId();

            DataSet.Usuarios.Add(usuario);
        }
        public Usuario? Read(int id, int locadoraId){
            foreach(var usr in DataSet.Usuarios){
                if(usr.UsuarioId == id && usr.LocadoraId == locadoraId){
                    return usr;
                }
            }
            return null;
        }
        public List<Usuario> Read(string termoBusca, int locadoraId){
            List<Usuario> usuarios = new();
            foreach(Usuario usr in Read(locadoraId)){
                if(usr.Nome.ToLower().Contains(termoBusca.ToLower())){
                    usuarios.Add(usr);
                }
            }
            return usuarios;
        }
        public List<Usuario> Read(int locadoraId){
            List<Usuario> result = new();
            foreach(var usr in DataSet.Usuarios){
                if(usr.LocadoraId == locadoraId){
                    result.Add(usr);
                }
            }
            return result;
        }
        public void Update(Usuario usuario){
            Delete(usuario.UsuarioId);
            Create(usuario, false);
        }
        public bool Delete(int id){
            Usuario? usuario = DataSet.Usuarios.Find(i => i.UsuarioId == id);
            if(usuario != null){
                DataSet.Usuarios.Remove(usuario);
                return true;
            }else{
                return false;
            }
        }
        
        // ------------------------- OUTRAS FUNÇÕES -------------------------------------

        private int GetNextId(){
            int id = 0;
            foreach(var usr in DataSet.Usuarios){
                if(usr.UsuarioId>id){
                    id = usr.UsuarioId;
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
            
            Usuario usr = new Usuario{
                UsuarioId = Convert.ToInt32(data[0] == null ? 0 : data[0]),
                Nome = data[1] ?? string.Empty,
                LocadoraId = Convert.ToInt32(data[2] == null ? 0 : data[2]),
            };

            Create(usr, false);

            return true; 
        }
    }
}