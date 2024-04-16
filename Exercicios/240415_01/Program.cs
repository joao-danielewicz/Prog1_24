using System.Data;
using System.Reflection.Metadata.Ecma335;
using _240415_01.Models;
using _240415_01.Repository;

CustomerRepository cr = new CustomerRepository();
Console.WriteLine("banana");

Customer customer1 = new(
    1,
    "Josy",
    "josy@josynha.com"
);
customer1.Addresses.Add(new(
    1, AddressType.Residential, "Rua Santa Catarina", "Cachoeira", "1001458", "Araucária", "PR", "Brasil", true
));


Customer customer2 = new Customer(2);
customer2.Name = "Josy";

cr.Save(customer1);
cr.Save(customer2);


Console.WriteLine(cr.Retrieve(1).Name);

Console.WriteLine("Os clientes cadastrados são: ");
foreach(var customer in cr.RetrieveAll()){
    Console.WriteLine(customer.Name);
}