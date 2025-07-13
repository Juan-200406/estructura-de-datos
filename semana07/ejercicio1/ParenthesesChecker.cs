//Este programa utiliza una pila (Stack) para verificar si los paréntesis, llaves y corchetes en una expresión matemática están correctamente balanceados. La lógica es simple: cuando se encuentra un carácter de apertura, se empuja a la pila. Cuando se encuentra un carácter de cierre, se desapila el último carácter de apertura y se verifica si coincide con el carácter de cierre. Si la pila está vacía al final y todos los caracteres de cierre han tenido su pareja, la expresión está balanceada.//
using System;
using System.Collections.Generic;

public static class ParenthesesChecker
{
    /// <summary>
    /// Verifica si los paréntesis, llaves y corchetes en una expresión están balanceados.
    /// </summary>
    /// <param name="expression">La expresión matemática a verificar.</param>
    /// <returns>True si la expresión está balanceada, False en caso contrario.</returns>
    public static bool AreParenthesesBalanced(string expression)
    {
        // Se utiliza una pila para almacenar los caracteres de apertura.
        Stack<char> stack = new Stack<char>();

        // Se define un diccionario para mapear los caracteres de cierre a sus correspondientes caracteres de apertura.
        Dictionary<char, char> matchingBrackets = new Dictionary<char, char>()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        foreach (char c in expression)
        {
            // Si el carácter es un paréntesis de apertura, se empuja a la pila.
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            // Si el carácter es un paréntesis de cierre.
            else if (c == ')' || c == ']' || c == '}')
            {
                // Si la pila está vacía, no hay un paréntesis de apertura correspondiente.
                if (stack.Count == 0)
                {
                    return false;
                }

                // Se obtiene el último paréntesis de apertura de la pila.
                char lastOpenBracket = stack.Pop();

                // Se verifica si el paréntesis de cierre actual coincide con el último de apertura.
                if (matchingBrackets[c] != lastOpenBracket)
                {
                    return false;
                }
            }
            // Se ignoran otros caracteres que no son paréntesis.
        }

        // Si la pila está vacía al final, significa que todos los paréntesis han sido balanceados.
        return stack.Count == 0;
    }

}