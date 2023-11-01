
namespace tabuleiro
{
    public class Tabuleiro
    {
        public int linhas {get; set;}
        public int colunas {get; set;}
        private Peca[,] pecas; // Private para privar a peca apenas para somente a classe Tabuleiro.

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna){
            return pecas[linha,coluna];
        }
    }
}

// Na classe Tabuleiro nos temos linhas e colunas, além de peças. A peça é instânciada, pois uma peça está em uma linha e coluna inicialmente, além de se mover dentro da matriz.