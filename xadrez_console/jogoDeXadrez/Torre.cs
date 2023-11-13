using tabuleiro;

// Classe que representa a Peça Torre
namespace jogoDeXadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        // Método privado que possibilita a verificação de o rei pode ou não se mover. 
        private bool podeMover(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos); // P é igual a peça no tabuleiro em uma posição
            return p != null || p.cor != cor; // retorne p se não for nula ou se houver uma peça adversária
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // Mover para cima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = -1;
            }


            // Mover para baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.linha = +1;
            }


            // Para direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = +1;
            }

            // Para esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = -1;
            }
            return matriz;
        }



    }
}