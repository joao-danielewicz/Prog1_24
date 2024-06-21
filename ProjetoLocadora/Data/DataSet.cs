using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;

namespace ProjetoLocadora.Data
{
    public class DataSet
    {
        public static List<Item> Itens { get; set; } = new();   
        public static List<Locadora> Locadoras { get; set; } = new();   
        public static List<Usuario> Usuarios { get; set; } = new();   

    }
}