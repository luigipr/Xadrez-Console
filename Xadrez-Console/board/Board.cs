using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class Board {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Piece[,] Pieces;

        public Board(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pieces = new Piece[linhas, colunas];
        }
    }
}
