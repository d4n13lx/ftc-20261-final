using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte3.Domain
{
    /// <summary>
    /// Representa a 7-tupla formal de uma Máquina de Turing: M = (Q, Σ, Γ, δ, q0, qaccept, qreject)
    /// </summary>
    public class MaquinaTuring
    {
        public const char Branco = '_';

        public string Q0 { get; }
        public string QAccept { get; }
        public string QReject { get; }
        public int LimitePassos { get; }

        /// <summary>
        /// Dicionário que mapeia a função de transição δ(q, a) = (q', a', D)
        /// </summary>
        public Dictionary<(string, char), (string, char, char)> Delta { get;  }

        public MaquinaTuring(
            Dictionary<(string,char), (string, char, char)> transicoes,
            string estadoInicial,
            string estadoAceitacao,
            string estadoRejeicao,
            int limitePassos
            )
        {
            // Cláusulas de Guarda que garantem a integridade do modelo matemático
            if(transicoes == null) throw new ArgumentNullException(nameof(transicoes));
            if(string.IsNullOrWhiteSpace(estadoInicial)) throw new ArgumentException("O estado inicial (q0) deve ser informado.");
            if(string.IsNullOrWhiteSpace(estadoAceitacao)) throw new ArgumentException("O estado de aceitação (qaccept) deve ser informado.");
            if(string.IsNullOrWhiteSpace(estadoRejeicao)) throw new ArgumentException("O estado de rejeição (qreject) deve ser informado.");
            if(limitePassos <= 0) throw new ArgumentException("O limite de passos deve ser superior a zero para evitar loops infinitos.");

            Delta = transicoes;
            Q0 = estadoInicial;
            QAccept = estadoAceitacao;
            QReject = estadoRejeicao;
            LimitePassos = limitePassos;
        }

        /// <summary>
        /// Responsável por processar a cadeia de entrada, movimentando o cabeçote sobre a fita dinâmica
        /// até aceitar, rejeitar ou atingir o limite de passos
        /// </summary>
        /// <param name="cadeia"></param>
        /// <returns></returns>
        public (bool Aceita, Dictionary<int, char> FitaFinal, int Passos) Executar(string cadeia)
        {
            var fita = new Dictionary<int, char>();

            string entrada = (cadeia == "E") ? "" : cadeia;

            for (int i = 0; i < entrada.Length; i++) 
            {
                fita[i] = entrada[i];
            }

            int cabecote = 0;
            string estadoAtual = Q0;
            int contadorPassos = 0;

            Presentation.VisualizadorMt.ImprimirConfiguracao(estadoAtual, fita, cabecote, contadorPassos);

            while (estadoAtual != QAccept && estadoAtual != QReject)
            {
                // Protegendo contra ciclos infinitos
                if (contadorPassos >= LimitePassos)
                {
                    estadoAtual = QReject;
                    break;
                }


                char simboloAtual = fita.ContainsKey(cabecote) ? fita[cabecote] : Branco;
                var chave = (estadoAtual, simboloAtual);

                if (Delta.TryGetValue(chave, out var destino))
                {
                    // Escreve o novo símbolo na fita
                    fita[cabecote] = destino.Item2;

                    // Transita para o novo estado
                    estadoAtual = destino.Item1;
                    char direcao = destino.Item3;

                    // Move o cabeçote (R = Direita(Right), L = Esquerda(Left))
                    if (direcao == 'R') cabecote++;
                    else if (direcao == 'L') cabecote--;

                    contadorPassos++;
                    Presentation.VisualizadorMt.ImprimirConfiguracao(estadoAtual, fita, cabecote, contadorPassos);
                }
                else
                {
                    // Transição indefinida resulta em rejeição
                    estadoAtual = QReject;
                    Presentation.VisualizadorMt.ImprimirConfiguracao(estadoAtual, fita, cabecote, contadorPassos);
                }
            }
            return (estadoAtual == QAccept, fita, contadorPassos);
        }
    }
}
