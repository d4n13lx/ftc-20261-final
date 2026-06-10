using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte1.Domain
{
    public class AutomacaoDeterministica
    {
        public HashSet<string> Q { get;  }
        public HashSet<char> Sigma { get; }
        public Dictionary<(string estado, char simbolo), string> Delta { get; }
        public string Q0 { get; }
        public HashSet<string> F { get; }

        public AutomacaoDeterministica(
            HashSet<string> estados,
            HashSet<char> alfabeto,
            Dictionary<(string estado, char simbolo), string> transicoes,
            string estadoInicial,
            HashSet<string> estadosAceitacao)
        {

        }

        public bool Aceitar(string cadeia)
        {
            return false;
        }

        public void ExibirDiagrama()
        {

        }
    }
}
