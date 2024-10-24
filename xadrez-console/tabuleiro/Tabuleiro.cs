﻿using xadrez_console.tabuleiro;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas {  get; set; }   
        public int colunas { get; set; }
        private Peca[,] pecas;
        
        //construtor:
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca [linhas, colunas];
        }

        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca (Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }
        
        //colocar peca
        public void colocarPeca(Peca p, Posicao pos)
        {
            // tratamento de excessao
            if (existePeca(pos)) { 
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
            if (peca(pos) == null)
            {
                return null;
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.linha, pos.coluna] = null;
            return aux;
            
        }

        //testando se a posição é valida:
        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha<0 || pos.linha>=linhas || pos.coluna<0 || pos.coluna >= colunas)
            {
                return false;

            }
            return true;
        }
        
        //validando a posição
        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Inválida");
            }
        }
    }
}
