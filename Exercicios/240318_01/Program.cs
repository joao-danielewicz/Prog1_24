using _240318_01.Models;

Customer c1 = new Customer();

c1.CustomerId = 1;
c1.FirstName = "João";
c1.LastName = "Danielewicz";
c1.BirthDate = new DateTime();
c1.EmailAddress = "joao.wicz@gmail.com";

Address address1 = new Address();
address1.AddressId = 1;
address1.Street = "José Ferreira da Silva";
address1.Neighbourhood = "Jardim Canadá";
address1.Number = 89;
address1.City = "Videira";
address1.FederalState = "Santa Catarina";
address1.Country = "Brasil";
address1.ZipCode = "89564-072";

c1.Addresses.Add(address1);

Console.WriteLine($"Nome: {c1.FirstName} {c1.LastName}");
Console.WriteLine($"E-mail: {c1.EmailAddress}");

Console.WriteLine("Endereços:\n-----------");
foreach(var ad in c1.Addresses){
    Console.WriteLine($"Rua: {ad.Street}");
    Console.WriteLine($"Bairro: {ad.Neighbourhood}");
    Console.WriteLine($"Número: {ad.Number}");
    Console.WriteLine($"Cidade: {ad.City}");
    Console.WriteLine($"Estado: {ad.FederalState}");
    Console.WriteLine($"País: {ad.Country}");
    Console.WriteLine($"CEP: {ad.ZipCode}");
}


