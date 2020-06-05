using System;
using System.Collections.Generic;
using System.Text;
using board;
using ChessPieces;
using System.Linq;

namespace Xadrez_Console {
    class Screen {

        public static void printMatch(ChessMatch match) {
            printBoard(match.tab);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            if (!match.MatchFinish) {
                Console.WriteLine("Waiting play from: " + match.CurrentPlayer);
                if (match.Check) {
                    Console.WriteLine("You're on check!");
                }
            } else {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }
        }

        public static void printCapturedPieces(ChessMatch match) {
            Console.WriteLine("Caught Pieces:");
            Console.Write("Whites: ");
            printSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Blacks: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set) {
            Console.Write("[");
            foreach (Piece p in set) {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }


        public static void printBoard(Board tab) {
            for (int i=0; i<tab.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j=0; j<tab.Columns; j++) {
                    PrintPiece(tab.piece(i, j));                   
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
        }

        public static void printBoard(Board tab, bool[,] possiblePositions) {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;
            
            for (int i = 0; i < tab.Lines; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Columns; j++) {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = alteredBackground;
                    } else {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(tab.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h ");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            if (char.IsUpper(column))
            {
                throw new BoardException("There is no available piece on this position!");
            }
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        private static bool isUpper(char column)
        {
            throw new NotImplementedException();
        }

        public static void PrintPiece(Piece piece) {

            if (piece == null) {
                Console.Write("- ");
            }
            else {
                if (piece.Color == Color.White) {
                    Console.Write(piece);
                }
                else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }




    }
}
