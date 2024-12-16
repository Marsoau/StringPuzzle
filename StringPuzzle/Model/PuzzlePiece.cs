using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPuzzle.Model
{
    public class PuzzlePiece : IPuzzle
    {
        public string String;

        public PuzzlePiece(string puzzle) {
            String = puzzle;
        }

        public string LeftSide() {
            return String.Substring(0, 2);
        }
        public string RightSide() {
            return String.Substring(4, 2);
        }
    }
}
