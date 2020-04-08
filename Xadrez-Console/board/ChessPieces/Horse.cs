using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Horse : Piece {

        public Horse(Board tab, Color color) : base(tab, color) { }

        public override string ToString() {
            return "H";
        }



        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            return mat;
        }
    }
}
