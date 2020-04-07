using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace Xadrez_Console {
    class Screen {
        public static void printBoard(Board tab) {
            for (int i=0; i<tab.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<tab.Columns; j++) {
                    if (tab.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        PrintPiece(tab.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void PrintPiece(Piece piece) {
            if (piece.Color == Color.White) {
                Console.Write(piece);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }


        }






    }
}
