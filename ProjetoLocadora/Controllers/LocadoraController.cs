using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Repository;
using ProjetoLocadora.Utils;

namespace ProjetoLocadora.Controllers
{
    public class LocadoraController
    {
        private LocadoraRepository lr;

        public LocadoraController(){
            lr = new LocadoraRepository();
        }

        public void Insert(Locadora Locadora){
            lr.Create(Locadora);
        }
        public Locadora? Retrieve(int id){
            return lr.Read(id);
        }
        public List<Locadora> Retrieve(string termoBusca){
            return lr.Read(termoBusca);
        }
        public List<Locadora> RetrieveAll(){
            return lr.Read();
        }
        public bool Remove(int id){
            return lr.Delete(id);
        }
        public void Update(Locadora locadora){
            lr.Update(locadora);
        }


        public bool ExportToDelimited(){
            List<Locadora> list = RetrieveAll();

            string fileContent = string.Empty;
            foreach(var loc in list){
                fileContent += $"{loc.EscreverDadosDelimitados()}\n";
            }

            string fileName = $"DUMP_Locadoras_{DateTimeOffset.Now.ToFileTime()}.txt";
            return ExportarDados.SalvarParaTexto(fileName, fileContent);
        }

        public string ImportFromDelimited(string filePath, string delimiter){
            bool result = true;
            string msgReturn = string.Empty;
            int lineCountSuccess = 0;
            int lineCountError = 0;
            int lineCountTotal = 0;

            try {
                if(!File.Exists(filePath))
                    return "ERRO: Arquivo de importação não encontrado.";

                using(StreamReader sr = new StreamReader(filePath)){
                    string line = string.Empty;
                    while((line = sr.ReadLine()) != null){
                        lineCountTotal++;
                        if(!lr.ImportFromTxt(line, delimiter)){
                            result = false;
                            lineCountError++;
                        }else{
                            lineCountSuccess++;
                        }
                    }

                }
                
            } catch(System.Exception ex){
                return $"ERRO: {ex.Message}";
            }
            if(result)
                msgReturn = "Dados importados com sucesso.";
            else
                msgReturn = "Dados parcialmente importados.";
            msgReturn += $"\nTotal de linhas: {lineCountTotal}";
            msgReturn += $"\nLinhas com sucesso: {lineCountSuccess}";
            msgReturn += $"\nLinhas com erro: {lineCountError}";


            return msgReturn;
        }
    }
}