using tabuleiro;
// Aqui na classe Peca temos que uma peça tem uma posição, uma cor, a quantidade de movimentos que pode ter e ela está em um tabuleiro.
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; } // set protected para permite que a propriedade só possa ser modificado na própria classe ou em subclasses.
        public Tabuleiro Tab { get; protected set; }
        public Peca(Tabuleiro tab, Cor cor)
        {
            this.Posicao = null;
            this.Tab = tab;
            this.Cor = cor;
            this.QteMovimentos = 0;
            // Determinamos a função de posição no Tabuleiro, logo ela teria que começar nula.
        }

        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }

        // Verificar se existe como a peça de mover, ou seja, se ela consegue realizar movimentos. 
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] matriz = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (matriz[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Método para validar se a peça pode mudar para o lugar que for digitado
        public bool MovimentosPossiveis(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        //Criamos a função abstract porque servirá de modelo para as classes especifícas das peças. 
        public abstract bool[,] MovimentosPossiveis();
    }
}
