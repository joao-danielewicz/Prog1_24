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
        private UsuarioController usuarioController;
        private int LocadoraId;
        private Texto txt;
        private string tituloMenu = "****** Menu dos Usuários ******";
        public UsuarioView(int locadoraId){
            usuarioController = new();
            txt = new();
            LocadoraId = locadoraId;
            Init();
        }
        public void Init(){
            bool aux = true;
            string[] menu = {
                "1 - Cadastrar",
                "2 - Alterar",
                "3 - Remover",
                "4 - Pesquisar...",
                "0 - Sair"};

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
            Thread.Sleep(1000);
            }while(aux);
        }   

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
        
        private void ListarPorId(){
            bool aux = true;
            do{
                WriteLine("Informe o ID do usuário a ser pesquisado.");
                try{
                    int id = Convert.ToInt32(ReadLine());
                    Usuario usuario = usuarioController.Retrieve(id, LocadoraId);
                    if(usuario!=null){
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
                foreach(Usuario usuario in usuarios){
                    EscreverDados(usuario);
                }
            }
            ReadLine();
        }
        private void ListarTodos(){
            List<Usuario> list = usuarioController.RetrieveAll(LocadoraId);
            if(list.Count!=0){
                foreach (var i in list){
                    EscreverDados(i);
                }
            }else
                WriteLine("Não há nenhum usuário para ser exibido.");
            WriteLine("Pressione enter para continuar...");
            ReadLine();
        }
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
    
        private void EscreverDados(Usuario usuario){
            WriteLine(usuario.ToString());
        }
    }
}