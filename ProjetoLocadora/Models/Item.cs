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
        public int LocadoraId {get; set; }
        public int UsuarioId {get; set; } = 0;

        public Item(){}

        public Item(int itemId){
            ItemId = itemId;
        }

        public Item(int itemId, string titulo, string diretor, string genero, TiposMidia tipoMidia, string estudio, DateTime lancamento, DateTime dataCadastro, int locadoraId){
            ItemId = itemId;
            Titulo = titulo;
            Diretor = diretor;
            Genero = genero;
            Tipo = tipoMidia;
            Estudio = estudio;
            Lancamento = lancamento;
            DataCadastro = dataCadastro;
            LocadoraId = locadoraId;
        }
        public string EscreverDadosDelimitados(){
            int tipoMidia = (int)Tipo;
            return $"{ItemId};{Titulo};{Diretor};{Genero};{tipoMidia};{Estudio};{Lancamento};{DataCadastro};{LocadoraId}";
        }
        public override string ToString()
        {
            // return string.Format("{0, -30} {1, 3}", Name, CustomerId);
            return $"ID: {ItemId}\nTítulo: {Titulo}\nDiretor(a): {Diretor}\nGênero: {Genero}\nTipo da obra: {Tipo}\nEstúdio: {Estudio}\nData de lançamento: {Lancamento}\nAlteração em: {DataCadastro}";
        }
    }
}