string expression1 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
string expression2 = "([)]";
string expression3 = "{[()}";
string expression4 = "()[]{}{}";

Console.WriteLine($"Expresión: {expression1}");
Console.WriteLine($"Salida esperada: Fórmula balanceada.");
Console.WriteLine($"Salida actual: {(ParenthesesChecker.AreParenthesesBalanced(expression1) ? "Fórmula balanceada." : "Fórmula no balanceada.")}");
Console.WriteLine("---");

Console.WriteLine($"Expresión: {expression2}");
Console.WriteLine($"Salida esperada: Fórmula no balanceada.");
Console.WriteLine($"Salida actual: {(ParenthesesChecker.AreParenthesesBalanced(expression2) ? "Fórmula balanceada." : "Fórmula no balanceada.")}");
Console.WriteLine("---");

Console.WriteLine($"Expresión: {expression3}");
Console.WriteLine($"Salida esperada: Fórmula no balanceada.");
Console.WriteLine($"Salida actual: {(ParenthesesChecker.AreParenthesesBalanced(expression3) ? "Fórmula balanceada." : "Fórmula no balanceada.")}");
Console.WriteLine("---");

Console.WriteLine($"Expresión: {expression4}");
Console.WriteLine($"Salida esperada: Fórmula balanceada.");
Console.WriteLine($"Salida actual: {(ParenthesesChecker.AreParenthesesBalanced(expression4) ? "Fórmula balanceada." : "Fórmula no balanceada.")}");
