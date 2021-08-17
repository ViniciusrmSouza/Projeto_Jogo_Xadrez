using System;
using System.Collections.Generic;
using System.Text;

namespace JogoXadrez_Console.tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] _pecas;

        public Tabuleiro()
        {
        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _pecas = new Peca[linhas, colunas];
        }

        //metodo para pegar a peça na matriz de peças
        public Peca PegaPeca(int linha, int coluna)
        {
            return _pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            //adicionar a peça na posição
            _pecas[pos.Linha, pos.Coluna] = p;//nova peça nessa posição
            p.Posicao = pos;//adiciando a posição na classe peça
        }
    }
}
