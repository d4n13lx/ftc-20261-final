using ftc_20261_final.Parte1.Presentation;
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
            if(estados == null || estados.Count == 0) throw new ArgumentException("O conjunto dos estados não pode ser vazio");
            if(alfabeto == null || alfabeto.Count == 0) throw new ArgumentException("O alfabeto Sigma não pode ser vazio");
            if(transicoes == null) throw new ArgumentNullException(nameof(transicoes));
            if(string.IsNullOrWhiteSpace(estadoInicial)) throw new ArgumentException("O estado Inicial deve ser informado");
            if(!estados.Contains(estadoInicial)) throw new ArgumentException("O estado Inicial deve pertencer ao conjunto Q");
            if(estadosAceitacao == null) throw new ArgumentNullException(nameof(estadosAceitacao));
            if(!estados.IsSupersetOf(estadosAceitacao)) throw new ArgumentException("O conjunto de estados de aceitação F deve ser um subconjunto de Q");

            Q = new HashSet<string>(estados);
            Sigma = new HashSet<char>(alfabeto);
            Delta = new Dictionary<(string estado, char simbolo), string>(transicoes);
            Q0 = estadoInicial;
            F = new HashSet<string>(estadosAceitacao);
        }

        public bool Aceitar(string cadeia)
        {
            string estadoAtual = Q0;

            foreach (char simbolo in cadeia)
            {
                if (!Sigma.Contains(simbolo) || !Delta.TryGetValue((estadoAtual, simbolo), out estadoAtual))
                {
                    return false;
                }
            }

            return F.Contains(estadoAtual);
        }

        public IEnumerable<string> ObterRastro(string cadeia)
        {
            var rastro = new List<string> { Q0 };
            string estadoAtual = Q0;

            if (cadeia == null) cadeia = string.Empty;

            foreach (char simbolo in cadeia)
            {
                if (!Sigma.Contains(simbolo))
                {
                    rastro.Add($"ERROR: '{simbolo}' não pertence ao alfabeto de sigma");
                    break;
                }

                if (Delta.TryGetValue((estadoAtual, simbolo), out string proximoEstado)) 
                {
                    estadoAtual = proximoEstado;
                    rastro.Add(estadoAtual);
                }
                else
                {
                    rastro.Add("ERROR: Transição indefinida");
                }
            }

            return rastro;
        }

        public void ExibirDiagrama()
        {
            TabelaVisualizacao.DesenharTabelaTransicoes(Q, Sigma, Delta, Q0, F);
        }
    }
}
