using ftc_20261_final.Parte2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2.Domain
{
    /// <summary>
    /// Representa a 6-tupla formal de um Autômato de Pilha (AP): M = (Q, Σ, Γ, δ, q0, Z0)
    /// </summary>
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
            // Cláusulas de Guarda que garantem a integridade do modelo matemático
            if(estados == null || estados.Count == 0) throw new ArgumentException("O conjunto de estados (Q) não pode ser vazio.");
            if(alfabetoEntrada == null || alfabetoEntrada.Count == 0) throw new ArgumentException("O alfabeto de entrada (Σ) não pode ser vazio.");
            if(alfabetoPilha == null || alfabetoPilha.Count == 0) throw new ArgumentException("O alfabeto da pilha (Γ) não pode ser vazio.");
            if(!estados.Contains(estadoInicial)) throw new ArgumentException("O estado inicial (q0) deve pertencer a Q.");
            if(!alfabetoPilha.Contains(simboloInicialPilha)) throw new ArgumentException("O símbolo inicial (Z0) deve pertencer a Γ.");

            Q = estados;
            Sigma = alfabetoEntrada;
            Gamma = alfabetoPilha;
            Delta = transicoes;
            Q0 = estadoInicial;
            Z0 = simboloInicialPilha;
        }

        /// <summary>
        /// Inicia o processamento da cadeia configurando a pilha inicial com o marcador Z0
        /// </summary>
        /// <param name="cadeia"></param>
        /// <returns></returns>
        public bool Aceitar(string cadeia)
        {
            string entradaReal = (cadeia == "E" || string.IsNullOrEmpty(cadeia)) ? "" : cadeia;

            var pilhaInicial = new Stack<char>();
            pilhaInicial.Push(Z0);

            return ExplorarCaminhos(Q0, entradaReal, 0, pilhaInicial);
        }

        /// <summary>
        /// O Motor Recursivo não-determinístico, explorando todos os ramos possíveis até esgotar as opções
        /// </summary>
        /// <param name="estadoAtual"></param>
        /// <param name="cadeia"></param>
        /// <param name="indice"></param>
        /// <param name="pilhaCorrente"></param>
        /// <returns></returns>
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

            // Consome transições vazias sem avançar na fita
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

            // Tenta consumir o caractere atual da fita
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

        /// <summary>
        /// Utilitário para evitar que a pilha seja invertida durante o processo de clonagem iterativa
        /// </summary>
        /// <param name="pilhaOriginal"></param>
        /// <returns></returns>
        private Stack<char> ClonarPilhaNaoInvertida(Stack<char> pilhaOriginal)
        {
            return new Stack<char>(pilhaOriginal.Reverse());
        }
    }
}
