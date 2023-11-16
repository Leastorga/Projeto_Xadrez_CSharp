// Na classe Tabuleiro nos temos linhas e colunas, além de peças. A peça é instânciada, pois uma peça está em uma linha e coluna inicialmente, além de se mover dentro da matriz.

using tabuleiro;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas; // Private para privar a peca apenas para somente a classe Tabuleiro.

        public Tabuleiro(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        { // Método criado para poder ser usado na tela, no caso para podermos incluir ela dentro do tabuleiro.
            return Pecas[linha, coluna];
        }

        // Criando sobrecarga de Peca, onde ao colar uma posição, será o mesmo que int linha, int coluna
        public Peca Peca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        // Criar função para adicionar peça e já verificar se existe uma peça nessa posição
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;  // Colocando a peça p dentro da matriz na posição pos.linha e pos.coluna
            p.Posicao = pos; // Definindo que a posição da peça p, vai ser a que eu colocar em pos. Lembrando que a posição tem linha e coluna.
        }
        
        // Função para retirar peças, se a posição for nula retorna nula, se não a variável auxiliar vai armazenar a posição da peça e depois fazer a posição ser nula, além disso a linha e coluna onde ela estava irá valer nulo e depois retornar, o que no caso retornaria " - " no tabuleiro.
        public Peca TirarPeca(Posicao pos)
        {
            if (Peca(pos) == null)
            {
                return null;
            }
            Peca aux = Peca(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        //Verificar se existe uma peça nessa posição
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        // Verificar se a posição inserida é valida
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        // Se a posição não for válida (FALSE) então lançar uma exceção
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

    }
}