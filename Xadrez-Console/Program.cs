using System;
using board;
using ChessPieces;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {
                ChessMatch match = new ChessMatch();
                while (!match.MatchFinish) {
                    Console.Clear();
                    Screen.printBoard(match.tab);
                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Position origin = Screen.readPosition().toPosition();
                    Console.Write("Destino: ");
                    Position destination = Screen.readPosition().toPosition();

                    match.MovementExecuter(origin, destination);
                }
                
                Screen.printBoard(match.tab);
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }





        }
    }
}
  