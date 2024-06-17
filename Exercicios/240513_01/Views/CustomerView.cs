using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using _240513_01.Models;
using _240513_01.Controllers;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace _240513_01.Views
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
                "2 - Pesquisar consumidor\n"+
                "3 - Listar todos os consumidores\n"+
                "0 - Sair");

                int opcao = 0;
                try{
                    opcao = Convert.ToInt32(Console.ReadLine());

                    switch(opcao){
                        case 1:
                            InsertCustomer();
                            break;
                        case 2:
                            SearchCustomer();
                            break;
                        case 3:
                            ListCustomers();
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
            Customer customer = new Customer();
            Console.WriteLine("Informe o nome do consumidor:");
            customer.Name = Console.ReadLine();

            Console.WriteLine("Informe o e-mail do consumidor:");
            customer.EmailAddress = Console.ReadLine();

            int aux = 0;
            do{
            Console.WriteLine("Deseja informar endereço?\n1 - Sim\n2 - Não");
            try{
                aux = Convert.ToInt32(Console.ReadLine());
                if(aux==1){
                    customer.Addresses.Add(addressView.Insert());
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
            customerController.Insert(customer);
            customerId++;
        }
        private void SearchCustomer(){
            Console.Clear();
            int aux = -1;

            do{
                Console.WriteLine("1 - Pesquisar por ID\n2 - Pesquisar por nome\n0 - Sair");
                aux = Convert.ToInt32(Console.ReadLine());
                switch(aux){
                    case 1:
                        Console.WriteLine("Informe o ID:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ShowCustomerById(id);
                        break;
                    case 2:
                        Console.WriteLine("Informe o termo de busca (min. 4 caracteres)");
                        String name = Console.ReadLine();
                        ShowCustomerByName(name);
                        break;
                    case 0:
                        break;
                    default:
                        aux = -1;
                        break;
                }
            }while(aux!=0);
        }
        private void ShowCustomerById(int id){
            Console.Clear();
            Customer c = customerController.Get(id);
            if(c!=null){
                PrintCustomerData(c);
                Console.ReadLine();
            }else{
                Console.WriteLine("Não há nenhum consumidor o ID "+id);
            }
        }
        private void ListCustomers(){
            Console.Clear();
            List<Customer> result = customerController.Get();
            if(result == null || result.Count == 0){
                Console.WriteLine("Nenhum cliente encontrado.");
                Console.ReadLine();
            }else{
                Console.WriteLine("***************\nLISTA DE CONSUMIDORES");                
                foreach(Customer c in result){
                    PrintCustomerData(c);
                }
                    Console.ReadLine();
            }
        }
        private void ShowCustomerByName(string name){
            Console.Clear();
            List<Customer> result = customerController.Get(name);
            if(result == null || result.Count == 0){
                Console.WriteLine("Nenhum cliente encontrado.");
                Console.ReadLine();
            }else{
                Console.WriteLine("***************\nLISTA DE CONSUMIDORES");                
                foreach(Customer c in result){
                    PrintCustomerData(c);
                }
                    Console.ReadLine();
            }
        }
        private void PrintCustomerData(Customer customer){
            Console.WriteLine("***************");
            Console.WriteLine("ID: "+customer.CustomerId);
            Console.WriteLine("Nome: "+customer.Name);
            Console.WriteLine("E-mail: "+customer.EmailAddress);
        }

    }       
}