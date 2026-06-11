using ftc_20261_final.Parte3.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte3.Presentation
{
    /// <summary>
    /// Componente de apresentação responsável pela formatação da saída na Máquina de Turing
    /// </summary>
    public class VisualizadorMt
    {
        /// <summary>
        /// Imprime no Console a configuração instantânea: passo, estado e a fita
        /// </summary>
        /// <param name="estado"></param>
        /// <param name="fita"></param>
        /// <param name="cabecote"></param>
        /// <param name="passo"></param>
        public static void ImprimirConfiguracao(string estado, Dictionary<int, char> fita, int cabecote, int passo)
        {
            int minIdx = fita.Keys.Count > 0 ? Math.Min(fita.Keys.Min(), cabecote) : cabecote;
            int maxIdx = fita.Keys.Count > 0 ? Math.Max(fita.Keys.Max(), cabecote) : cabecote;

            var stringBuilder = new StringBuilder();

            for (int i = minIdx; i <= maxIdx; i++)
            {
                char c = fita.ContainsKey(i) ? fita[i] : MaquinaTuring.Branco;

                if (i == cabecote)
                {
                    stringBuilder.Append($"[{c}]");
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }

            Console.WriteLine($" -> Passo: {passo:D3} | Estado: {estado,-7} | Fita: {stringBuilder}");
        }

        public static void ImprimirResultado(string cadeia, bool aceita, Dictionary<int, char> fitaFinal)
        {
            string fitaLimpa = ObterFitaLimpa(fitaFinal);

            Console.WriteLine($"\nCadeia \"{cadeia}\" -> ");

            if (aceita)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Aceita (Conteúdo final da fita: {fitaLimpa}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Rejeita (Conteúdo final da fita: {fitaLimpa}\n");
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Remove os espaços em branco excedentes das extremidades
        /// </summary>
        /// <param name="fita"></param>
        /// <returns></returns>
        public static string ObterFitaLimpa(Dictionary<int, char> fita)
        {
            if (fita.Count == 0)
            {
                return MaquinaTuring.Branco.ToString();
            }

            var stringBuilder = new StringBuilder();

            for (int i = fita.Keys.Min(); i <= fita.Keys.Max(); i++)
            {
                stringBuilder.Append(fita.ContainsKey(i) ? fita[i] : MaquinaTuring.Branco);
            }

            return stringBuilder.ToString().Trim(MaquinaTuring.Branco);
        }
    }
}
