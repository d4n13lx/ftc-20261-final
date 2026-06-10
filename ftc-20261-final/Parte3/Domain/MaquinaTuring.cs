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
        }
    }
}
