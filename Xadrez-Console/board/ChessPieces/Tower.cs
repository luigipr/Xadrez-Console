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

        private bool CanMove(Position pos) {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);
            //N
            pos.defineValues(Position.lines - 1, Position.columns);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.lines = pos.lines - 1;
            }
            //S
            pos.defineValues(Position.lines + 1, Position.columns);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.lines = pos.lines + 1;
            }
            //R
            pos.defineValues(Position.lines, Position.columns + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.columns = pos.columns + 1;
            }
            //L
            pos.defineValues(Position.lines, Position.columns - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos)) {
                mat[pos.lines, pos.columns] = true;
                if (Tab.piece(pos) != null && Tab.piece(pos).Color != Color) {
                    break;
                }
                pos.columns = pos.columns - 1;
            }
            return mat;
        }

        }
    }
