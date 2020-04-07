using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class Board {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns) {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column) {
            return Pieces[line, column];
        }

        public Piece piece(Position pos) {
            return Pieces[pos.lines, pos.columns];
                }

        public bool ExistingPiece(Position pos) {
            ValidatePosition(pos);
            return piece(pos) != null;
        }

        public void dropPiece(Piece p, Position pos) {
            if (ExistingPiece(pos)) {
                throw new BoardException("There is already a piece in this position!");
            }
            Pieces[pos.lines, pos.columns] = p;
            p.Position = pos;
        }

        public bool ValidPosition(Position pos) {
            if (pos.lines < 0 || pos.lines >= Lines || pos.columns < 0 || pos.columns >= Columns) {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position pos) {
            if (!ValidPosition(pos)) {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
