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
        private string titulo = "****** Menu dos Itens da Locadora ******";
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
            };

            do{
                try{
                    Clear();
                    txt.WriteMenu(titulo, menu);
                    int opcao = Convert.ToInt32(ReadLine());

                    switch(opcao){
                        case 1:
                            WriteLine("banana");
                            ReadLine();
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
            WriteLine("Informe o título da obra.");
            string titulo = ReadLine();
            string autor = ReadLine();
            string genero = ReadLine();
            int tipoMidia = Convert.ToInt32(ReadLine());
            string estudio = ReadLine();
            DateTime lancamento = Convert.ToDateTime(ReadLine());
            int qtdTotal = Convert.ToInt32(ReadLine());
        }
    
    
    }
}