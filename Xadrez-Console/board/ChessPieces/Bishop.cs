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

        private bool CanMove(Position pos) {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);
            //NO
            pos.defineValues(Position.lines - 1, Position.columns - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.lines - 1, pos.columns - 1);
            }
            //NE
            pos.defineValues(Position.lines - 1, Position.columns + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.lines - 1, pos.columns + 1);
            }
            //SO
            pos.defineValues(Position.lines + 1, Position.columns -1);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.lines + 1, pos.columns - 1);
            }
            //SE
            pos.defineValues(Position.lines + 1, Position.columns + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.defineValues(pos.lines + 1, pos.columns + 1);
            }

                return mat;
        }
    }
}
