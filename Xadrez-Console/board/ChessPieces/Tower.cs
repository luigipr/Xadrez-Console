using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Tower : Piece {

        public Tower(Board tab, Color color) : base(tab, color) { }

        public override string ToString() {
            return "T";
        }

    }
}
