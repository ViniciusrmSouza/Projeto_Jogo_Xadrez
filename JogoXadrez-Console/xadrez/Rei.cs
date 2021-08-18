using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p == null || p.Cor != this.Cor;//verifica se casa n tem peça ou se a casa tem uma peça da cor diferente da cor da peça atual
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matMovP = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //acima direita
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //acima esquerda
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //baixo 
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //baixo direita
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //baixo esquerda
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);//
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
            }

            return matMovP;
        }
    }
}
