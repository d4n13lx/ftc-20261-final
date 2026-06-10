using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte1.Presentation
{
    public class TabelaVisualizacao
    {
        public static void DesenharTabelaTransicoes(
            HashSet<string> estados,
            HashSet<char> alfabeto,
            Dictionary<(string estado, char simbolo), string> transicoes,
            string estadoInicial,
            HashSet<string> estadosAceitacao
            )
        {
            Console.WriteLine(" TABELA DE TRANSIÇÕES DO AUTÔMATO ");
            Console.WriteLine();

            Console.WriteLine("{0, - 12", "Estado");

            foreach (char simbolo in alfabeto.OrderBy(c => c))
            {
                Console.Write("| {0, -8}", simbolo);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 12 + (alfabeto.Count * 11)));

            foreach (string estado in estados.OrderBy(e => e))
            {
                string prefixo = "";
                if (estado == estadoInicial) prefixo += "->";
                if (estadosAceitacao.Contains(estado)) prefixo += "*";

                string estadoFormatado = $"{prefixo}{estado}";
                Console.Write("{0,-12}", estadoFormatado);

                foreach (char simbolo in alfabeto.OrderBy(c => c))
                {
                    if (transicoes.TryGetValue((estado, simbolo), out string destino))
                    {
                        Console.Write("| {0, -8}", destino);
                    }
                    else
                    {
                        Console.Write("| {0, -8}", "-");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
