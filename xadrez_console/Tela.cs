using System;
using tabuleiro;

// Não está com o tabuleiro pois não é um componente e sim o que tornará os componentes visiveis. 
// Classe para método de imprimir o tabuleiro
namespace xadrez_console
{
    public class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {

            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (tabuleiro.peca(i, j) == null) // se não houver peça no tabuleiro imprimeiro "-"
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tabuleiro.peca(i, j) + " "); // Se houver imprimir a peça
                    }
                }
                Console.WriteLine(); // Quando acabar as colunas pula de linha
            }
        }
    }
}