using ftc_20261_final.Parte3.Infrastructure;
using ftc_20261_final.Parte3.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final.Parte3
{
    /// <summary>
    /// Orquestrador da Parte 3: Máquina de Turing
    /// Interliga os dados de entrada ao motor computacional e à interface de visualização
    /// </summary>
    public static class Program
    {
        public static void Executar()
        {
            string pastaDoExecutavel = AppContext.BaseDirectory;
            
            string pathL4 = Path.GetFullPath(Path.Combine(pastaDoExecutavel, "..", "..", "..", "Parte3", "Resources", "entradas_L4.txt"));
            string pathFuncao = Path.GetFullPath(Path.Combine(pastaDoExecutavel, "..", "..", "..", "Parte3", "Resources", "entradas_funcao.txt"));

            if (!File.Exists(pathL4) || !File.Exists(pathFuncao))
            {
                Console.WriteLine("Arquivos de entrada não encontrados na pasta Resources");
                return;
            }

            Console.WriteLine(" Máquina de Turing: L4 = { a^n b^n c^n } ");

            var mtL4 = ConfiguradorMt.CriarMtL4();

            foreach (string linha in File.ReadAllLines(pathL4))
            {
                string cadeia = linha.Trim();
                if (string.IsNullOrEmpty(cadeia)) 
                {
                    continue;
                }

                Console.WriteLine($"\nProcessando Cadeia: \"{cadeia}\"");
                var resultado = mtL4.Executar(cadeia);

                VisualizadorMt.ImprimirResultado(cadeia, resultado.Aceita, resultado.FitaFinal);
            }

            Console.WriteLine(" Máquina de Turing: Função Unária f(n) = n + 1 ");

            var mtUnaria = ConfiguradorMt.CriarMtFuncaoUnaria();
            foreach (string linha in File.ReadAllLines(pathFuncao))
            {
                string cadeia = linha.Trim();
                if (string.IsNullOrEmpty(cadeia))
                {
                    continue;
                }

                Console.WriteLine($"\nComputando Entrada: \"{cadeia}\"");

                var resultado = mtUnaria.Executar(cadeia);

                VisualizadorMt.ImprimirResultado(cadeia, resultado.Aceita, resultado.FitaFinal);
            }
        }
    }
}
