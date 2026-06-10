using ftc_20261_final.Parte1.Domain;
using ftc_20261_final.Parte1.Infrastructure;
using ftc_20261_final.Parte1.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte1
{
    internal class Program
    {
        public static void Executar()
        {
            string pastaDoExecutavel = AppContext.BaseDirectory;
            string caminhoJson = Path.GetFullPath(Path.Combine(pastaDoExecutavel, "..", "..", "..", "Parte1","Resources", "afd.json"));
            string caminhoEntradas = Path.GetFullPath(Path.Combine(pastaDoExecutavel, "..", "..", "..", "Parte1", "Resources", "entradas.txt"));

            try
            {
                Console.WriteLine("Carregando o autômato a partir de um arquivo JSON...");
                var loader = new AutomacaoJsonLoader();
                AutomacaoDeterministica afd = loader.CarregarJson(caminhoJson);

                afd.ExibirDiagrama();

                if (!File.Exists(caminhoEntradas))
                {
                    Console.WriteLine($"ERROR: O arquivo de teste '{caminhoEntradas}' não foi encontrado");
                    return;
                }

                Console.WriteLine("Processando as cadeias de teste do arquivo...");

                string[] linhas = File.ReadAllLines(caminhoEntradas);
                foreach (string linha in linhas)
                {
                    string cadeia = linha.Trim();

                    if (string.IsNullOrEmpty(cadeia)) continue;

                    if (cadeia == "E")
                    {
                        cadeia = "";
                    }

                    bool aceita = afd.Aceitar(cadeia);
                    var rastro = afd.ObterRastro(cadeia);

                    string cadeiaParaImprimir = cadeia == "" ? "ε (vazia)" : cadeia;
                    ConsoleTrace.Imprimir(cadeia, rastro, aceita);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
