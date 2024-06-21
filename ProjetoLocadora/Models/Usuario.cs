using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLocadora.Models
{
    public class Usuario
    {
       
        // -------------------------------------- ATRIBUTOS -----------------------------------

        public int UsuarioId { get; set; } = 0;
        public string Nome { get ; set; } = "Não definido";
        public int LocadoraId { get; set; }
        public static readonly string Formato = "{0, -3} {1, -30} {2, -15}";

        // ---------------------------------------- CONSTRUTORES -----------------------------------

        public Usuario(){}
        public Usuario(int usuarioId){
            UsuarioId = usuarioId;
        }
        public Usuario(int usuarioId, string nome, int locadoraId){
            UsuarioId = usuarioId;
            Nome = nome;
            LocadoraId = locadoraId;
        }
        
        // -------------------------------------- FUNÇÕES DE TEXTO -----------------------------------
        
        public string EscreverDadosDelimitados(){
            return $"{UsuarioId};{Nome};{LocadoraId}";
        }
        public override string ToString()
        {
            return string.Format(Formato, UsuarioId, Nome, LocadoraId);
        }
    }
}

