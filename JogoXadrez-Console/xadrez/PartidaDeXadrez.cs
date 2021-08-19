using System;
using JogoXadrez_Console.tabuleiro;
namespace JogoXadrez_Console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);//tabuleiro que vai ser passado para a classe Tela
            Turno = 1;
            JogadorAtual = Cor.Branca;
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

        //controla o turno e a vez da jogada
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            MovimentaPeca(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidaPosDeOrigem(Posicao pos)
        {
            if (Tab.PegaPeca(pos) == null)
            {
                throw new TabuleiroException("Posição vazia");
            }
            if(JogadorAtual != Tab.PegaPeca(pos).Cor)
            {
                throw new TabuleiroException("Peça selecionada da cor errada");
            }
            if (!Tab.PegaPeca(pos).PodeMover())
            {
                throw new TabuleiroException("Essa peça não possui espaço de movimentação");
            }
        }

        public void ValidarPosDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.PegaPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        private void MudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
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
