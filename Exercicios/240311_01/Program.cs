// Operadores

// ++ é um acumulador. Neste caso, somará a+1.
int a = 3;
int b = a++; 

// Neste caso, o acúmulo acontece após a atribuição pois o ++ está do lado direito de a.
WriteLine($"a é {a}, b é {b}");
int c = 3;
int d = ++c;

// Aqui, o ++ está à esquerda de C, então o acúmulo acontece antes da atribuição.
WriteLine($"c é {c}, d é {d}");

// Equivalente à p = p +3, -3, *3, /3
int p = 6;
p += 3;
p -= 3;
p *= 3;
p /= 3; 

// Operadores lógicos
bool b_A = true;
bool b_B = false;

WriteLine($"AND  | b_A   | b_B  ");
WriteLine($"b_A  | {b_A & b_A, -5} | {b_A & b_B, -5}");
WriteLine($"b_B  | {b_A & b_A, -5} | {b_B & b_B, -5}\n");

WriteLine($"OR   | b_A   | b_B  ");
WriteLine($"b_A  | {b_A | b_A, -5} | {b_A | b_B, -5}");
WriteLine($"b_B  | {b_A | b_A, -5} | {b_B | b_B, -5}\n");

WriteLine($"XOR  | b_A   | b_B  ");
WriteLine($"b_A  | {b_A ^ b_A, -5} | {b_A ^ b_B, -5}");
WriteLine($"b_B  | {b_A ^ b_A, -5} | {b_B ^ b_B, -5}\n");