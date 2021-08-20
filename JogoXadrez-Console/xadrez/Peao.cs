using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p == null || p.Cor != this.Cor;//verifica se casa n tem peça ou se a casa tem uma peça da cor diferente da cor da peça atual
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.PegaPeca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.PegaPeca(pos) == null;
        }

        //somente verifica os movimentos possiveis
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matMovP = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //peãos brancos
            if (Cor == Cor.Branca)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }

                //inicio
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }

                //Comer peça
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);//
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }

                //inicio
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }

                //Comer peça
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);//
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    matMovP[pos.Linha, pos.Coluna] = true;
                }
            }

            return matMovP;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
