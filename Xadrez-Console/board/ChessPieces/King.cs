using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class King : Piece {

        private ChessMatch match;
        public King(Board tab, Color color, ChessMatch match) : base (tab, color) {
            this.match = match;
        }

        public override string ToString() {
            return "K";
        }
        
        private bool CanMove(Position pos) {
            Piece p = Tab.piece(pos);
            return p == null || p.Color != Color;
        }

        private bool castlingTest(Position pos) {
            Piece p = Tab.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.MovementTimes == 0;
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
            // #specialmove castling
            if (MovementTimes ==0 && !match.Check) {
                // small castling
                Position postowersmall = new Position(Position.lines, Position.columns + 3);
                if (castlingTest(postowersmall)) {
                    Position p1 = new Position(Position.lines, Position.columns + 1);
                    Position p2 = new Position(Position.lines, Position.columns + 2);
                    if (Tab.piece(p1)==null && Tab.piece(p2)==null) {
                        mat[Position.lines, Position.columns + 2] = true;
                    }
                }
                // large castling
                Position postowerlarge = new Position(Position.lines, Position.columns - 4);
                if (castlingTest(postowerlarge)) {
                    Position p1 = new Position(Position.lines, Position.columns - 1);
                    Position p2 = new Position(Position.lines, Position.columns - 2);
                    Position p3 = new Position(Position.lines, Position.columns - 3);
                    if (Tab.piece(p1) == null && Tab.piece(p2) == null && Tab.piece(p3)==null) {
                        mat[Position.lines, Position.columns - 2] = true;
                    }
                }
            }
            return mat;
        }

    }
}
