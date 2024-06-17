using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBiblioteca.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get ; set; } = "Não definido";
        public int LocadoraId { get; set; }

        public Usuario(){}

        public Usuario(int usuarioId){
            UsuarioId = usuarioId;
        }

        public Usuario(string nome, int locadoraId){
            Nome = nome;
            LocadoraId = locadoraId;
        }
    }
}