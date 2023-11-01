// Na classe Tabuleiro nos temos linhas e colunas, além de peças. A peça é instânciada, pois uma peça está em uma linha e coluna inicialmente, além de se mover dentro da matriz.

namespace tabuleiro
{
    public class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; // Private para privar a peca apenas para somente a classe Tabuleiro.

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        { // Método criado para poder ser usado na tela, no caso para podermos incluir ela dentro do tabuleiro.
            return pecas[linha, coluna];
        }

        public void colocarPeca(Peca p, Posicao pos)
        { // Criar função para adicionar peça
            pecas[pos.linha, pos.coluna] = p;  // Colocando a peça p dentro da matriz na posição pos.linha e pos.coluna
            p.posicao = pos; // Definindo que a posição da peça p, vai ser a que eu colocar em pos. Lembrando que a posição tem linha e coluna.
        }
    }
}