using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using _240603_01.Controllers;
using _240603_01.Models;

namespace _240603_01.Views
{
    public class ProductView{
        public ProductView(){
            this.Init();
        }
        public void Init(){
            bool aux = true;
            int productId = 1;

            do{
                Console.WriteLine("*************\n"+
                "MENU DO PRODUTO\n"+
                "*************\n");

                Console.WriteLine("OPÇÕES - Escolha uma\n"+
                "1 - Cadastrar produto\n"+
                "2 - Pesquisar produto por ID\n"+
                "3 - Listar todos os produtos\n"+
                "0 - Sair");

                int opcao = 0;
                try{
                    opcao = Convert.ToInt32(Console.ReadLine());
                    ProductController pc = new();

                    switch(opcao){
                        case 0:
                            aux = false;
                            break;
                        case 1:
                            Console.WriteLine("Informe o nome do produto:");
                            string? nome = Console.ReadLine();
                            Console.WriteLine("Informe a descrição do produto:");
                            string? descricao = Console.ReadLine();
                            Console.WriteLine("Informe o preço do produto:");
                            float preco = Convert.ToSingle(Console.ReadLine());
                            pc.Insert(new(productId, nome, descricao, preco));
                            productId++;
                            break;
                        case 2:
                            Console.WriteLine("Informe o ID do produto a ser procurado:");
                            int idPesquisa = Convert.ToInt32(Console.ReadLine());
                            if(pc.Get(idPesquisa)!=null){
                                Product product = pc.Get(idPesquisa);
                                Console.WriteLine("Nome: {0}\nDescrição: {1}\nPreço: {2:C}", product.ProductName, product.Description, product.CurrentPrice);
                            }
                            else
                                Console.WriteLine("Não há nenhum consumidor com este ID.");

                            Thread.Sleep(5000);
                            break;
                        case 3:
                            List<Product> allProducts = pc.Get();
                            Console.Clear();
                            Console.WriteLine("***************\nLISTA DE PRODUTOS");
                            foreach(Product produto in allProducts){
                                Console.WriteLine("***************");
                                Console.WriteLine("ID: "+produto.ProductId);
                                Console.WriteLine("Nome: "+produto.ProductName);
                                Console.WriteLine("Descrição: "+produto.Description);
                                Console.WriteLine("Preço: {0:C}", produto.CurrentPrice);
                            }
                            Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                } catch{
                    opcao = -1;
                }

            Console.Clear();
            }while(aux);
        }
    }
}