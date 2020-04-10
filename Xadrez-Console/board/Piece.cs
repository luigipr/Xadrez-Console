using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    abstract class Piece {

        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MovementTimes { get; protected set; }
        public Board Tab { get; protected set; }

        public Piece(Board tab, Color color) {
            Position = null;
            Tab = tab;
            this.Color = color;            
            MovementTimes = 0;
        }

         public void MovementIncrease() {
            MovementTimes++;
        }

        public void MovementDecrease() {
            MovementTimes--;
        }

        public bool ExistingPossibleMovements() {
            bool[,] mat = possibleMovements();
            for (int i=0; i<Tab.Lines; i++) {
                for (int j=0; j<Tab.Columns; j++) {
                    if (mat[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos) {
            return possibleMovements()[pos.lines, pos.columns];
        }

        public abstract bool[,] possibleMovements();

    }
}
