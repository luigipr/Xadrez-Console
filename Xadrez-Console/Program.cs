using System;
using board;
using ChessPieces;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {
                Board tab = new Board(8, 8);

                tab.dropPiece(new Tower(tab, Color.Black), new Position(0, 0));
                tab.dropPiece(new Tower(tab, Color.Black), new Position(1, 6));
                tab.dropPiece(new King(tab, Color.Black), new Position(2, 4));
                tab.dropPiece(new King(tab, Color.Black), new Position(0, 2));
                tab.dropPiece(new Tower(tab, Color.White), new Position(3, 5));
                tab.dropPiece(new Tower(tab, Color.White), new Position(1, 1));



                Screen.printBoard(tab);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }





        }
    }
}
  