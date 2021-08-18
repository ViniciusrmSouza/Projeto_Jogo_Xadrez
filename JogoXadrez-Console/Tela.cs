using System;
using JogoXadrez_Console.tabuleiro;
using JogoXadrez_Console.xadrez;
namespace JogoXadrez_Console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.PegaPeca(i, j) != null)
                    {
                        ImprimirPeca(tab.PegaPeca(i, j)); //pritando tostring da peça que esta na posição da matriz
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static PosicaoXadrez LerPosicao()//metodo para ler a posição
        {
            string lerP = Console.ReadLine();
            //pegando o indice do string e passando para char e int
            char coluna = lerP[0];
            int linha = int.Parse(lerP[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
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
        }
    }
}
