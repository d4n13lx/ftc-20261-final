using ftc_20261_final.Parte2.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Infrastructure
{
    public class ConfiguradorAutomato
    {
        public static AutomatoPilha CriarAutomatoL2() 
        {
            var estados = new HashSet<string> { "q0", "q1" };
            var sigma = new HashSet<char> { 'a', 'b' };
            var gamma = new HashSet<char> { 'A', 'Z' };

            var delta = new Dictionary<ChaveTransicao, List<DestinoTransicao>>();

            return new AutomatoPilha(estados, sigma, gamma, delta, "q0", 'Z');
        }

        public static AutomatoPilha CriarAutomatoL3()
        {
            var estados = new HashSet<string> { "q0", "q1" };
            var sigma = new HashSet<char> { 'a', 'b' };
            var gamma = new HashSet<char> { 'A', 'B', 'Z' };

            var delta = new Dictionary<ChaveTransicao, List<DestinoTransicao>>();

            return new AutomatoPilha(estados, sigma, gamma, delta, "q0", 'Z');
        }
    }
}
