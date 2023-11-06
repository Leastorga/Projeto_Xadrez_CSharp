// Na classe Tabuleiro nos temos linhas e colunas, além de peças. A peça é instânciada, pois uma peça está em uma linha e coluna inicialmente, além de se mover dentro da matriz.

using xadrez_console.tabuleiro;

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

        // Criando sobrecarga de Peca, onde ao colar uma posição, será o mesmo que int linha, int coluna
        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        // Criar função para adicionar peça e já verificar se existe uma peça nessa posição
        public void colocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;  // Colocando a peça p dentro da matriz na posição pos.linha e pos.coluna
            p.posicao = pos; // Definindo que a posição da peça p, vai ser a que eu colocar em pos. Lembrando que a posição tem linha e coluna.
        }
        
        // Função para retirar peças, se a posição for nula retorna nula, se não a variável auxiliar vai armazenar a posição da peça e depois fazer a posição ser nula, além disso a linha e coluna onde ela estava irá valer nulo e depois retornar, o que no caso retornaria " - " no tabuleiro.
        public Peca tirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
        }

        //Verificar se existe uma peça nessa posição
        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        // Verificar se a posição inserida é valida
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        // Se a posição não for válida (FALSE) então lançar uma exceção
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

    }
}