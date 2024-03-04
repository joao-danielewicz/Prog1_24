// Escreva um programa em C# que sirva como uma ficha cadastral, tente caprichar no layout, essa ficha cadastral deve coletar alguns dados do usuário:
// - Nome
// - E-mail
// - Data de nascimento
// - Sexo ou gênero
// - Endereço: CEP, Rua, Número, Bairro, Cidade, UF, País.
Console.Clear();

// Dados do endereço que se desejam solicitar
string[] componentesEndereco = {"Rua", "Número", "Bairro", "Cidade", "UF", "País", "CEP"};

// Escritura dos dados mais simples do usuário
Console.WriteLine("------------- FICHA CADASTRAL -------------");
Console.WriteLine("\n-------------- Dados básicos --------------");

Console.WriteLine("Informe seu nome.");
string nome = Console.ReadLine();

Console.WriteLine("Informe sua data de nascimento.");
string datanasc = Console.ReadLine();

Console.WriteLine("Informe seu gênero.");
string genero = Console.ReadLine();

Console.WriteLine("Informe seu e-mail.");
string email = Console.ReadLine();

Console.Clear();

// Recepção e estruturação das informações do endereço
Console.WriteLine("----------------- Endereço ----------------");
string endereco = "";
Console.WriteLine("Informe os detalhes de seu endereço.");
foreach(string ce in componentesEndereco){
    Console.Write(ce+": ");
    endereco += Console.ReadLine()+(ce == "CEP"? "." : ce == "Cidade"? " - ": ", ");
}
Console.Clear();

// Apresentação da ficha cadastral
Console.WriteLine("------------ Dados do Usuário ------------\n");
Console.WriteLine($"Nome: {nome}\nData de nascimento: {datanasc}\nGênero: {genero}\nE-mail: {email}\n\nEndereço: {endereco}");
Console.WriteLine("\n------------------------------------------");