using tabuleiro;

// Classe que representa a peça Rei
namespace jogoDeXadrez
{
    public class Rei : Peca
    {

        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}