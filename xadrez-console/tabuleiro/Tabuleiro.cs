using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabuleiro;

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
        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.linha<0 || posicao.linha>=linhas || posicao.coluna<0 || posicao.coluna >= colunas)
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
