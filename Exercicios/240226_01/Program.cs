﻿// Trabalhando com variáveis C#
using System;

// Strings
// Declarando variáveis sem inicialização
string message1 = null;

// Inicializar a variável com valor nulo
string message2 = null;

// Inicializar a string vazia
string message3 = System.String.Empty; // ""

// Declarar uma string com valor implícito 
var message4 = "Uma mensagem aleatória.";

Console.WriteLine(message4);

// Concatenando strings
// if ternário

string concat = (message1 == null ? "" : message1) + " " + message2 + " " + message3 + " " + message4;
Console.WriteLine("\n" + concat);

Console.WriteLine("A temperatura hoje {0:D} é {1} °C", DateTime.Now, 23);

string nome = string.Empty;
Console.WriteLine("Qual é o seu nome?");
nome = Console.ReadLine();
string resultado = $"Oi, {nome}";
Console.WriteLine(resultado);

// Escreva um programa em C# que sirva como uma ficha cadastral. Tente caprichar no layout. A ficha deve coletar
// alguns dados do usuário: nome, e-mail, data de nascimento, gênero, endereço separado por CEP, rua, n º, bairro, cidade, UF e país.
// ao coletar os dados, monte um texto exibindo a ficha cadastral do usuário. 