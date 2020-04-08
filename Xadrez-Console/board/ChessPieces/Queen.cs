using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Queen : Piece {

        public Queen(Board tab, Color color) : base(tab, color) { }

        public override string ToString() {
            return "Q";
        }


        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            return mat;
        }






        }
}
