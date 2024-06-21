using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoLocadora.Utils
{
    public class ExportarDados
    {
        // Escrever os dados dos objetos num arquivo .txt, organizando-os conforme a hierarquia estabelecida.
        // As locadoras terão uma pasta própria, onde ficarão todas juntas.
        // Seus respectivos arquivos ficarão numa pasta com o nome da locadora.
        private const string baseDir = @"Arquivos";
        public static bool SalvarParaTexto(string fileName, string fileContent, string nomeLocadora){            
            string pasta = "";
            if(nomeLocadora!=null)
                pasta = @$"{baseDir}\Itens e Usuarios\{nomeLocadora}";
            else
                pasta = @$"{baseDir}\Locadoras";

            string filePath = @$"{pasta}\{fileName}";
            WriteLine(filePath);
            ReadLine();

            try{

                if(!Directory.Exists(pasta)){
                    Directory.CreateDirectory(pasta);
                }
                
                using(StreamWriter sw = File.CreateText(filePath)){
                    sw.Write(fileContent);
                }
            }
            catch{
                return false;
            }

            return true;
        }
    }
}