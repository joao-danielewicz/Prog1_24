using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLocadora.Models{
    public class Item{
        public int ItemId {get; set; } = 0;
        public string Titulo {get; set; }  = "Não Definido";
        public string Diretor {get; set; } = "Não Definido";
        public string Genero {get; set; } = "Não Definido";
        public TiposMidia Tipo {get; set; } = 0;
        public string Estudio {get; set; } = "Não Definido";
        public DateTime Lancamento {get; set; } = DateTime.Now;
        public DateTime DataCadastro {get; set; } = DateTime.Now;
        public int QtdTotal {get; set; } = 1;
        public int QtdDisponivel {get; set; } = 1;
        public int LocadoraId {get; set; }
        public List<int> Emprestimos {get; set; } = new();

        public Item(){}

        public Item(int itemId){
            ItemId = itemId;
        }

        public Item(int itemId, string titulo, string diretor, string genero, TiposMidia tipoMidia, string estudio, DateTime lancamento, DateTime dataCadastro, int qtdTotal, int locadoraId){
            ItemId = itemId;
            Titulo = titulo;
            Diretor = diretor;
            Genero = genero;
            Tipo = tipoMidia;
            Estudio = estudio;
            Lancamento = lancamento;
            DataCadastro = dataCadastro;
            QtdTotal = qtdTotal;
            QtdDisponivel = qtdTotal;
            LocadoraId = locadoraId;
        }

        public override string ToString()
        {
            return $"{ItemId};{Titulo};{Diretor};{Genero};{Tipo};{Estudio};{Lancamento};{DataCadastro};{QtdTotal};{QtdDisponivel};{LocadoraId};";
        }
    }
}