using System;
using tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabuleiro tabuleiro = new(8, 8); // Tamanho de um tabuleiro de xadrez
            
            Tela.imprimirTabuleiro(tabuleiro);

            Console.ReadLine();
        }
    }
}