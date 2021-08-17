using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for(int i = 0; i < tab.Linhas; i++)
            {
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.PegaPeca(i,j) != null)
                    {
                        Console.Write(tab.PegaPeca(i,j));//pritando tostrring da peça que esta na posição da matriz
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
