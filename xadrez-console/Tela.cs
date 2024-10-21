using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez_console.tabuleiro;
using xadrez;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace xadrez_console
{
    internal class Tela
    {

        //imprimir partida
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine(); 
            Console.WriteLine("Turno: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguarndando jogada " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);

            }
        }
        //imprimir pecas capturadas
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write("Vermelhas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preto));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }
        //imprimirconjunto
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine("        TABULEIRO    ");
            Console.WriteLine("  +-----------------+");

            //Tabuleiro: 

            for (int i=0; i<tab.linhas; i++)
            {
                Console.Write(8 - i + " | ");
                for (int j=0; j<tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i,j));
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  +-----------------+");
            Console.WriteLine("    A B C D E F G H ");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            Console.WriteLine("        TABULEIRO    ");
            Console.WriteLine("  +-----------------+");

            //Tabuleiro: 
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " | ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  +-----------------+");
            Console.WriteLine("    A B C D E F G H ");
            Console.BackgroundColor = fundoOriginal;
        }



        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "  ");
            return new PosicaoXadrez(coluna, linha);

        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}