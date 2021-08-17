using System;
using System.Collections.Generic;
using System.Text;

namespace JogoXadrez_Console.tabuleiro
{
    class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string message) : base(message)
        {
        }
    }
}
