using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _240429_01.Controllers;
using _240429_01.Models;
namespace _240429_01.Views
{
    public class AddressView
    {
        private AddressController addressController;

        public AddressView(){
            addressController = new AddressController();
            this.Init();
        }

        public void Init(){
            
        }

        public Address Insert(){
            Address address = new();
            Console.WriteLine("******************");
            Console.WriteLine("INSERINDO ENDEREÇO");
            Console.WriteLine("******************");

            Console.WriteLine("Qual o tipo do endereço?\n"+
            "1 - Residencial\n"+
            "2 - Comercial\n"+
            "3 - Outros");

            int tpEndereco = Convert.ToInt32(Console.ReadLine());

            switch(tpEndereco){
                case 1:
                    address.Type = AddressType.Residential;
                break;
                case 2:
                    address.Type = AddressType.Commercial;
                break;
                default:
                    address.Type = AddressType.Other;
                break;
            }

            Console.WriteLine("Rua: ");
            address.Street = Console.ReadLine();

            Console.WriteLine("Bairro: ");
            address.District = Console.ReadLine();

            Console.WriteLine("CEP: ");
            address.ZipCode = Console.ReadLine();

            Console.WriteLine("Cidade: ");
            address.City = Console.ReadLine();

            Console.WriteLine("Estado: ");
            address.FederalState = Console.ReadLine();

            Console.WriteLine("Country: ");
            address.Country = Console.ReadLine();

            Console.WriteLine("Este é o endereço padrão?\n"+
            "1 - Sim\n"+
            "2 - Não");
            int isDefault = Convert.ToInt32(Console.ReadLine());
            address.IsDefault = (isDefault == 1? true : false);

            addressController.Insert(address);

            return address;
        }
    }
}