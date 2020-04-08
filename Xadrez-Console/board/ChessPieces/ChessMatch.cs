using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class ChessMatch {

        public Board tab { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool MatchFinish { get; private set; }

        public ChessMatch() {
            tab = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            PieceDropper();
            MatchFinish = false;
        }

        public void MovementExecuter(Position origin, Position destination) {
            Piece p = tab.RemovePiece(origin);
            p.MovementIncrease();
            Piece capturedPiece = tab.RemovePiece(destination);
            tab.dropPiece(p, destination);

        }

        public void PlayMaker(Position origin, Position destination) {
            MovementExecuter(origin, destination);
            Turn++;
            ChangePlayer();
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


        private void PieceDropper() {
            tab.dropPiece(new Tower(tab, Color.White), new ChessPosition('c', 1).toPosition());
            tab.dropPiece(new Tower(tab, Color.White), new ChessPosition('c', 2).toPosition());
            tab.dropPiece(new Tower(tab, Color.White), new ChessPosition('d', 2).toPosition());
            tab.dropPiece(new Tower(tab, Color.White), new ChessPosition('e', 2).toPosition());
            tab.dropPiece(new Tower(tab, Color.White), new ChessPosition('e', 1).toPosition());
            tab.dropPiece(new King(tab, Color.White), new ChessPosition('d', 1).toPosition());

            tab.dropPiece(new Tower(tab, Color.Black), new ChessPosition('c', 7).toPosition());
            tab.dropPiece(new Tower(tab, Color.Black), new ChessPosition('c', 8).toPosition());
            tab.dropPiece(new Tower(tab, Color.Black), new ChessPosition('d', 7).toPosition());
            tab.dropPiece(new Tower(tab, Color.Black), new ChessPosition('e', 7).toPosition());
            tab.dropPiece(new Tower(tab, Color.Black), new ChessPosition('e', 8).toPosition());
            tab.dropPiece(new King(tab, Color.Black), new ChessPosition('d', 8).toPosition());
        }

    }
}
