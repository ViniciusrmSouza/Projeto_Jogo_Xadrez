using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p == null || p.Cor != this.Cor;//verifica se casa n tem peça ou se a casa tem uma peça da cor diferente da cor da peça atual
        }

        //somente verifica os movimentos possiveis
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matMovP = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            return matMovP;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
