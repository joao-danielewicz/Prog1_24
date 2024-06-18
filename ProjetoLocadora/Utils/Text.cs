using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLocadora.Utils
{
    public class Texto{
        public void WriteMenu(string titulo, string[] msg){
            WriteLine(titulo);
            foreach(int i in titulo){
                Write("*");
            }
            WriteLine();

            foreach(string linha in msg){
                string qtd = ((titulo.Length+linha.Length)/2).ToString();
                string formato = "{0, "+qtd+"}";
                WriteLine(string.Format(formato, linha));
            }
        }
        
    }
}