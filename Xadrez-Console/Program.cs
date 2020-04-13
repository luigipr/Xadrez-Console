using System;
using board;
using ChessPieces;

namespace Xadrez_Console {
    class Program {
        static void Main(string[] args) {

            try {
                ChessMatch match = new ChessMatch();
                while (!match.MatchFinish) {

                    try {
                        Console.Clear();
                        Screen.printMatch(match);
                        

                        Console.WriteLine();
                        Console.WriteLine("Instructions: Select the tile you want to move to match the");
                        Console.WriteLine("coordinates in the board. e.g.: b2 (lowercase letters only)");
                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readPosition().toPosition();
                        match.ValidatePositionOrigin(origin);



                        bool[,] possiblePositions = match.tab.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.tab, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.readPosition().toPosition();
                        match.ValidatePositionDestination(origin, destination);

                        match.PlayMaker(origin, destination);
                    }
                    catch (BoardException e) {
                        Console.WriteLine();
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Press enter to repeat the turn");
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.printMatch(match);

            }
            catch (BoardException e) {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }





        }
    }
}
  