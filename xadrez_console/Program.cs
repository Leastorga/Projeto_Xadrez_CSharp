using System;
using tabuleiro;
using jogoDeXadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabuleiro tabuleiro = new(8, 8); // Tamanho de um tabuleiro de xadrez
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0,0));  //Colocando a peça e em que posição ela está no tabuleiro.
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1,3));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2,4));

            Tela.imprimirTabuleiro(tabuleiro);

            Console.ReadLine();
        }
    }
}