using System;
using System.Collections.Generic;
using System.Text;

namespace board {
    class Position {
        public int lines { get; set; }
        public int columns { get; set; }

        public Position(int line, int column) {
            this.lines = line;
            this.columns = column;
        }

        public override string ToString() {
            return lines + ", " + columns;
        }
    }
}
