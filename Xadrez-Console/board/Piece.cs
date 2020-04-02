using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class Piece {

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementTimes { get; protected set; }
        public Board Tab { get; protected set; }

        public Piece(Position position, Color color, Board tab) {
            Position = position;
            Color = color;
            Tab = tab;
            MovementTimes = 0;
        }
    }
}
