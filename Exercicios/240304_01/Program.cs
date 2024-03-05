// Substituindo conteúdo de strings

string nomeCompleto = "João Vitor Danielewicz";
nomeCompleto = nomeCompleto.Replace("Vitor", "Paulo");

Console.WriteLine(nomeCompleto);

// Comparação de strings

bool isNomeEqual = (nomeCompleto == "João Vitor Danielewicz");
bool isNomeEqual2 = string.Equals(nomeCompleto, "João Paulo Danielewicz");

Console.WriteLine($"Primeiro resultado: {isNomeEqual}");
Console.WriteLine($"Segundo resultado: {isNomeEqual2}");

// Tipos Numéricos
/*
    sbyte: entre -128 e 127
    short: entre -32.768 e 32.767
    int: entre -2.147.483.648 e 2.147.483.647
    long: entre - 9.223.372.036.854.775.808 e 9.223.372.036.854.775.807
*/

float myFloat = 10f;
double myDouble = 5d;
decimal myDecimal = 7m;
int myInteger = 0;
