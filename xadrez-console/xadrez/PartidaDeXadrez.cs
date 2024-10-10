﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;
using tabuleiro;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada {  get; private set; }


        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }
        //
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
         //   Peca.pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

        }

        private void colocarPecas()
        {
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());

            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Preto), new PosicaoXadrez('e', 7).ToPosicao());
           

        }
    }
}