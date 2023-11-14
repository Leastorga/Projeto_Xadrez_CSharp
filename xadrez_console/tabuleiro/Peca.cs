using tabuleiro;
// Aqui na classe Peca temos que uma peça tem uma posição, uma cor, a quantidade de movimentos que pode ter e ela está em um tabuleiro.
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; } // set protected para permite que a propriedade só possa ser modificado na própria classe ou em subclasses.
        public Tabuleiro tabuleiro { get; protected set; }
        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.tabuleiro = tabuleiro;
            this.posicao = null; // Determinamos a função de posição no Tabuleiro, logo ela teria que começar nula.
            this.cor = cor;
            this.qteMovimentos = 0;
        
        }

        public void incrementarQteMovimentos(){
            qteMovimentos++;
        }

        // Verificar se existe como a peça de mover, ou seja, se ela consegue realizar movimentos. 
        public bool existeMovimentosPossiveis(){
            bool[,] matriz = movimentosPossiveis();
            for(int i = 0; i < tabuleiro.linhas; i++)
            {
                for(int j = 0; j < tabuleiro.colunas; j++)
                {
                    if(matriz[i,j]){
                        return true;
                    }
                }
            }
            return false;
        }

        //Método para validar se a peça pode mudar para o lugar que for digitado
        public bool podeMoverPara(Posicao pos){
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
        //Criamos a função abstract porque servirá de modelo para as classes especifícas das peças. 
        public abstract bool [,] movimentosPossiveis();
    }
}
