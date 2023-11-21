using System.IO.Compression;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using tabuleiro;

namespace jogoDeXadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao pos){
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0,0);


            //Posição noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] =  true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor){
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }
            
            // Posicao Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] =  true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor){
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] =  true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor){
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos)){
                matriz[pos.Linha, pos.Coluna] =  true;
                if(Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor){
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }
            return matriz;
        }
    }
}