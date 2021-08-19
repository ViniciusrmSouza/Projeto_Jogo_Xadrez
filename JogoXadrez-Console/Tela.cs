using System;
using System.Collections.Generic;
using JogoXadrez_Console.tabuleiro;
using JogoXadrez_Console.xadrez;

namespace JogoXadrez_Console
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            Console.WriteLine("Jogador atual: " + partida.JogadorAtual.ToString());
            if(partida.Xeque == true)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor corAtual = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = corAtual;
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjuntoPecas)
        {
            Console.Write("[");
            foreach (Peca pecaCap in conjuntoPecas)
            {
                Console.Write(pecaCap + "");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    //pritando tostring da peça que esta na posição da matriz
                    ImprimirPeca(tab.PegaPeca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoAtual = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.White;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    //pintando o fundo nas posições onde é possivel mover a peça
                    if (posicoesPossiveis[i, j] == true)
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoAtual;
                    }
                    //pritando tostring da peça que esta na posição da matriz
                    ImprimirPeca(tab.PegaPeca(i, j));
                    Console.BackgroundColor = fundoAtual;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoAtual;
        }

        public static PosicaoXadrez LerPosicao()//metodo para ler a posição
        {
            string lerP = Console.ReadLine();
            //pegando o indice do string e passando para char e int
            char coluna = lerP[0];
            int linha = int.Parse(lerP[1] + "");
            return new PosicaoXadrez(coluna, linha);//retorna um objeto do tipo PosicaoXadrez
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca != null)
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor corPadrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(peca);
                    Console.ForegroundColor = corPadrao;
                }
                Console.Write(" ");
            }
            else
            {
                Console.Write("- ");
            }
        }
    }
}
