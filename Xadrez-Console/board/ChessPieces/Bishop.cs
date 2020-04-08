using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Bishop : Piece {

        public Bishop(Board tab, Color color) : base(tab, color) { }

        public override string ToString() {
            return "B";
        }




        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            return mat;
        }
    }
}
