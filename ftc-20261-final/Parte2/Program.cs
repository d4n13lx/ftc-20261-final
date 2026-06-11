using ftc_20261_final.Parte2.Domain;
using ftc_20261_final.Parte2.Infrastructure;
using ftc_20261_final.Parte2.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte2
{
    /// <summary>
    /// Orquestrador da Parte 2
    /// </summary>
    public class Program
    {
        public static void Executar()
        {
            string pastaDoExecutavel = AppContext.BaseDirectory;
            string caminhoArquivo = Path.GetFullPath(Path.Combine(pastaDoExecutavel, "..", "..", "..", "Parte2", "Resources", "entradas_ap.txt"));
            

            if (!File.Exists(caminhoArquivo))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Arquivos de testes não encontrado em: {caminhoArquivo}");
                Console.ResetColor();
                return;
            }

            // Lê as linhas, remove espaços em branco e filtra linhas vazias
            var linhasValidas = File.ReadAllLines(caminhoArquivo)
                                    .Select(l => l.Trim())
                                    .Where(l => !string.IsNullOrEmpty(l));

            Console.WriteLine(" EXECUTANDO AUTÔMATO DE PILHA PARA L2 (A^2 B^N) ");
            Console.WriteLine();

            AutomatoPilha apL2 = ConfiguradorAutomato.CriarAutomatoL2();

            foreach (string linha in linhasValidas)
            {
                Console.WriteLine($"Processando Cadeia: \"{linha}\"");

                bool aceita = apL2.Aceitar(linha);
                VisualizadorAp.ImprimirResultado(linha, aceita);
            }

            Console.WriteLine(" EXECUTANDO AUTÔMATO DE PILHA PARA L3 (PALÍNDROMOS) ");
            AutomatoPilha apL3 = ConfiguradorAutomato.CriarAutomatoL3();

            foreach (string linha in linhasValidas)
            {
                Console.WriteLine($"Processando Cadeia: \"{linha}\"");

                bool aceita = apL3.Aceitar(linha);
                VisualizadorAp.ImprimirResultado(linha, aceita);
            }
        }
    }
}
