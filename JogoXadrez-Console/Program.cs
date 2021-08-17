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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));//upcasting
                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(0, 0));
                Tela.ImprimirTabuleiro(tab);
            }
            catch (TabuleiroException tE)
            {
                Console.WriteLine(tE.Message);
            }


        }
    }
}
