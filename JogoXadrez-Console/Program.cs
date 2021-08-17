using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8,8);
            Tela.ImprimirTabuleiro(tab);
        }
    }
}
