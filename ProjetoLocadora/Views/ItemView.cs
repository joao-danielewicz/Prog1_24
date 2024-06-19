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
        private ItemController itemController;
        private Texto txt;
        private string tituloMenu = "****** Menu dos Itens da Locadora ******";
        public ItemView(){
            itemController = new();
            txt = new();
            this.Init();
        }
        public void Init(){
            bool aux = true;
            string[] menu = {
                "1 - Cadastrar",
                "2 - Alterar",
                "3 - Remover",
                "4 - Mostrar todos",
                "5 - Pesquisar por ID",
                "0 - Sair"
            };

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
                            MostrarTodos();
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
    
        private void InserirItem(){
            int aux = 0;
            do{
                try{
                    Item item = new Item();
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

                    aux = 0;
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
                            aux = 1;
                        }catch{
                            WriteLine("Erro. Tente novamente.");
                            aux = 0;
                        }
                    }while(aux==0);

                    WriteLine("Quantas unidades deste item estarão disponíveis?");
                    item.QtdTotal = Convert.ToInt32(ReadLine());

                    itemController.Insert(item);
                    aux = 1;
                }catch{
                    Clear();
                    WriteLine("Houve um erro. Cadastre novamente.");
                }
            }while(aux==0);
        }
    
        void MostrarTodos(){
            List<Item> list = itemController.RetrieveAll();
            foreach (var i in list)
            {
                Console.WriteLine(i.ToString());
            }
        }
    }
}