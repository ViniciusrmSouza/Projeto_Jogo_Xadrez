using System;
using JogoXadrez_Console.tabuleiro;
namespace JogoXadrez_Console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        private int _turno;
        private Cor _jogadorAtual;
        public bool Terminada { get; private set; }
        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);//tabuleiro que vai ser passado para a classe Tela
            _turno = 1;
            _jogadorAtual = Cor.Branca;
            ColocarPecas();
            Terminada = false;
        }

        public void MovimentaPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tab.RemoverPeca(origem);//pega a peça que sera movida
            peca.IncrementaQteMovimentos();
            Peca pecaCapturada = Tab.RemoverPeca(destino); //caso haja peça sera removida caso não será null
            Tab.ColocarPeca(peca, destino);//coloca a peça na posição
        }

        private void ColocarPecas()
        {
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('a', 8).toPosition());//upcasting
            Tab.ColocarPeca(new Torre(Cor.Preta, Tab), new PosicaoXadrez('h', 8).toPosition());//upcasting
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('a', 1).toPosition());//upcasting
            Tab.ColocarPeca(new Torre(Cor.Branca, Tab), new PosicaoXadrez('h', 1).toPosition());//upcasting
            Tab.ColocarPeca(new Rei(Cor.Preta, Tab), new PosicaoXadrez('d', 8).toPosition());//upcasting
            Tab.ColocarPeca(new Rei(Cor.Branca, Tab), new PosicaoXadrez('d', 1).toPosition());//upcasting
        }
    }
}
