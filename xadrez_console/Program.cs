using System;
using tabuleiro;
using jogoDeXadrez;
using xadrez_console.tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            PosicaoXadrez pos = new PosicaoXadrez('a', 1);
            Console.WriteLine(pos.ToPosicao());
            
        }
    }
}