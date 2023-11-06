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

        // Função para colocar dentro do tabuleiro a peça na posição correta, já que o tabuleiro possui letras e números. 
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