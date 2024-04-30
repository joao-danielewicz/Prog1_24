using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using _240429_01.Models;
using _240429_01.Controllers;
using System.Runtime.InteropServices;

namespace _240429_01.Views
{
    public class CustomerView
    {
        int customerId = 1;
        private CustomerController customerController;
        private AddressView addressView;
        public CustomerView(){
            addressView = new();
            customerController = new();
            this.Init();
        }
        public void Init(){
            bool aux = true;
            do{
                Console.WriteLine("*************\n"+
                "MENU DO CONSUMIDOR\n"+
                "*************");

                Console.WriteLine("OPÇÕES - Escolha uma\n"+
                "1 - Cadastrar consumidor\n"+
                "2 - Pesquisar consumidor por ID\n"+
                "3 - Pesquisar consumidor por nome (min. de quatro caracteres)\n"+
                "4 - Listar todos os consumidores\n"+
                "0 - Sair");

                int opcao = 0;
                try{
                    opcao = Convert.ToInt32(Console.ReadLine());

                    switch(opcao){
                        case 1:
                            InsertCustomer();
                            break;
                        case 2:
                            Console.WriteLine("Informe o ID do consumidor a ser procurado:");
                            int idPesquisa = Convert.ToInt32(Console.ReadLine());
                            if(customerController.Get(idPesquisa)!=null){
                                Customer customer = customerController.Get(idPesquisa);
                                Console.WriteLine("Nome: {0}\nE-mail: {1}", customer.Name, customer.EmailAddress);
                            }
                            else
                                Console.WriteLine("Não há nenhum consumidor com este ID.");

                            Thread.Sleep(5000);
                            break;
                        case 3:
                            Console.WriteLine("Informe um termo de, no mínimo, quatro caracteres a ser usado na busca por nome: ");
                            string? termo = Console.ReadLine();
                            if(termo.Length<4){
                                Console.WriteLine("A busca deve ser efetuada com mais de 4 caracteres. Tente novamente.");
                                Thread.Sleep(2000);
                            }else{
                                Console.Clear();
                                Console.WriteLine("A busca resultou no seguinte resultado: ");
                                List<Customer> searchCustomer = customerController.Get(termo);
                                foreach(Customer consumidor in searchCustomer){
                                    Console.WriteLine("***************");
                                    Console.WriteLine("ID: "+consumidor.CustomerId);
                                    Console.WriteLine("Nome: "+consumidor.Name);
                                    Console.WriteLine("E-mail: "+consumidor.EmailAddress);
                                }
                                Console.ReadLine();
                            }
                            break;
                        case 4:
                            List<Customer> allCustomers = customerController.Get();
                            Console.Clear();
                            Console.WriteLine("***************\nLISTA DE CONSUMIDORES");
                            foreach(Customer consumidor in allCustomers){
                                Console.WriteLine("***************");
                                Console.WriteLine("ID: "+consumidor.CustomerId);
                                Console.WriteLine("Nome: "+consumidor.Name);
                                Console.WriteLine("E-mail: "+consumidor.EmailAddress);
                            }
                            Console.ReadLine();
                            break;
                        case 0:
                            aux = false;
                            break;
                        default:
                            aux = true;
                            break;
                    }
                } catch{
                    opcao = -1;
                }

            Console.Clear();
            }while(aux);
        }
        private void InsertCustomer(){
            Console.WriteLine("Informe o nome do consumidor:");
            string? nome = Console.ReadLine();

            Console.WriteLine("Informe o e-mail do consumidor:");
            string? email = Console.ReadLine();

            int aux = 0;
            do{
            Console.WriteLine("Deseja informar endereço?\n1 - Sim\n2 - Não");
            try{
                aux = Convert.ToInt32(Console.ReadLine());
                if(aux==1){
                    .Addresses.Add(addressView.Insert());
                }else if(aux==2){
                    break;
                }else{
                    aux = 1;
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
                    
            }catch{
                aux = 1;
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            }while(aux!=2);
            customerController.Insert(new(customerId, nome, email));
            customerId++;
        }
    }       
}