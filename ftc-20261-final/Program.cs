using System;
using System.Collections.Generic;
using System.Text;

namespace ftc_20261_final
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" TRABALHO FINAL ");
                Console.WriteLine(" 1 - Executar Parte 1 (AFD)");
                Console.WriteLine(" 2 - Executar Parte 2 (Autômato de Pilha)");
                Console.WriteLine(" 3 - Executar Parte 3 (Máquina de Turing)");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine("Escolha uma opção");

                string opcao = Console.ReadLine();

                Console.Clear();

                switch(opcao) 
                {
                    case "1":
                        Parte1.Program.Executar();
                        break;
                    case "2":
                        Parte2.Program.Executar(); 
                        break;
                    case "3":
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa");
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }
    }
}
