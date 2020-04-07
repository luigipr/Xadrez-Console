using System;
using board;
using ChessPieces;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            ChessPosition pos = new ChessPosition('c', 7);


            Console.WriteLine(pos);


            Console.WriteLine(pos.toPosition());




        }
    }
}
  