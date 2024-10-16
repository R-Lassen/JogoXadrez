using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public char coluna {  get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }
        
        //transformando o comando do xadres (a1) para o comando interno da matriz
        public Posicao ToPosicao()
        {
            return new Posicao( 8 - linha, coluna - 'a');
        }

        public override string ToString()
        {
            var s = "" + coluna.ToString() + linha.ToString();
            return ("" + coluna.ToString() + linha.ToString());
        }
    }
}
