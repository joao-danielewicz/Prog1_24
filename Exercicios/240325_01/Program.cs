using _240325_01.Models;
// Primeira clínica

Clinica c1 = new Clinica();
Clinica.InstanceCount = 1;
c1.ObjectCount = 1;

// Segunda clínica

Clinica c2 = new Clinica();
Clinica.InstanceCount++;
c2.ObjectCount = 10;

Console.WriteLine($"Valor c1: {c1.ObjectCount}\nInstance Count: {Clinica.InstanceCount}\nValor c2: {c2.ObjectCount}\n");