using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Controllers;
using ProjetoLocadora.Models;
using ProjetoLocadora.Utils;

namespace ProjetoLocadora.Views
{
    public class LocadoraView{

        // --------------------------------- ATRIBUTOS -------------------------------

        private LocadoraController locadoraController;
        private int LocadoraId;
        private UsuarioView uv;
        private ItemView iv;
        private Texto txt = new();
        private string tituloMenu = "****** Menu da Locadora ******";

        // ------------------------- CONSTRUTORES E INICIALIZADOR ---------------------
        public LocadoraView(){
            locadoraController = new();
            InserirLocadora();
        }
        public LocadoraView(bool firstExec){
            locadoraController = new();
            WriteLine(locadoraController.ImportFromDelimited("", "", true));
            ReadLine();
        }
        public LocadoraView(int locadoraId){
            LocadoraId = locadoraId;
            locadoraController = new();
            txt = new();
            Init(LocadoraId);
        }
        public void Init(int locadoraId){
            bool aux = true;
            string[] menu = {
                "1 - Itens...",
                "2 - Usuários...",
                "3 - Menu das locadoras...",
                "4 - Dados...",
                "5 - Verificar empréstimos",
                "0 - Voltar"};

            do{
                try{
                    Clear();
                    txt.WriteMenu(tituloMenu, menu);
                    int opcao = Convert.ToInt32(ReadLine());

                    switch(opcao){
                        case 1:
                            iv = new(locadoraId);
                            break;
                        case 2:
                            uv = new(locadoraId);
                            break;
                        case 3:
                            MenuCrud();
                            break;
                        case 4:
                            MenuDados();
                            break;
                        case 5:
                            VerificarEmprestimos();
                            break;
                        case 0:
                            aux = false;
                            break;
                        default:
                            WriteLine("Opção inválida. Tente novamente.\n");
                            aux = true;
                            break;
                    }
                }catch{
                    WriteLine("Erro. Tente novamente.\n");
                }
            }while(aux);
        }
        
        // --------------------------------- CRUD -------------------------------------
          
