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



    }
}
