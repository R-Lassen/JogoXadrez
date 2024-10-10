using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preto), new Posicao(0, 0));
                tab.colocarPeca(new Rei(tab, Cor.Preto), new Posicao(1, 3));

                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(0, 2));
                tab.colocarPeca(new Rei(tab, Cor.Branca), new Posicao(3, 5));

                Tela.imprimirTabuleiro(tab);

                Console.Read();
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosicao().ToString());

            Console.ReadLine();
        }
    }
}
