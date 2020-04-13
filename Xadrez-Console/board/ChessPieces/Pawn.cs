using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Pawn : Piece {

        private ChessMatch match;
        public Pawn(Board tab, Color color, ChessMatch match) : base(tab, color) {
            this.match = match;
        }

        public override string ToString() {
            return "P";
        }

        private bool ExistingOponent(Position pos) {
            Piece p = Tab.piece(pos);
            if (p == null) {
                return false;
            }
                if ( p.Color != Color) {
                return true;
            }
            return false;
        }

        private bool Free(Position pos) {
            return Tab.piece(pos) == null;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White) {
                pos.defineValues(Position.lines - 1, Position.columns);
                if (Tab.ValidPosition(pos) && Free(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines - 2, Position.columns);
                if (Tab.ValidPosition(pos) && Free(pos) && MovementTimes == 0) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines - 1, Position.columns - 1);
                if (Tab.ValidPosition(pos) && ExistingOponent(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines - 1, Position.columns + 1);
                if (Tab.ValidPosition(pos) && ExistingOponent(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                // #specialmove en passant
                if (Position.lines == 3) {
                    Position left = new Position(Position.lines, Position.columns - 1);
                    if (Tab.ValidPosition(left) && ExistingOponent(left) && Tab.piece(left) == match.EnPassantVulnerability) {
                        mat[left.lines - 1, left.columns] = true;
                    }
                    Position right = new Position(Position.lines, Position.columns + 1);
                    if (Tab.ValidPosition(right) && ExistingOponent(right) && Tab.piece(right) == match.EnPassantVulnerability) {
                        mat[right.lines - 1, right.columns] = true;
                    }
                }
            } else {
                pos.defineValues(Position.lines + 1, Position.columns);
                if (Tab.ValidPosition(pos) && Free(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines + 2, Position.columns);
                if (Tab.ValidPosition(pos) && Free(pos) && MovementTimes == 0) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines + 1, Position.columns - 1);
                if (Tab.ValidPosition(pos) && ExistingOponent(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines + 1, Position.columns + 1);
                if (Tab.ValidPosition(pos) && ExistingOponent(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                // #specialmove en passant
                if (Position.lines == 4) {
                    Position left = new Position(Position.lines, Position.columns - 1);
                    if (Tab.ValidPosition(left) && ExistingOponent(left) && Tab.piece(left) == match.EnPassantVulnerability) {
                        mat[left.lines + 1, left.columns] = true;
                    }
                    Position right = new Position(Position.lines, Position.columns + 1);
                    if (Tab.ValidPosition(right) && ExistingOponent(right) && Tab.piece(right) == match.EnPassantVulnerability) {
                        mat[right.lines + 1, right.columns] = true;
                    }
                }
            }
            return mat;
        }
    }
}
