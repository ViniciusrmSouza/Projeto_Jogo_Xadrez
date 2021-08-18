using System;
using System.Collections.Generic;
using System.Text;

namespace JogoXadrez_Console.tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca()
        {
        }
        public Peca(Cor cor, Tabuleiro tab)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QteMovimentos = 0;
        }
        //é possivel utilizar de metodo e classe abstratada pois a peça sempre é instanciada com upcasting(rei,torre,peão...)
        public abstract bool[,] MovimentosPossiveis();
        public void IncrementaQteMovimentos()
        {
            QteMovimentos++;
        }
    }
}
