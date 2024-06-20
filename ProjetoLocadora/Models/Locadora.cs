using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLocadora.Models
{
    public class Locadora
    {
        public int LocadoraId { get; set; } = 0;
        public string Nome { get; set; } = "Não definido";
        public string Localizacao { get; set; }  = "Não definido";
        public int Acervo { get; set; } = 0;
        public static readonly string Formato = "{0, -3} {1, -30} {2, -30} {4, -5}";

        public Locadora(){}

        public Locadora(int locadoraId){
            LocadoraId = locadoraId;
        }

        public Locadora(int locadoraId, string nome, string localizacao){
            LocadoraId = locadoraId;
            Nome = nome;
            Localizacao = localizacao;
        }
        public string EscreverDadosDelimitados(){
            return $"{LocadoraId};{Nome};{Localizacao}";
        }
        public override string ToString(){
            return string.Format(Formato, LocadoraId, Nome, Localizacao, Acervo);
        }
    }
}



