using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoLocadora.Utils
{
    public class ExportarDados
    {
        private const string baseDir = @"Arquivos";
        public static bool SalvarParaTexto(string fileName, string fileContent, string nomeLocadora){            
            string pasta = "";
            if(nomeLocadora!=null)
                pasta = @$"{baseDir}\Itens e Usuários\{nomeLocadora}";
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