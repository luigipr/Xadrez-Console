﻿using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class ChessMatch {

        public Board tab { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchFinish { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool Check { get; private set; }


        public ChessMatch() {
            tab = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PieceDropper();
            MatchFinish = false;
            Check = false;
        }

        public Piece MovementExecuter(Position origin, Position destination) {
            Piece p = tab.RemovePiece(origin);
            p.MovementIncrease();
            Piece capturedPiece = tab.RemovePiece(destination);
            tab.dropPiece(p, destination);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
            // #specialplay small castling
            if (p is King && destination.columns == origin.columns + 2) {
                Position Torigin = new Position(origin.lines, origin.columns + 3);
                Position Tdestination = new Position(origin.lines, origin.columns + 1);
                Piece T = tab.RemovePiece(Torigin);
                tab.dropPiece(T, Tdestination);
            }
            // #specialplay large castling
            if (p is King && destination.columns == origin.columns - 2) {
                Position Torigin = new Position(origin.lines, origin.columns - 4);
                Position Tdestination = new Position(origin.lines, origin.columns - 1);
                Piece T = tab.RemovePiece(Torigin);
                tab.dropPiece(T, Tdestination);
            }
            return capturedPiece;
        }

        public void PlayMaker(Position origin, Position destination) {
            Piece capturedPiece = MovementExecuter(origin, destination);

            if (CheckCkecker(CurrentPlayer)) {
                undoMovement(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself on check!");
            }
            if (CheckCkecker(Oponent(CurrentPlayer))) {
                Check = true;
            } else {
                Check = false;
            }
            if (CheckmateTest(Oponent(CurrentPlayer))) {
                MatchFinish = true;
            }
            else {
                Turn++;
                ChangePlayer();
            }
        }

        public void undoMovement(Position origin, Position destination, Piece capturedPiece) {
            Piece p = tab.RemovePiece(destination);
            p.MovementDecrease();
            if (capturedPiece != null) {
                tab.dropPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            // #specialplay small castling
            if (p is King && destination.columns == origin.columns + 2) {
                Position Torigin = new Position(origin.lines, origin.columns + 3);
                Position Tdestination = new Position(origin.lines, origin.columns + 1);
                Piece T = tab.RemovePiece(Tdestination );
                T.MovementDecrease();
                tab.dropPiece(T, Torigin);
            }
            // #specialplay large castling
            if (p is King && destination.columns == origin.columns - 2) {
                Position Torigin = new Position(origin.lines, origin.columns - 4);
                Position Tdestination = new Position(origin.lines, origin.columns - 1);
                Piece T = tab.RemovePiece(Tdestination);
                T.MovementDecrease();
                tab.dropPiece(T, Torigin);
            }
            tab.dropPiece(p, origin);
        }


        public void ValidatePositionOrigin(Position pos) {
            if (tab.piece(pos) == null) {
                throw new BoardException("There is no available piece on this position!");
            }
            if (CurrentPlayer != tab.piece(pos).Color) {
                throw new BoardException("This piece does not belong to you!");
            }
            if (!tab.piece(pos).ExistingPossibleMovements()) {
                throw new BoardException("There is no movements available for the chosen piece!");
            }

        }

        public void ValidatePositionDestination(Position origin, Position destination) {
            if (!tab.piece(origin).CanMoveTo(destination)) {
                throw new BoardException("Invalid target for piece movement!");
            }
        }


        private void ChangePlayer() {
            if (CurrentPlayer == Color.White) {
                CurrentPlayer = Color.Black;
            } else {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in captured) {
                if (p.Color == color) {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces) {
                if (p.Color == color) {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Oponent(Color color) {
            if (color == Color.White) {
                return Color.Black;
            } else { return Color.White; }
        }

        private Piece king (Color color) {
            foreach (Piece p in PiecesInGame(color)) {
                if (p is King) {
                    return p;
                }
            }
            return null;
        }

        public bool CheckCkecker(Color color) {
            Piece K = king(color);
            if (K == null) {
                throw new BoardException("There is no king of the assigned color on the board!");
            }
            foreach (Piece p in PiecesInGame(Oponent(color))) {
                bool[,] mat = p.possibleMovements();
                if (mat[K.Position.lines, K.Position.columns]) {
                    return true;
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color) {
            if (!CheckCkecker(color)) {
                return false;
            }
            foreach (Piece p in PiecesInGame(color)) {
                bool[,] mat = p.possibleMovements();
                for (int i = 0; i<tab.Lines; i++) {
                    for (int j=0; j<tab.Columns; j++) {
                        if (mat[i,j]) {
                            Position origin = p.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = MovementExecuter(origin, destination);
                            bool checktest = CheckCkecker(color);
                            undoMovement(origin, destination, capturedPiece);
                            if (!checktest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void NewPiecePlacer(char column, int line, Piece piece) {
            tab.dropPiece(piece, new ChessPosition(column, line).toPosition());
            pieces.Add(piece);
        }

        private void PieceDropper() {
            NewPiecePlacer('a', 1, new Tower(tab, Color.White));
            NewPiecePlacer('b', 1, new Horse(tab, Color.White));
            NewPiecePlacer('c', 1, new Bishop(tab, Color.White));
            NewPiecePlacer('d', 1, new Queen(tab, Color.White));
            NewPiecePlacer('e', 1, new King(tab, Color.White, this));
            NewPiecePlacer('f', 1, new Bishop(tab, Color.White));
            NewPiecePlacer('g', 1, new Horse(tab, Color.White));
            NewPiecePlacer('h', 1, new Tower(tab, Color.White));
            NewPiecePlacer('a', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('b', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('c', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('d', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('e', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('f', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('g', 2, new Pawn(tab, Color.White));
            NewPiecePlacer('h', 2, new Pawn(tab, Color.White));


            NewPiecePlacer('a', 8, new Tower(tab, Color.Black));
            NewPiecePlacer('b', 8, new Horse(tab, Color.Black));
            NewPiecePlacer('c', 8, new Bishop(tab, Color.Black));
            NewPiecePlacer('d', 8, new Queen(tab, Color.Black));
            NewPiecePlacer('e', 8, new King(tab, Color.Black, this));
            NewPiecePlacer('f', 8, new Bishop(tab, Color.Black));
            NewPiecePlacer('g', 8, new Horse(tab, Color.Black));
            NewPiecePlacer('h', 8, new Tower(tab, Color.Black));
            NewPiecePlacer('a', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('b', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('c', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('d', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('e', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('f', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('g', 7, new Pawn(tab, Color.Black));
            NewPiecePlacer('h', 7, new Pawn(tab, Color.Black));
        }

    }
}
