using System.Data;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using _240429_01.Models;
using _240429_01.Repository;
using _240429_01.Views;


bool aux = true;

do{
    Console.WriteLine("*************\n"+
    "Cadastro de Pedidos!!!\n"+
    "*************");

    Console.WriteLine("Opções - Escolha uma:\n"+
    "1 - Consumidor\n"+
    "2 - Produtos\n"+
    "3 - Pedidos\n"+
    "0 - Sair");
    int opcao = -1;
    try{
        opcao = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch(opcao){
            case 1:
                CustomerView cv = new CustomerView();
                break;
            case 2:
                ProductView pv = new ProductView();
                break;
            case 3:
                OrderView ov = new OrderView();
                break;

            case 0:
                aux = false;
                Console.WriteLine("Até mais.");
                Thread.Sleep(2000);
                break;
            default:
                break;
        }
    }catch{
        opcao = -1;
    }
    Console.Clear();
}while(aux);