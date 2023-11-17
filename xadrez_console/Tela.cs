using System.Collections.Generic;
using jogoDeXadrez;
using tabuleiro;

// Não está com o tabuleiro pois não é um componente e sim o que tornará os componentes visiveis. 
// Classe para criação o tabuleiro visivelmente, utilizando uma função de imprimir o tabuleiro para mostra-lo assim que todas as peças forem colocadas.
namespace xadrez_console
{
    class Tela
    {
    
        // Método para imprimir o inicio da partida e os seguintes turnos
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno} ");
            Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");
            if(partida.Xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        // Método para imprimir as peças capturadas
        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida){
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
            
        }
        
        // Método para imprimir os conjuntos das peças capturadas
        public static void ImprimirConjunto(HashSet<Peca> conjunto){
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        // Método para imprimir o tabuleiro
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine(); // Quando acabar as colunas pula de linha
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine(); // Quando acabar as colunas pula de linha
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;

        }


        // Método de imprimir Peça, diferenciando as cores das peças. 
        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
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
                Console.Write(" ");
            }
        }

        // Método que le a posição escrita pelo o usuário, primeiro uma string que receberá a posição, onde primeiro será o char coluna e o int linha que está sendo convertido em uma string.
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(coluna, linha);
        }

    }
}