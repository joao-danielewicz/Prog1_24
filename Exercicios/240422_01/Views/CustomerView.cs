using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using _240422_01.Models;
using _240422_01.Repository;

namespace _240422_01.Views
{
    public class CustomerView
    {
        public CustomerView(){
            this.Init();
        }
        public void Init(){
            bool aux = true;

            do{
                Console.WriteLine("*************\n"+
                "MENU DO CONSUMIDOR\n"+
                "*************\n");

                Console.WriteLine("OPÇÕES - Escolha uma\n"+
                "1 - Cadastrar consumidor\n"+
                "2 - Pesquisar consumidor por ID\n"+
                "3 - Listar todos os consumidores\n"+
                "0 - Sair");

                int opcao = 0;
                try{
                    opcao = Convert.ToInt32(Console.ReadLine());
                    CustomerRepository cr = new();
                    Customer customer = new();
                    int customerId = 1;

                    switch(opcao){
                        case 0:
                            aux = false;
                            break;
                        case 1:
                            Console.WriteLine("Informe o nome do consumidor:");
                            string? nome = Console.ReadLine();
                            Console.WriteLine("Informe o e-mail do consumidor:");
                            string? email = Console.ReadLine();
                            cr.Save(new(customerId, nome, email));
                            customerId++;
                            break;
                        case 2:
                            Console.WriteLine("Informe o ID do consumidor a ser procurado:");
                            int idPesquisa = Convert.ToInt32(Console.ReadLine());
                            customer = cr.Retrieve(idPesquisa);
                            Console.WriteLine("Nome: {0}\nE-mail: {1}", customer.Name, customer.EmailAddress);
                            Thread.Sleep(5000);
                            break;
                        case 3:
                        default:
                            Console.WriteLine("Opção inválida.");
                            aux = true;
                            break;
                    }
                } catch(Exception e){
                    opcao = -1;
                    Console.WriteLine("Opção inválida.");
                }

            Console.Clear();
            }while(aux);
        }
    }
}