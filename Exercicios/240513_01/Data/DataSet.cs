using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _240513_01.Models;

namespace _240513_01.Data
{
    public class DataSet
    {
        // Esta classe funciona como um "banco de dados" virtual.
        // Os repositórios dos modelos têm métodos que salvam e retornam os objetos contidos nas listas abaixo.
        public static List<Address> Addresses { get; set; } = new();
        public static List<Customer> Customers { get; set; } = new();
        public static List<Product> Products { get; set; } = new();
        public static List<Order> Orders { get; set; } = new();
        public static List<OrderItem> OrderItems { get; set; } = new();

    }
}