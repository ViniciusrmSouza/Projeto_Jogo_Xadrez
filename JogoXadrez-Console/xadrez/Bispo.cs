using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
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

            //acima direita
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                //ta dando algum bug no metodo do DefinirValores
                pos.Linha--;
                pos.Coluna++;
            }

            //acima esquerda
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Linha--;
                pos.Coluna--;
            }

            //baixo direita
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Linha++;
                pos.Coluna++;
            }

            //baixo esquerda
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Linha++;
                pos.Coluna--;
            }

            return matMovP;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
