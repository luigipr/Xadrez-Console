using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace Xadrez_Console {
    class Screen {
        public static void printBoard(Board tab) {
            for (int i=0; i<tab.Lines; i++) {
                for (int j=0; j<tab.Columns; j++) {
                    if (tab.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tab.piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }


        }








    }
}
