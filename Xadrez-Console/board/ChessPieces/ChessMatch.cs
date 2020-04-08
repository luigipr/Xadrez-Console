using System;
using System.Collections.Generic;
using System.Text;
using board;

namespace ChessPieces {
    class ChessMatch {

        public Board tab { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
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
