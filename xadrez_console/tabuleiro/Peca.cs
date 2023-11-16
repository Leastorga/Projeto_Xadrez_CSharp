using tabuleiro;
// Aqui na classe Peca temos que uma peça tem uma posição, uma cor, a quantidade de movimentos que pode ter e ela está em um tabuleiro.
namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; } // set protected para permite que a propriedade só possa ser modificado na própria classe ou em subclasses.
        public Tabuleiro Tabuleiro { get; protected set; }
        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.Tabuleiro = tabuleiro;
            this.Posicao = null; // Determinamos a função de posição no Tabuleiro, logo ela teria que começar nula.
            this.Cor = cor;
            this.QteMovimentos = 0;
        
        }

        public void IncrementarQteMovimentos(){
            QteMovimentos++;
        }

        // Verificar se existe como a peça de mover, ou seja, se ela consegue realizar movimentos. 
        public bool ExisteMovimentosPossiveis(){
            bool[,] matriz = MovimentosPossiveis();
            for(int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for(int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if(matriz[i,j]){
                        return true;
                    }
                }
            }
            return false;
        }

        //Método para validar se a peça pode mudar para o lugar que for digitado
        public bool PodeMoverPara(Posicao pos){
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        //Criamos a função abstract porque servirá de modelo para as classes especifícas das peças. 
        public abstract bool [,] MovimentosPossiveis();
    }
}
