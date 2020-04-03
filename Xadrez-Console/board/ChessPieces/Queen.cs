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

    }
}
