using System;
using System.Collections.Generic;
using JogoXadrez_Console.tabuleiro;
using JogoXadrez_Console.xadrez;

namespace JogoXadrez_Console.xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        private HashSet<Peca> _pecas;
        private HashSet<Peca> _capturadas;
        public bool Xeque { get; private set; }
        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);//tabuleiro que vai ser passado para a classe Tela
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Xeque = false;
            _pecas = new HashSet<Peca>();
            _capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
        }

        public Peca MovimentaPeca(Posicao origem, Posicao destino)
        {
            Peca peca = Tab.RemoverPeca(origem);//pega a peça que sera movida
            peca.IncrementaQteMovimentos();
            Peca pecaCapturada = Tab.RemoverPeca(destino); //caso haja peça sera removida caso não será null
            Tab.ColocarPeca(peca, destino);//coloca a peça na posição

            //passando para o conjunto a peça que foi pega
            if (pecaCapturada != null)
            {
                _capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RemoverPeca(destino);
            p.DecrementarQteMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                _capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        //controla o turno e a vez da jogada
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = MovimentaPeca(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque");
            }
            if (EstaEmXeque(PecaAdversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (Xequemate(PecaAdversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
        }

        public void ValidaPosDeOrigem(Posicao pos)
        {
            if (Tab.PegaPeca(pos) == null)
            {
                throw new TabuleiroException("Posição vazia");
            }
            if (JogadorAtual != Tab.PegaPeca(pos).Cor)
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
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        //retorna as peças capturadas de acordo com sua cor
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca pecasC in _capturadas)
            {
                if (pecasC.Cor == cor)
                {
                    aux.Add(pecasC);
                }
            }
            return aux;
        }

        //retorna as peças em jogo de acordo com sua cor
        public HashSet<Peca> PecasEmJogo(Cor cor)//verifica as peças em jogo dada a sua cor
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca pecaJ in _pecas)
            {
                if (pecaJ.Cor == cor)
                {
                    aux.Add(pecaJ);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));//remove todas as peças que foram capturadas para ficar somente as que estão em jogo
            return aux;
        }

        //verifica a peça adversaria pela cor
        private Cor PecaAdversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            return Cor.Branca;//
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca pecaR in PecasEmJogo(cor))
            {
                //o "is" verifica se a super classe é uma instancia de uma sub-classe(downcasting)
                if (pecaR is Rei)
                {
                    return pecaR;
                }

            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            if (rei == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca pX in PecasEmJogo(PecaAdversaria(cor)))
            {
                bool[,] movPecas = pX.MovimentosPossiveis();

                if (movPecas[rei.Posicao.Linha, rei.Posicao.Coluna])//se algum dos movimentos possiveis das peças puder comer a peça do rei vai dar xeque
                {
                    return true;
                }
            }
            return false;
        }

        public bool Xequemate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca pecaX in PecasEmJogo(cor))
            {
                bool[,] movP = pecaX.MovimentosPossiveis();

                //verificando todos os movimentos possiveis de uma certa peça
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (movP[i, j] == true)
                        {
                            Posicao origem = pecaX.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = MovimentaPeca(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosition());
            _pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            //upcasting
            //Pretas
            ColocarNovaPeca('b', 8, new Torre(Cor.Preta, Tab));
            ColocarNovaPeca('a', 8, new Rei(Cor.Preta, Tab));

            //Brancas
            ColocarNovaPeca('h', 7, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tab));
        }
    }
}
