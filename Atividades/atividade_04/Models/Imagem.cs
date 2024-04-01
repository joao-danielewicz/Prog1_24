using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace atividade_04.Models{

    public class Imagem{
        public int Id {get; set;}
        public byte[] BytesImagem {get; set;}
        public Imovel Imovel {get; set;}
    }
}