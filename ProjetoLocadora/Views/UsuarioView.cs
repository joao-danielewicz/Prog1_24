using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoLocadora.Controllers;
using ProjetoLocadora.Models;
using ProjetoLocadora.Utils;

namespace ProjetoLocadora.Views
{
    public class UsuarioView{

        // --------------------------------- ATRIBUTOS -------------------------------

        private UsuarioController usuarioController;
        private int LocadoraId;
        private Texto txt;
        private string tituloMenu = "****** Menu dos Usuários ******";

        // ------------------------- CONSTRUTORES E INICIALIZADOR ---------------------

        public UsuarioView(int locadoraId){
            usuarioController = new();
            txt = new();
            LocadoraId = locadoraId;
            Init();
        }
        public void Init(){
            bool aux = true;
            string[] menu = {
                "1 - Menu dos usuários...",
                "2 - Menu dos dados...",
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

        private Usuario FormularioUsuario(bool generateId = true, int id=0){
            bool aux = true;
            Usuario usuario = new Usuario();
            if(!generateId)
                usuario.UsuarioId = id;
            do{
                try{
                    WriteLine("Informe o nome do usuário.");
                    usuario.Nome = ReadLine();          
                    usuario.LocadoraId= LocadoraId;         
                    aux = false;
                }catch{
                    Clear();
                    WriteLine("Houve um erro. Cadastre novamente.");
                }
            }while(aux==true);
            return usuario;
        }
        private void InserirUsuario(){
            Usuario usuario = FormularioUsuario();
            usuarioController.Insert(usuario);
        }
        private void AlterarUsuario(){
            bool aux = true;
            int id=0;
            Usuario usuario = new();
            do{
                try{
                    WriteLine("Informe o ID do usuário a ser alterado.");
                    id = Convert.ToInt32(ReadLine());
                    usuario = FormularioUsuario(false, id);
                    break;
                }catch{
                    WriteLine("Erro. Tente novamente.");
                }
            }while(aux==true);
            usuarioController.Update(usuario);
        }
        private void RemoverUsuario(){
            bool aux = true;
            WriteLine("Insira o ID do usuário a ser removido.\n Esta ação não pode ser desfeita.");
            do{
                try{
                    int id = Convert.ToInt32(ReadLine());
                    if(usuarioController.Remove(id))
                        WriteLine("usuário removido com sucesso.");
                    else
                        WriteLine("Nenhum usuário com este ID foi encontrado.");
                    aux=false;
                }catch{

                }
            }while(aux==true);
        }     
        
        // --------------------------------- LISTAGENS --------------------------------

        private void ListarPorId(){
            bool aux = true;
            do{
                WriteLine("Informe o ID do usuário a ser pesquisado.");
                try{
                    int id = Convert.ToInt32(ReadLine());
                    Usuario usuario = usuarioController.Retrieve(id, LocadoraId);
                    if(usuario!=null){
                        WriteLine(string.Format(Usuario.Formato, "ID", "Nome", "ID da Locadora"));
                        EscreverDados(usuario);
                    }
                    else
                        WriteLine("Não há nenhum usuário com este ID.");
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
            List<Usuario> usuarios = usuarioController.Retrieve(termoBusca, LocadoraId);
            if(usuarios.Count==0 || usuarios == null){
                WriteLine("Nenhum usuário encontrado.");
            }else{
                WriteLine(string.Format(Usuario.Formato, "ID", "Nome", "ID da Locadora"));
                foreach(Usuario usuario in usuarios){
                    EscreverDados(usuario);
                }
            }
            ReadLine();
        }
        private void ListarTodos(){
            List<Usuario> list = usuarioController.RetrieveAll(LocadoraId);
            if(list.Count!=0){
                WriteLine(string.Format(Usuario.Formato, "ID", "Nome", "ID da Locadora"));
                foreach (var i in list){
                    EscreverDados(i);
                }
            }else
                WriteLine("Não há nenhum usuário para ser exibido.");
            WriteLine("Pressione enter para continuar...");
            ReadLine();
        }
        
        // --------------------------------- MENUS ------------------------------------
        
        private void MenuPesquisa(){
            bool aux = true;
            string[] menuListagem = {"1 - Mostrar todos",
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
                            InserirUsuario();
                            break;
                        case 2:
                            AlterarUsuario();
                            break;
                        case 3:
                            RemoverUsuario();
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
            usuarioController.ExportToDelimited(LocadoraId);
        }
        private void ImportarDadosDoArquivo(){
            WriteLine("Informe o caminho do arquivo.");
            string caminho = ReadLine();
            WriteLine("Informe o delimitador dos dados.");
            string delimitador = ReadLine();
            WriteLine(usuarioController.ImportFromDelimited(caminho, delimitador));
            WriteLine("Pressione Enter para continuar...");
            ReadLine();
        }
        
        // ------------------------- OUTRAS FUNÇÕES -------------------------------------
        
        private void EscreverDados(Usuario usuario){
            WriteLine(usuario.ToString());
        }
    }
}