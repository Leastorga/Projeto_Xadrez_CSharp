using tabuleiro;

namespace xadrez
{
    public class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }
        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        // Convertemos o método ToPosicao para uma posição comum da matriz tabuleiro
        // Matriz está invertida logo os número são as linhas e as colunas são as strings 
        // Importante lembrar que o a string está sendo subtraida através da sua representação númerica vista na tabela de unicode.
        public Posicao ToPosicao() {
            return new Posicao(coluna - 'a', 8 - linha);
        }
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}