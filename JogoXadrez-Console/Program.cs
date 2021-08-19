using System;
using JogoXadrez_Console.tabuleiro;
using JogoXadrez_Console.xadrez;
using System.Collections.Generic;

namespace JogoXadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();//limpar a tela
                        
                        Tela.ImprimirPartida(partida);

                        Console.Write("Digite a Origem: ");
                        Posicao origem = Tela.LerPosicao().toPosition();
                        partida.ValidaPosDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.Tab.PegaPeca(origem).MovimentosPossiveis();

                        Console.Clear();

                        Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Jogador atual: " + partida.JogadorAtual.ToString());

                        Console.Write("Digite o destino: ");
                        Posicao destino = Tela.LerPosicao().toPosition();
                        partida.ValidarPosDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.ImprimirPartida(partida);

            }
            catch (TabuleiroException tE)
            {
                Console.WriteLine(tE.Message);
            }
        }
    }
}
