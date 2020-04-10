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

        private bool CanMove(Position pos) {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);
            pos.defineValues(Position.lines - 1, Position.columns - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines - 2, Position.columns - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines - 2, Position.columns + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines - 1, Position.columns + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines + 1, Position.columns + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines + 2, Position.columns + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines + 2, Position.columns - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            pos.defineValues(Position.lines + 1, Position.columns - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            return mat;
        }
    }
}
