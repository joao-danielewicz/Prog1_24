using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace _240527_01.Utils
{
    public class ExportToFile
    {
        private const string dir = @"C:\Users\414732\Desktop\Prog1_24\Exercicios\Arquivos";
        public static bool SaveToDelimitedTxt(string fileName, string fileContent){
            string filePath = @$"{dir}\{fileName}";

            if(!Directory.Exists(dir)){
                Directory.CreateDirectory(dir);
            }
            
            using(StreamWriter sw = File.CreateText(filePath)){
                sw.Write(fileContent);
            }

            return true;
        }
    }
}