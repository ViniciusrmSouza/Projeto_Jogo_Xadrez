using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base (cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
