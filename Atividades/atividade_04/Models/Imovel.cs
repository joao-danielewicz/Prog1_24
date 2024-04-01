using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace atividade_04.Models{

    public class Imovel{
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Descricao {get; set;}
        public float Valor {get; set;}
        public int QtdComodos {get; set;}
        public Localidade Localidade {get; set;}
        public TipoImovel TipoImovel {get; set;}
        public TipoNegocio TipoNegocio {get; set;}
    }
}