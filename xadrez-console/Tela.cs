﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez_console.tabuleiro;
using xadrez;


namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            Console.WriteLine("        TABULEIRO    ");
            Console.WriteLine("  +-----------------+");

            //Tabuleiro: 

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " | ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(i, j));

                        Console.Write(" ");

                    }

                }
                Console.WriteLine("|");
                
            }
            Console.WriteLine("  +-----------------+");
            Console.WriteLine("    A B C D E F G H ");
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);

        }

        public static void imprimirPeca(Peca peca)
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

        }
    }
}
