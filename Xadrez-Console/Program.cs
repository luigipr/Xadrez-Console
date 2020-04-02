using System;
using board;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {


            Board tab = new Board(8, 8);
            Screen.printBoard(tab);




        }
    }
}
