// Substituindo conteúdo de strings

string nomeCompleto = "João Vitor Danielewicz";
nomeCompleto = nomeCompleto.Replace("Vitor", "Paulo");

Console.WriteLine(nomeCompleto);

// Comparação de strings

bool isNomeEqual = (nomeCompleto == "João Vitor Danielewicz");
bool isNomeEqual2 = string.Equals(nomeCompleto, "João Paulo Danielewicz");

Console.WriteLine($"Primeiro resultado: {isNomeEqual}");
Console.WriteLine($"Segundo resultado: {isNomeEqual2}");