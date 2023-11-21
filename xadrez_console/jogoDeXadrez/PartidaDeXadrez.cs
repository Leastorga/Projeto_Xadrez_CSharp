
using tabuleiro;

// Essa classe foi criada com o intuito de realizar a partida de xadrez
namespace jogoDeXadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;  //  HashSet: Conjunto que armazena elementos únicos sem duplicatas
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        // Aqui determinamos uma início da partida, qual o turno e quem irá começar.
        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        // Também criamos uma função para exercutar um movimento e caso haja uma peça lá, tirar ela de dentro do tabuleiro e ir até o seu destino selecionado.
        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.TirarPeca(origem);
            p.IncrementarQteMovimentos();
            Peca pecaCapturada = Tab.TirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.TirarPeca(destino);
            p.DecrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        // Método para realizar a jogada e depois alterar o turno e jogador. 
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmCheque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xaque!");
            }
            if (EstaEmCheque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).MovimentosPossiveis(destino))
            {
                throw new TabuleiroException("Posição de destino invélida!");
            }
        }

        // Método para alterar a cor da peça do tabuleiro
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        // Método que guarda no conjunto as peças que foram capturadas
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }


        // Método que guarda no conjunto as peças que ainda estão no jogo
        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmCheque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] matriz = x.MovimentosPossiveis();
                if (matriz[rei.Posicao.Linha, rei.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmCheque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] matriz = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool TesteXeque = EstaEmCheque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!TesteXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        // Metódo para colocar as peças no tabuleiro
        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('h', 7, new Torre(Tab, Cor.Branca));

            ColocarNovaPeca('a', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Torre(Tab, Cor.Preta));

        }
    }
}