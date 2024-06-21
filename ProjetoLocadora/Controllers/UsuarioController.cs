using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Models;
using ProjetoLocadora.Repository;
using ProjetoLocadora.Utils;

namespace ProjetoLocadora.Controllers
{
    public class UsuarioController
    {
        private UsuarioRepository ur;
        private LocadoraController lc;
        public UsuarioController(){
            ur = new UsuarioRepository();
            lc = new LocadoraController();
        }

        public void Insert(Usuario usuario){
            ur.Create(usuario);
        }
        public Usuario? Retrieve(int id, int locadoraId){
            return ur.Read(id, locadoraId);
        }
        public List<Usuario> Retrieve(string termoBusca, int locadoraId){
            return ur.Read(termoBusca, locadoraId);
        }
        public List<Usuario> RetrieveAll(int locadoraId){
            return ur.Read(locadoraId);
        }
        public bool Remove(int id){
            return ur.Delete(id);
        }
        public void Update(Usuario usuario){
            ur.Update(usuario);
        }

        public string ExportToDelimited(int locadoraId){
            List<Usuario> list = RetrieveAll(locadoraId);
            string fileContent = string.Empty;
            foreach(var usr in list){
                fileContent += $"{usr.EscreverDadosDelimitados()}\n";
            }

            string fileName = $"DUMP_Usuarios_{DateTimeOffset.Now.ToFileTime()}.txt";
            if(ExportarDados.SalvarParaTexto(fileName, fileContent, lc.Retrieve(locadoraId).Nome))
                return "Exportação concluída com sucesso.";
            else
                return "Erro na exportação dos dados.";
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
                        if(!ur.ImportFromTxt(line, delimiter)){
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