using System;
using System.Collections.Generic;
using System.Text;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        //transforma a posição do xadrez em posição da matriz
        public Posicao toPosition()//lembrar de alterar o toPosition para ToPosition seguindo as regras da OOP em c#
        {
            return new Posicao(8 - Linha, Coluna - 'a');//o caractere "a" é um numero inteiro
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
