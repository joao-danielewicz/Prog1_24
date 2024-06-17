using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoBiblioteca.Models;
using ProjetoBiblioteca.Data;

namespace ProjetoBiblioteca.Repository
{
    public class UsuarioRepository{
        public void Create(Usuario usuario, bool autoGenerateId = true){
            if(autoGenerateId)
                usuario.UsuarioId = this.GetNextId();

            DataSet.Usuarios.Add(usuario);
        }
        public Usuario Read(int id){
            foreach(var usr in DataSet.Usuarios){
                if(usr.UsuarioId == id){
                    return usr;
                }
            }
            return null;
        }
        public List<Usuario> Read(){
            return DataSet.Usuarios;
        }
        public void Update(Usuario usuario){
            Delete(usuario.UsuarioId);
            Create(usuario, false);
        }
        public bool Delete(int id){
            Usuario usuario = DataSet.Usuarios.Find(i => i.UsuarioId == id);
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