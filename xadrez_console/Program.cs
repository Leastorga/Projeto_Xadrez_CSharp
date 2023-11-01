using System;
using tabuleiro;
using jogoDeXadrez;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try{
            // Tamanho de um tabuleiro de xadrez
            Tabuleiro tabuleiro = new(8, 8); 

            //Colocando a peça e em que posição ela está no tabuleiro.
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0,0));  
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1,3));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0,2));

            Tela.imprimirTabuleiro(tabuleiro);
            }catch (TabuleiroException e){

                Console.WriteLine(e.Message);
            }

        }
    }
}