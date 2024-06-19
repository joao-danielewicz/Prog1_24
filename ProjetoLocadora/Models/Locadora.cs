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
        public int Capacidade { get; set; } = 1000;
        public int Acervo { get; set; } = 0;

        public Locadora(){}

        public Locadora(int locadoraId){
            LocadoraId = locadoraId;
        }

        public Locadora(int locadoraId, string nome, string localizacao){
            LocadoraId = locadoraId;
            Nome = nome;
            Localizacao = localizacao;
        }

        public override string ToString(){
            return $"{LocadoraId};{Nome};{Localizacao}";
        }
    }
}



