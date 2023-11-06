using System;
using System.Runtime.InteropServices.Marshalling;
using tabuleiro;

// Não está com o tabuleiro pois não é um componente e sim o que tornará os componentes visiveis. 
// Classe para criação o tabuleiro visivelmente, utilizando uma função de imprimir o tabuleiro para mostra-lo assim que todas as peças forem colocadas.
namespace xadrez_console
{
    public class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {

            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (tabuleiro.peca(i, j) == null) // se não houver peça no tabuleiro imprimeiro "-"
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Tela.imprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" "); // Se houver imprimir a peça
                    }
                }
                Console.WriteLine(); // Quando acabar as colunas pula de linha
            }
            Console.Write("  a b c d e f g h");
        }


        // Método de imprimir Peça, diferenciando as cores das peças. 
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}