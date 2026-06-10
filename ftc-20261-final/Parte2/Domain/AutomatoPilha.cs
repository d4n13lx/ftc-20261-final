using ftc_20261_final.Parte2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Domain
{
    public class AutomatoPilha
    {
        private const char Epsilon = 'E';

        public HashSet<string> Q { get; }
        public HashSet<char> Sigma { get; }
        public HashSet<char> Gamma { get; }
        public Dictionary<ChaveTransicao, List<DestinoTransicao>> Delta { get; }
        public string Q0 { get; }
        public char Z0 { get; }

        public AutomatoPilha(
            HashSet<string> estados,
            HashSet<char> alfabetoEntrada,
            HashSet<char> alfabetoPilha,
            Dictionary<ChaveTransicao, List<DestinoTransicao>> transicoes,
            string estadoInicial,
            char simboloInicialPilha)
        {
            Q = estados;
            Sigma = alfabetoEntrada;
            Gamma = alfabetoPilha;
            Delta = transicoes;
            Q0 = estadoInicial;
            Z0 = simboloInicialPilha;
        }

        public bool Aceitar(string cadeia)
        {
            string entradaReal = (cadeia == "E" || string.IsNullOrEmpty(cadeia)) ? "" : cadeia;

            var pilhaInicial = new Stack<char>();
            pilhaInicial.Push(Z0);

            return ExplorarCaminhos(Q0, entradaReal, 0, pilhaInicial);
        }

        public bool ExplorarCaminhos(string estadoAtual, string cadeia, int indice, Stack<char> pilhaCorrente)
        {
            string cadeiaRestante = cadeia.Substring(indice);
            VisualizadorAp.ImprimirConfiguracao(estadoAtual, cadeiaRestante, pilhaCorrente);

            if (indice == cadeia.Length && pilhaCorrente.Count == 0)
            {
                return true;
            }

            if (pilhaCorrente.Count == 0)
            {
                return false;
            }

            char topoAtual = pilhaCorrente.Peek();

            var chaveEpsilon = new ChaveTransicao(estadoAtual, Epsilon, topoAtual);

            if (Delta.TryGetValue(chaveEpsilon, out List<DestinoTransicao> destinosEpsilon))
            {
                foreach (var destino in destinosEpsilon)
                {
                    var pilhaClonada = ClonarPilhaNaoInvertida(pilhaCorrente);
                    pilhaClonada.Pop();

                    foreach (char c in destino.ElementosEmpilhar.Reverse())
                    {
                        pilhaClonada.Push(c);
                    }

                    if (ExplorarCaminhos(destino.ProximoEstado, cadeia, indice, pilhaClonada))
                    {
                        return true;
                    }
                }
            }

            if (indice < cadeia.Length)
            {
                char caractereAtual = cadeia[indice];

                var chaveConsumo = new ChaveTransicao(estadoAtual, caractereAtual, topoAtual);

                if (Delta.TryGetValue(chaveConsumo, out List<DestinoTransicao> destinosConsumo))
                {
                    foreach (var destino in destinosConsumo)
                    {
                        var pilhaClonada = ClonarPilhaNaoInvertida(pilhaCorrente);
                        pilhaClonada.Pop();

                        foreach (char c in destino.ElementosEmpilhar.Reverse())
                        {
                            pilhaClonada.Push(c);
                        }

                        if (ExplorarCaminhos(destino.ProximoEstado, cadeia, indice + 1, pilhaClonada))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private Stack<char> ClonarPilhaNaoInvertida(Stack<char> pilhaOriginal)
        {
            return new Stack<char>(pilhaOriginal.Reverse());
        }
    }
}
