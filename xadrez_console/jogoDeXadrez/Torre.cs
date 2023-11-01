using tabuleiro;

// Classe que representa a Peça Torre
namespace jogoDeXadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro,Cor cor) : base(tabuleiro, cor)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}