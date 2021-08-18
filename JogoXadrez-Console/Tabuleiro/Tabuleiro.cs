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

        public Peca PegaPeca(Posicao pos)
        {
            return _pecas[pos.Linha, pos.Coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (existePeca(pos))//verifica se tem alguma peça na posição informada
            {
                throw new TabuleiroException("Já existe peça nessa posição");
            }
            //adicionar a peça na posição
            _pecas[pos.Linha, pos.Coluna] = p;//nova peça nessa posição
            p.Posicao = pos;//adiciando a posição na classe peça
        }
        public Peca RemoverPeca(Posicao pos)
        {
            if (PegaPeca(pos) == null)
            {
                return null;
            }
            //removendo a peça de sua posição
            Peca pecaRetirada = PegaPeca(pos);
            pecaRetirada.Posicao = null;
            _pecas[pos.Linha, pos.Coluna] = null;

            return pecaRetirada;
        }

        //Exceptions
        public bool PosicaoValida(Posicao pos)//metodo para verificar onde foi colocado a peça caso seja fora dos limites retorna false
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)//metodo para verificar onde foi colocado a peça caso seja fora dos limites mostra a exceção
        {
            if (!PosicaoValida(pos))//verificando se é false
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
        public bool existePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return PegaPeca(pos) != null;
        }
    }
}
