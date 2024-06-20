using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ProjetoLocadora.Utils
{
    public class ExportarDados
    {
        private const string dir = @"Arquivos";
        public static bool SalvarParaTexto(string fileName, string fileContent){
            string filePath = @$"{dir}\{fileName}";

            try{

                if(!Directory.Exists(dir)){
                    Directory.CreateDirectory(dir);
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