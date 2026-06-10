using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte3.Presentation
{
    public class VisualizadorMt
    {
        public static void ImprimirConfiguracao(string estado, Dictionary<int, char> fita, int cabecote, int passo)
        {
            int minIdx = fita.Keys.Count > 0 ? Math.Min(fita.Keys.Min(), cabecote) : cabecote;
            int maxIdx = fita.Keys.Count > 0 ? Math.Max(fita.Keys.Max(), cabecote) : cabecote;

            var stringBuider = new StringBuilder();
        }

        public static void ImprimirResultado(string cadeia, bool aceita, Dictionary<int, char> fitaFinal)
        {
            string fitaLimpa = ObterFitaLimpa(fitaFinal);
        }

        public static string ObterFitaLimpa(Dictionary<int, char> fita)
        {
            var stringBuilder = new StringBuilder();
            return stringBuilder.ToString();
        }
    }
}
