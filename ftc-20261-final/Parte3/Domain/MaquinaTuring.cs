using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte3.Domain
{
    public class MaquinaTuring
    {
        public const char Branco = '_';

        public string Q0 { get; }
        public string QAccept { get; }
        public string QReject { get; }
        public int LimitePassos { get; }

        public Dictionary<(string, char), (string, char, char)> Delta { get;  }

        public MaquinaTuring(
            Dictionary<(string,char), (string, char, char)> transicoes,
            string estadoInicial,
            string estadoAceitacao,
            string estadoRejeicao,
            int limitePassos
            )
        {
            Delta = transicoes;
            Q0 = estadoInicial;
            QAccept = estadoAceitacao;
            QReject = estadoRejeicao;
            LimitePassos = limitePassos;
        }

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
                if (contadorPassos >= LimitePassos)
                {
                    estadoAtual = QReject;
                    break;
                }


                char simboloAtual = fita.ContainsKey(cabecote) ? fita[cabecote] : Branco;
                var chave = (estadoAtual, simboloAtual);

                if (Delta.TryGetValue(chave, out var destino))
                {
                    fita[cabecote] = destino.Item2;

                    estadoAtual = destino.Item1;

                    char direcao = destino.Item3;

                    if (direcao == 'R') cabecote++;
                    else if (direcao == 'L') cabecote--;

                    contadorPassos++;
                    Presentation.VisualizadorMt.ImprimirConfiguracao(estadoAtual, fita, cabecote, contadorPassos);
                }
                else
                {
                    estadoAtual = QReject;
                    Presentation.VisualizadorMt.ImprimirConfiguracao(estadoAtual, fita, cabecote, contadorPassos);
                }
            }
            return (estadoAtual == QAccept, fita, contadorPassos);
        }
    }
}
