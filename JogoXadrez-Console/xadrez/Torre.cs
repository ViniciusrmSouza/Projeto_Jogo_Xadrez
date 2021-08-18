using System;
using JogoXadrez_Console.tabuleiro;

namespace JogoXadrez_Console.xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tab) : base(cor, tab)
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

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Linha--;//verificando a posição acima
            }

            //baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Linha++;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Coluna++;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);//passando as posições da peça no tabuleiro

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matMovP[pos.Linha, pos.Coluna] = true;
                if (Tab.PegaPeca(pos) != null && Tab.PegaPeca(pos).Cor != this.Cor)//verifica se há peça no tabuleiro com a função de PegaPeca da classe tabuleiro e verifica se a peça tem as cores diferentes pq come a peça e para ela
                {
                    break;
                }

                pos.Coluna--;
            }

            return matMovP;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
