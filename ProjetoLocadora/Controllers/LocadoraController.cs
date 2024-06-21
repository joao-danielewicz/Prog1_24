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
        
        // ---------------------------------- ATRIBUTOS -------------------------------

        private LocadoraRepository lr;

        // ---------------------------------- CONSTRUTORES -------------------------------

        public LocadoraController(){
            lr = new LocadoraRepository();
        }

        // ---------------------------------- CRUD -------------------------------

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

        private readonly string[] CaminhoDadosBase = [@"Arquivos\DadosBaseTeste\loc.txt", @"Arquivos\DadosBaseTeste\usrs.txt", @"Arquivos\DadosBaseTeste\itens.txt"];
        
        // ---------------------------------- OUTRAS FUNÇÕES -------------------------------

        public List<Item> VerificarEmprestimos(int LocadoraId){
            return lr.ItensEmprestados(LocadoraId);
        }
        public int VerificarLocadoras(){
            return lr.Read().Count;
        }
        
        // ---------------------------------- ARQUIVOS -------------------------------

        public string ExportToDelimited(){
            List<Locadora> list = RetrieveAll();

            string fileContent = string.Empty;
            foreach(var loc in list){
                fileContent += $"{loc.EscreverDadosDelimitados()}\n";
            }

            string fileName = $"DUMP_Locadoras_{DateTimeOffset.Now.ToFileTime()}.txt";
            if(ExportarDados.SalvarParaTexto(fileName, fileContent, null))
                return "Exportação concluída com sucesso.";
            else
                return "Erro na exportação dos dados.";
        }
        public string ImportFromDelimited(string filePath, string delimiter, bool firstExec = false){
            bool result = true;
            string msgReturn = string.Empty;
            int lineCountSuccess = 0;
            int lineCountError = 0;
            int lineCountTotal = 0;

            if(firstExec){
                try{
                    ItemController ic = new();
                    UsuarioController uc = new();
                    ImportFromDelimited(CaminhoDadosBase[0], ";");
                    uc.ImportFromDelimited(CaminhoDadosBase[1], ";");
                    ic.ImportFromDelimited(CaminhoDadosBase[2], ";");
                }catch{
                    return "Erro ao importar. Cadastre dados manualmente.";
                }
                return "Importação de dados preliminares concluída.";
            }

            try {
                if(!File.Exists(filePath)){
                    return "ERRO: Arquivo de importação não encontrado.";
                }

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