// Na classe posição nós temos a posição que a peça estará, na linha e coluna determinada. 

namespace tabuleiro
{
    public class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public Posicao()
        {
        }

        // Criamos um construtor que diz que a posição recebe (linha, coluna)
        public Posicao(int linha, int coluna) 
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }
        public void DefinirValores(int linha, int coluna) 
        {
            this.Linha = linha;
            this.Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha
            + ", "
            + Coluna
            ;
        }
    }
}

