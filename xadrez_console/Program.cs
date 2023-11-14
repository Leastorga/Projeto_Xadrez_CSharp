﻿using System;
using tabuleiro;
using jogoDeXadrez;


namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();



                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {partida.turno} ");
                        Console.WriteLine($"Aguardando jogada: {partida.jogadorAtual}");


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                        partida.validarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine($"{e.Message}");
                        Console.Write("Para retornar a jogada aperte enter: ");
                        Console.ReadLine();

                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.Write($"{e.Message}");
            }
        }
    }
}