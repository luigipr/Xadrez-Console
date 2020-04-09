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
                        Console.Write("Origem: ");
                        Position origin = Screen.readPosition().toPosition();
                        match.ValidatePositionOrigin(origin);



                        bool[,] possiblePositions = match.tab.piece(origin).possibleMovements();

                        Console.Clear();
                        Screen.printBoard(match.tab, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
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
                
                Screen.printBoard(match.tab);
            }
            catch (BoardException e) {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }





        }
    }
}
  