
namespace tabuleiro
{
    public class Tabuleiro
    {
        public int linhas {get; set;}
        public int colunas {get; set;}
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }
    }
}

// Na classe Tabuleiro nos temos linhas e colunas, além de peças. A peça é instânciada, pois uma peça está em uma linha e coluna inicialmente, além de se mover dentro da matriz.