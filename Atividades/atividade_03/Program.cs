Clear();

//  Escreva um programa C# que seja capaz de perguntar ao usuário um operador aritmético específico
// e com base na operação escolhida pelo usuário, imrpima na tela a tabuada de 1 a 9 daquela operação.
// Utilize uma formatação de impressão e laço de repetição while ou for para exibir a tabuada completa dinamicamente.

// Declaração e nicialização de variáveis que armazenam os valores da conta e o resultado da mesma
double primeiroValor = 0.0;
double segundoValor = 0.0;
double resultado = 0.0;
double tabuada = 0.0;
int opcao = 0;

// Recepção do primeiro valor
Write("---------- CALCULADORA COM TABUADA ----------\n"+
      "        Para começar, insira um número\n"+
      "                      ");
primeiroValor = Convert.ToDouble(ReadLine());
Clear();

// Decisão de qual operação será realizada
Write("---------- CALCULADORA COM TABUADA ----------\n"+
      "          Qual operação será feita?\n"+
      "                    1   +\n"+
      "                    2   -\n"+
      "                    3   *\n"+
      "                    4   \\ \n"+
      "                      ");

opcao = Convert.ToInt32(ReadLine());
Clear();

// Recepção do segundo valor
Write("---------- CALCULADORA COM TABUADA ----------\n"+
      "     Para começar, insira outro número\n"+
      "                      ");
segundoValor = Convert.ToDouble(ReadLine());
Clear();

// Escrita do resultado da operação e de sua tabuada
Write("---------- CALCULADORA COM TABUADA ----------\n");
switch(opcao){
    case 1:
        resultado = primeiroValor+segundoValor;
        break;
    case 2:
        resultado = primeiroValor-segundoValor;
        break;
    case 3:
        resultado = primeiroValor*segundoValor;
        break;
    case 4:
        resultado = primeiroValor/segundoValor;
        break;
    default:
        Write("Opção inválida. Tente novamente.");
        break;
}
Write($"          O resultado da conta é: {resultado}\n"+
       "---------------------------------------------\n"+
       "------------------ TABUADA ------------------\n");

for(int i=0; i<9; i++){
    WriteLine($"               {resultado} * {i+1} = {resultado*(i+1)}");
}