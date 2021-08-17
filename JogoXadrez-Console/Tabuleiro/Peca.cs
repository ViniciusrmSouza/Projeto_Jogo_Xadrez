using System;
using System.Collections.Generic;
using System.Text;

namespace JogoXadrez_Console.tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }
        
        public Peca()
        {

        }
        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            this.cor = cor;
            Tab = tab;
            qteMovimentos = 0;
        }
    }
}
