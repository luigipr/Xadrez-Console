using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Pawn : Piece {

        public Pawn(Board tab, Color color) : base(tab, color) { }

        public override string ToString() {
            return "P";
        }





        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            return mat;
        }
    }
}
