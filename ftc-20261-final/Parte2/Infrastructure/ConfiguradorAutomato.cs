using ftc_20261_final.Parte2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Infrastructure
{
    /// <summary>
    /// Mapeia estaticamente as configurações das duas linguagens (L2 e L3)
    /// </summary>
    public class ConfiguradorAutomato
    {
        public static AutomatoPilha CriarAutomatoL2() 
        {
            var estados = new HashSet<string> { "q0", "q1" };
            var sigma = new HashSet<char> { 'a', 'b' };
            var gamma = new HashSet<char> { 'A', 'Z' };

            var delta = new Dictionary<ChaveTransicao, List<DestinoTransicao>>();

            delta[new ChaveTransicao("q0", 'a', 'Z')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "AZ")
            };

            delta[new ChaveTransicao("q0", 'a', 'A')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "AA")
            };

            delta[new ChaveTransicao("q0", 'b', 'A')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q1", "")
            };

            delta[new ChaveTransicao("q1", 'b', 'A')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q1", "")
            };

            delta[new ChaveTransicao("q1", 'E', 'Z')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q1", "")
            };

            return new AutomatoPilha(estados, sigma, gamma, delta, "q0", 'Z');
        }

        public static AutomatoPilha CriarAutomatoL3()
        {
            var estados = new HashSet<string> { "q0", "q1" };
            var sigma = new HashSet<char> { 'a', 'b' };
            var gamma = new HashSet<char> { 'A', 'B', 'Z' };

            var delta = new Dictionary<ChaveTransicao, List<DestinoTransicao>>();

            // Empilhamento q0
            delta[new ChaveTransicao("q0", 'a', 'Z')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "AZ")
            };
            delta[new ChaveTransicao("q0", 'b', 'Z')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "BZ")
            };
            delta[new ChaveTransicao("q0", 'a', 'A')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "AA")
            };
            delta[new ChaveTransicao("q0", 'b', 'A')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "BA")
            };
            delta[new ChaveTransicao("q0", 'a', 'B')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "AB")
            };
            delta[new ChaveTransicao("q0", 'b', 'B')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q0", "BB")
            };

            // Transições Epsilon
            delta[new ChaveTransicao("q0", 'E', 'A')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q1", "A")
            };
            delta[new ChaveTransicao("q0", 'E', 'B')] = new List<DestinoTransicao>
            {
                new DestinoTransicao("q1", "B")
            };

            // Transições não-determinísticas
            delta[new ChaveTransicao("q0", 'a', 'Z')].Add(new DestinoTransicao("q1", "Z"));
            delta[new ChaveTransicao("q0", 'a', 'A')].Add(new DestinoTransicao("q1", "A"));
            delta[new ChaveTransicao("q0", 'a', 'B')].Add(new DestinoTransicao("q1", "B"));
            delta[new ChaveTransicao("q0", 'b', 'Z')].Add(new DestinoTransicao("q1", "Z"));
            delta[new ChaveTransicao("q0", 'b', 'A')].Add(new DestinoTransicao("q1", "A"));
            delta[new ChaveTransicao("q0", 'b', 'B')].Add(new DestinoTransicao("q1", "B"));

            // Desempilhamento e validação q1
            delta[new ChaveTransicao("q1", 'a', 'A')] = new List<DestinoTransicao> { new DestinoTransicao("q1", "") };
            delta[new ChaveTransicao("q1", 'b', 'B')] = new List<DestinoTransicao> { new DestinoTransicao("q1", "") };

            // Aceitação por pilha vazia
            delta[new ChaveTransicao("q1", 'E', 'Z')] = new List<DestinoTransicao> { new DestinoTransicao("q1", "") };

            return new AutomatoPilha(estados, sigma, gamma, delta, "q0", 'Z');
        }
    }
}
