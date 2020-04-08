using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class Piece {

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementTimes { get; protected set; }
        public Board Tab { get; protected set; }

        public Piece(Board tab, Color color) {
            Position = null;
            Tab = tab;
            Color = color;            
            MovementTimes = 0;
        }

         public void MovementIncrease() {
            MovementTimes++;
        }

    }
}
