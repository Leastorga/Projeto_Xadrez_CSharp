using tabuleiro;

namespace jogoDeXadrez
{
    public class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }
        public PosicaoXadrez(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        // Convertemos o método ToPosicao para uma posição comum da matriz tabuleiro
        // Matriz está invertida logo os número são as linhas e as colunas são as strings 
        // Importante lembrar que o a string está sendo subtraida através da sua representação númerica vista na tabela de unicode.
        public Posicao ToPosicao() {
            return new Posicao(8 - Linha, Coluna - 'a');
        }
        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}