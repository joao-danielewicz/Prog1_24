using _240401_01.Models;
Console.WriteLine("Hello, World!");

Customer c1 = new Customer();
c1.CustomerId = 1;
c1.Name = "Bocó";
c1.EmailAddress = "boco@ananda.com";
c1.WorkAddress = "Embaixo do Jeep Compass";
c1.HomeAddress = "Magitus";

Customer c2 = new Customer(2);
c2.Name = "Samila";
c2.EmailAddress = "samila@papelariaceysa.com";
c2.WorkAddress = "Secretaria de Sobrancelhas";
c2.HomeAddress = "Casa da Neli";

Customer c3 = new Customer(){
    CustomerId = 3,
    Name = "Boi",
    EmailAddress = "boi@dolfoenterprises.com",
    WorkAddress = "Escola Santos Anjos",
    HomeAddress = "Sítio do Dolfo"
};