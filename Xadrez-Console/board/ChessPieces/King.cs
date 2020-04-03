using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class King : Piece {

        public King(Board tab, Color color) : base (tab, color) { }

        public override string ToString() {
            return "K";
        }

    }
}
