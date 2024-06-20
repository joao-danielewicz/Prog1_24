using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Data;

namespace ProjetoLocadora.Repository
{
    public class UsuarioRepository{
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
        
        private int GetNextId(){
            int id = 0;
            foreach(var usr in DataSet.Usuarios){
                if(usr.UsuarioId>id){
                    id = usr.UsuarioId;
                }
            }
            return ++id;
        }
    }
}