using System;
using board;
using ChessPieces;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {


            Board tab = new Board(8, 8);

            tab.dropPiece(new Tower(tab, Color.Black) , new Position(0, 0));
            tab.dropPiece(new Tower(tab, Color.Black) , new Position(1, 3));
            tab.dropPiece(new King(tab, Color.Black) , new Position(2, 4));
            


            Screen.printBoard(tab);




        }
    }
}
  