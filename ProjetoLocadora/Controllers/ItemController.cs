using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Repository;
using ProjetoLocadora.Utils;

namespace ProjetoLocadora.Controllers
{
    public class ItemController
    {
        private ItemRepository ir;
        private LocadoraController lc;

        public ItemController(){
            ir = new ItemRepository();
            lc = new LocadoraController();
        }

        public void Insert(Item item){
            ir.Create(item);
        }
        public Item? Retrieve(int id, int locadoraId){
            return ir.Read(id, locadoraId);
        }
        public List<Item> Retrieve (string termoBusca, int locadoraId){
            return ir.Read(termoBusca, locadoraId);
        }
        public List<Item> RetrieveAll(int locadoraId){
            return ir.Read(locadoraId);
        }
        public bool Remove(int id){
            return ir.Delete(id);
        }
        public void Update(Item item){
            ir.Update(item);
        }

        public string Emprestar(Item item, int usuarioId){
            if(ir.Emprestar(item, usuarioId))
                return "Item emprestado com sucesso.";
            else
                return "Este item já está emprestado.";
        }
        public string Devolver(Item item){
            ir.Devolver(item);
            return "Item devolvido com sucesso.";
        }


        public string ExportToDelimited(int locadoraId){
            List<Item> list = RetrieveAll(locadoraId);
            string fileContent = string.Empty;
            foreach(var item in list){
                fileContent += $"{item.EscreverDadosDelimitados()}\n";
            }
                WriteLine("banana");
                ReadLine();
            string fileName = $"DUMP_Itens_{DateTimeOffset.Now.ToFileTime()}.txt";
            if(ExportarDados.SalvarParaTexto(fileName, fileContent, lc.Retrieve(locadoraId).Nome))
                return "Exportação concluída com sucesso.";
            else{
                return "Erro na exportação dos dados.";
            }
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
                        if(!ir.ImportFromTxt(line, delimiter)){
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