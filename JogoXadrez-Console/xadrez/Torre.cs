using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
