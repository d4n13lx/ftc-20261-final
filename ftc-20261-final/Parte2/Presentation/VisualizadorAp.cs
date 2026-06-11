using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Presentation
{
    /// <summary>
    /// Componente de apresentação visual do Autômato de Pilha
    /// </summary>
    public class VisualizadorAp
    {
        /// <summary>
        /// Exibe a configuração instantânea (Estado, Restante da Fita e Conteúdo da Pilha)
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="entradaRestante"></param>
        /// <param name="pilha"></param>
        public static void ImprimirConfiguracao(string estado, string entradaRestante, Stack<char> pilha)
        {
            string representacaoEntrada = string.IsNullOrEmpty(entradaRestante) ? "ε" : $"\"{entradaRestante}\"";

            char[] arrPilha = pilha.ToArray();
            string representacaoPilha = arrPilha.Length == 0 ? "Vazia" : string.Join(", ", arrPilha);

            Console.WriteLine($" -> Estado: {estado}, Entrada Restante: {representacaoEntrada}, Pilha: [{representacaoPilha}]");
        }

        public static void ImprimirResultado(string cadeia, bool aceita)
        {
            Console.WriteLine($"\nCadeia \"{cadeia}\" -> ");

            if (aceita)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Aceita (Pilha Esvaziada com Sucesso!)\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rejeitada (Pilha Não Esvaziou ou Transição Morta)\n");
            }
            Console.ResetColor();
        }
    }
}
