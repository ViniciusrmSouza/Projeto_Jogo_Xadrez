using System;
using JogoXadrez_Console.tabuleiro;
using JogoXadrez_Console.xadrez;

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
                    Console.Clear();//limpar a tela
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.Write("Digite a Origem: ");
                    Posicao origem = Tela.LerPosicao().toPosition();

                    bool[,] posicoesPossiveis = partida.Tab.PegaPeca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab,posicoesPossiveis);

                    Console.Write("Digite a Origem: ");
                    Posicao destino = Tela.LerPosicao().toPosition();
                    
                    partida.MovimentaPeca(origem, destino);
                }

            }
            catch (TabuleiroException tE)
            {
                Console.WriteLine(tE.Message);
            }
        }
    }
}
