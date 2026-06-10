using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte1.Presentation
{
    public class ConsoleTrace
    {
        public static void Imprimir(string cadeia, IEnumerable<string> rastro, bool Aceita)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Cadeia Analisada: \"{cadeia}\"");
            Console.ResetColor();

            Console.WriteLine($"Rastro de Estados: {string.Join(" -> ", rastro)}");

            if (Aceita) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Resultado    : Aceita");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Resultado    : Rejeitado");
            }

            Console.ResetColor();
        }
    }
}
