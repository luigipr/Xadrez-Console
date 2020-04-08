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
        
        private bool CanMove(Position pos) {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);
            //N
            pos.defineValues(Position.lines - 1, Position.columns);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //NE
            pos.defineValues(Position.lines - 1, Position.columns + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //R
            pos.defineValues(Position.lines, Position.columns + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //SE
            pos.defineValues(Position.lines + 1, Position.columns + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //S
            pos.defineValues(Position.lines + 1, Position.columns);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //SW
            pos.defineValues(Position.lines + 1, Position.columns - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //L
            pos.defineValues(Position.lines, Position.columns - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            //NW
            pos.defineValues(Position.lines - 1, Position.columns - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
            }
            return mat;
        }

    }
}
