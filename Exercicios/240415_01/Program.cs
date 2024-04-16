using _240415_01.Models;
using _240415_01.Repository;

CustomerRepository cr = new CustomerRepository();
Console.WriteLine("banana");

Customer customer1 = new Customer(1);
customer1.Name = "José";

Customer customer2 = new Customer(2);
customer2.Name = "Josy";

cr.Save(customer1);
cr.Save(customer2);

Console.WriteLine(cr.Retrieve(1));