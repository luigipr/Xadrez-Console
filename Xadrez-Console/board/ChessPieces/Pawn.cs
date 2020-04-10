﻿using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class Pawn : Piece {

        public Pawn(Board tab, Color color) : base(tab, color) { }

        public override string ToString() {
            return "P";
        }

        private bool ExistingOponent(Position pos) {
            Piece p = Tab.piece(pos);
            return p != null || p.Color != Color;
        }

        private bool free(Position pos) {
            return Tab.piece(pos) == null;
        }

        public override bool[,] possibleMovements() {
            bool[,] mat = new bool[Tab.Lines, Tab.Columns];
            Position pos = new Position(0, 0);

            if (Color == Color.White) {
                pos.defineValues(Position.lines - 1, Position.columns);
                if (Tab.ValidPosition(pos) && free(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines - 2, Position.columns);
                if (Tab.ValidPosition(pos) && free(pos) && MovementTimes == 0) {
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
            } else {
                pos.defineValues(Position.lines + 1, Position.columns);
                if (Tab.ValidPosition(pos) && free(pos)) {
                    mat[pos.lines, pos.columns] = true;
                }
                pos.defineValues(Position.lines + 2, Position.columns);
                if (Tab.ValidPosition(pos) && free(pos) && MovementTimes == 0) {
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
            }
            return mat;
        }
    }
}
