﻿using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class Position {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Position(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }

        public override string ToString() {
            return linha + ", " + coluna;
        }
    }
}
