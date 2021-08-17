using System;
using JogoXadrez_Console.tabuleiro;
using JogoXadrez_Console.xadrez;

namespace JogoXadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('a',1);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosition());
        }
    }
}