        private Locadora FormularioLocadora(bool generateId = true, int id=0){
            bool aux = true;
            Locadora loc = new Locadora();
            if(!generateId)
                loc.LocadoraId = id;
            do{
                try{
                    WriteLine("Informe o nome da locadora.");
                    loc.Nome = ReadLine();
                    WriteLine("Informe sua localização.");
                    loc.Localizacao = ReadLine();
                    aux = false;
                }catch{
                    Clear();
                    WriteLine("Houve um erro. Cadastre novamente.");
                }
            }while(aux==true);
            return loc;
        }
        private void InserirLocadora(){
            Locadora loc = FormularioLocadora();
            locadoraController.Insert(loc);
        }
        private void AlterarLocadora(){
            bool aux = true;
            int id=0;
            Locadora loc = new();
            do{
                try{
                    WriteLine("Informe o ID da locadora a ser alterada.");
                    id = Convert.ToInt32(ReadLine());
                    loc = FormularioLocadora(false, id);
                    break;
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
            }while(aux==true);
            locadoraController.Update(loc);
        }
        private void RemoverLocadora(){
            bool aux = true;
            WriteLine("Insira o ID da locadora a ser removida.\n Esta ação não pode ser desfeita.");
            do{
                try{
                    int id = Convert.ToInt32(ReadLine());
                    if(locadoraController.Remove(id))
                        WriteLine("Locadora removida com sucesso.");
                    else
                        WriteLine("Nenhuma locadora com este ID foi encontrada.");
                    aux=false;
                }catch{

                }
            }while(aux==true);
        }     
        
        // --------------------------------- LISTAGENS --------------------------------

        private void ListarPorId(){
            bool aux = true;
            do{
                WriteLine("Informe o ID da locadora a ser pesquisada.");
                try{
                    int id = Convert.ToInt32(ReadLine());
                    Locadora loc = locadoraController.Retrieve(id);
                    if(loc!=null){
                        WriteLine(string.Format(Locadora.Formato, "ID", "Nome", "Localização"));
                        EscreverDados(loc);
                    }
                    else
                        WriteLine("Não há nenhuma locadora com este ID.");
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
                aux = false;
            }while(aux == true);
            ReadLine();
        }
        private void ListarPorNome(){
            WriteLine("Informe o termo de busca a ser utilizado.");
            string? termoBusca = ReadLine();
            List<Locadora> locs = locadoraController.Retrieve(termoBusca);
            if(locs.Count==0 || locs == null){
                WriteLine("Nenhuma locadora encontrada.");
            }else{
                WriteLine(string.Format(Locadora.Formato, "ID", "Nome", "Localização"));
                foreach(Locadora loc in locs){
                    EscreverDados(loc);
                }
            }
            ReadLine();
        }
        private void ListarTodos(){
            List<Locadora> list = locadoraController.RetrieveAll();
            if(list.Count!=0){
                WriteLine(string.Format(Locadora.Formato, "ID", "Nome", "Localização"));
                foreach (var i in list){
                    EscreverDados(i);
                }
            }else
                WriteLine("Não há nenhuma locadora para ser exibida.");
            WriteLine("Pressione enter para continuar...");
            ReadLine();
        }
        
        // --------------------------------- MENUS ------------------------------------
        
        private void MenuPesquisa(){
            bool aux = true;
            string[] menuListagem = {"1 - Mostrar todas",
                "2 - Pesquisar por ID",
                "3 - Pesquisar por nome",
                "0 - Voltar"};

            do{
                Clear();
                txt.WriteMenu(tituloMenu, menuListagem);
                try{
                    int opcao = Convert.ToInt32(ReadLine());
                    switch(opcao){
                        case 1:
                            ListarTodos();
                            break;
                        case 2:
                            ListarPorId();
                            break;
                        case 3:
                            ListarPorNome();
                            break;
                        case 0:
                            aux = false;
                            break;
                        default:
                            WriteLine("Opção inválida. Tente novamente.");
                            aux = true;
                            break;
                    }
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
            }while(aux);
        }
        private void MenuDados(){
            bool aux = true;
            string[] menuListagem = {"1 - Exportar para .txt",
                "2 - Importar .txt",
                "0 - Voltar"};

            do{
                Clear();
                txt.WriteMenu(tituloMenu, menuListagem);
                try{
                    int opcao = Convert.ToInt32(ReadLine());
                    switch(opcao){
                        case 1:
                            ExportarDadosParaArquivo();
                            break;
                        case 2:
                            ImportarDadosDoArquivo();
                            break;
                        case 0:
                            aux = false;
                            break;
                        default:
                            WriteLine("Opção inválida. Tente novamente.");
                            aux = true;
                            break;
                    }
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
            }while(aux);
        }
        public void MenuCrud(){
            bool aux = true;
            string[] menu = {
                "1 - Cadastrar",
                "2 - Alterar",
                "3 - Remover",
                "4 - Pesquisar...",
                "0 - Voltar"};

            do{
                try{
                    Clear();
                    txt.WriteMenu(tituloMenu, menu);
                    int opcao = Convert.ToInt32(ReadLine());

                    switch(opcao){
                        case 1:
                            InserirLocadora();
                            break;
                        case 2:
                            AlterarLocadora();
                            break;
                        case 3:
                            RemoverLocadora();
                            break;
                        case 4:
                            MenuPesquisa();
                            break;
                        case 0:
                            aux = false;
                            break;
                        default:
                            WriteLine("Opção inválida. Tente novamente.\n");
                            aux = true;
                            break;
                    }
                }catch{
                    WriteLine("Erro. Tente novamente.\n");
                }
            }while(aux);
        } 
        
        // --------------------------------- ARQUIVOS ----------------------------------

        public void ExportarDadosParaArquivo(){
            locadoraController.ExportToDelimited();
        }
        private void ImportarDadosDoArquivo(){
            WriteLine("Informe o caminho do arquivo.");
            string caminho = ReadLine();
            WriteLine("Informe o delimitador dos dados.");
            string delimitador = ReadLine();
            WriteLine(locadoraController.ImportFromDelimited(caminho, delimitador));
            WriteLine("Pressione Enter para continuar...");
            ReadLine();
        }
    
        // ------------------------- OUTRAS FUNÇÕES -------------------------------------
        
        private void EscreverDados(Locadora loc){
            WriteLine(loc.ToString());
        }
        public void VerificarEmprestimos(){
            List<Item> emprestados = locadoraController.VerificarEmprestimos(LocadoraId);
            if(emprestados.Count==0){
                WriteLine("Não há nenhum empréstimo pendente.");
            }else{
                WriteLine(string.Format("{0, -30} {1}", "Título", "ID do Usuário", "banana"));
                foreach(Item item in emprestados){
                    WriteLine(string.Format("{0, -30} {1}", item.Titulo, item.UsuarioId));
                }
            }
            WriteLine("Pressione Enter para continuar...");
            ReadLine();
        }
    }
}