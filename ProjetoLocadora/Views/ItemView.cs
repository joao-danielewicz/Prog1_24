using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Controllers;
using ProjetoLocadora.Models;
using ProjetoLocadora.Utils;

namespace ProjetoLocadora.Views
{
    public class ItemView{

        // --------------------------------- ATRIBUTOS -------------------------------

        private ItemController itemController;
        private int LocadoraId;
        private Texto txt;
        private string tituloMenu = "****** Menu dos Itens da Locadora ******";

        // ------------------------- CONSTRUTORES E INICIALIZADOR ---------------------

        public ItemView(int locadoraId){
            itemController = new();
            txt = new();
            LocadoraId = locadoraId;
            Init();
        }
        public void Init(){
            bool aux = true;
            string[] menu = {
                "1 - Menu dos itens...",
                "2 - Dados...",
                "3 - Emprestar",
                "4 - Devolver",
                "0 - Voltar"};

            do{
                try{
                    Clear();
                    txt.WriteMenu(tituloMenu, menu);
                    int opcao = Convert.ToInt32(ReadLine());

                    switch(opcao){
                        case 1:
                            MenuCrud();
                            break;
                        case 2:
                            MenuDados();
                            break;
                        case 3:
                            EmprestarItem();
                            break;
                        case 4:
                            DevolverItem();
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

        private Item FormularioItem(bool generateId = true, int id=0){
            bool aux = true;
            Item item = new Item();
            if(!generateId)
                item.ItemId = id;
            do{
                try{
                    WriteLine("Informe o título da obra.");
                    item.Titulo = ReadLine();
                    WriteLine("Informe seu diretor.");
                    item.Diretor = ReadLine();
                    WriteLine("Informe o gênero.");
                    item.Genero = ReadLine();
                    WriteLine("Informe o título da obra.");
                    WriteLine("Escolha uma opção para informar em qual dos tipos a mídia se encaixa.\n"+
                    "1 - Filme\n"+
                    "2 - Série\n"+
                    "3 - Documentário\n"+
                    "4 - Novela");
                    int tipoMidia = Convert.ToInt32(ReadLine());
                    if(tipoMidia>4){
                        throw new Exception("");
                    }
                    item.Tipo = (TiposMidia)tipoMidia;

                    WriteLine("Qual o estúdio responsável pela gravação?");
                    item.Estudio = ReadLine();
                    aux = true;
                    do{
                        try{
                            WriteLine("Informe a data de lançamento.");
                            Write("Ano: ");
                            int ano = Convert.ToInt32(ReadLine());
                            Write("Mês: ");
                            int mes = Convert.ToInt32(ReadLine());
                            Write("Dia: ");
                            int dia = Convert.ToInt32(ReadLine());
                            item.Lancamento = new DateTime(ano, mes, dia);
                            aux = false;
                        }catch{
                            WriteLine("Erro. Tente novamente.");
                            aux = true;
                        }
                    }while(aux==true);

                    item.LocadoraId= LocadoraId;
                    aux = false;
                }catch{
                    Clear();
                    WriteLine("Houve um erro. Cadastre novamente.");
                }
            }while(aux==true);
            return item;
        }
        private void InserirItem(){
            Item item = FormularioItem();
            itemController.Insert(item);
        }
        private void AlterarItem(){
            bool aux = true;
            int id=0;
            Item item = new();
            do{
                try{
                    WriteLine("Informe o ID do item a ser alterado.");
                    id = Convert.ToInt32(ReadLine());
                    item = FormularioItem(false, id);
                    break;
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
            }while(aux==true);
            itemController.Update(item);
        }
        private void RemoverItem(){
            bool aux = true;
            WriteLine("Insira o ID do item a ser removido.\n Esta ação não pode ser desfeita.");
            do{
                try{
                    int id = Convert.ToInt32(ReadLine());
                    if(itemController.Remove(id))
                        WriteLine("Item removido com sucesso.");
                    else
                        WriteLine("Nenhum item com este ID foi encontrado.");
                    aux=false;
                }catch{

                }
            }while(aux==true);
        }            
        
        // --------------------------------- LISTAGENS --------------------------------
        
        private void ListarPorId(){
            bool aux = true;
            do{
                WriteLine("Informe o ID do item a ser pesquisado.");
                try{
                    int id = Convert.ToInt32(ReadLine());
                    Item item = itemController.Retrieve(id, LocadoraId);
                    if(item!=null){
                        WriteLine(string.Format(Item.Formato, "ID", "Título", "Diretor(a)", "Gênero", "Tipo da obra",
                        "Estúdio", "Data de lançamento", "Alteração em","Emprestado para"));
                        EscreverDados(item);
                    }
                    else
                        WriteLine("Não há nenhum item com este ID.");
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
                aux = false;
            }while(aux == true);
            ReadLine();
        }
        private void ListarPorTitulo(){
            WriteLine("Informe o termo de busca a ser utilizado.");
            string? termoBusca = ReadLine();
            List<Item> itens = itemController.Retrieve(termoBusca, LocadoraId);
            if(itens.Count==0 || itens == null){
                WriteLine("Nenhum item encontrado.");
            }else{
                WriteLine(string.Format(Item.Formato, "ID", "Título", "Diretor(a)", "Gênero", "Tipo da obra",
                "Estúdio", "Data de lançamento", "Alteração em","Emprestado para"));
                foreach(Item item in itens){
                    EscreverDados(item);
                }
            }
            ReadLine();
        }
        private void ListarTodos(){
            List<Item> list = itemController.RetrieveAll(LocadoraId);
            if(list.Count!=0){
                WriteLine(string.Format(Item.Formato, "ID", "Título", "Diretor(a)", "Gênero", "Tipo da obra",
                "Estúdio", "Data de lançamento", "Alteração em","Emprestado para"));
                foreach (var i in list){
                    EscreverDados(i);
                }
            }else
                WriteLine("Não há nenhum item para ser exibido.");
            WriteLine("Pressione enter para continuar...");
            ReadLine();
        }
        
        // --------------------------------- MENUS ------------------------------------
        
        private void MenuPesquisa(){
            bool aux = true;
            string[] menuListagem = {"1 - Mostrar todos",
                "2 - Pesquisar por ID",
                "3 - Pesquisar por título",
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
                            ListarPorTitulo();
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
            ReadLine();
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
                            InserirItem();
                            break;
                        case 2:
                            AlterarItem();
                            break;
                        case 3:
                            RemoverItem();
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
            itemController.ExportToDelimited(LocadoraId);
        }
        private void ImportarDadosDoArquivo(){
            WriteLine("Informe o caminho do arquivo.");
            string caminho = ReadLine();
            WriteLine("Informe o delimitador dos dados.");
            string delimitador = ReadLine();
            WriteLine(itemController.ImportFromDelimited(caminho, delimitador));
            WriteLine("Pressione Enter para continuar...");
            ReadLine();
        }
        
        // ------------------------- OUTRAS FUNÇÕES -------------------------------------
        
        private void EscreverDados(Item item){
            WriteLine(item.ToString());
        }
        public void EmprestarItem(){
            bool aux = true;
            do{
                try{
                    WriteLine("Informe o ID do item a ser emprestado.");
                    int itemId = Convert.ToInt32(ReadLine());
                    WriteLine("Informe o ID do usuário que deseja emprestar o item.");
                    int usuarioId = Convert.ToInt32(ReadLine());
                    if(itemId==0)
                        throw new Exception("");
                    else{
                        WriteLine(itemController.Emprestar(itemController.Retrieve(itemId, LocadoraId), usuarioId));
                        ReadLine();
                        aux = false;
                    }
                }catch{
                    Clear();
                    WriteLine("Houve um erro. Tente novamente.");
                    break;
                }
            }while(aux==true);
        }
        public void DevolverItem(){
            bool aux = true;
            do{
                try{
                    WriteLine("Informe o ID do item a ser devolvido.");
                    int itemId = Convert.ToInt32(ReadLine());
                    if(itemId==0)
                        throw new Exception("");
                    else{
                        WriteLine(itemController.Devolver(itemController.Retrieve(itemId, LocadoraId)));
                        aux = false;
                    }
                }catch{
                    Clear();
                    WriteLine("Houve um erro. Tente novamente.");
                    break;
                }
            }while(aux==true);
            ReadLine();

        }
    }
}