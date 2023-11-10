using tabuleiro;
// Aqui na classe Peca temos que uma peça tem uma posição, uma cor, a quantidade de movimentos que pode ter e ela está em um tabuleiro.
namespace tabuleiro
{
    public class Peca
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
    }
}
