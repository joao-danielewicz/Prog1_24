using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _240325_01.Models
{
    public class Veterinario
    {
        public int Id {get; set;}
        public int CPF {get; set;}
        public string Nome {get; set;}
        public string Genero {get; set;}
        public DateTime DtNascimento {get; set;}
        public string CRMV {get; set;}
        public string Email {get; set;}
        public string Fone {get; set;}
    }
}