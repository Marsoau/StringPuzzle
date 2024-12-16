using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPuzzle.Model
{
    public class PuzzleLine : IPuzzle
    {
        private readonly List<PuzzlePiece> _parts;
        public int Count {
            get => _parts.Count;
        }

        private PuzzleLine() {
            _parts = new List<PuzzlePiece>();
        }
        public PuzzleLine(IPuzzle firstPuzzle) : this() {
            InsertAt(0, firstPuzzle);
        }
        public PuzzleLine(string firstPiece) : this(new PuzzlePiece(firstPiece)) { }

        public string LeftSide() {
            return _parts.First().LeftSide();
        }
        public string RightSide() {
            return _parts.Last().RightSide();
        }

        public bool TryAttach(IPuzzle puzzle) {
            for (int i = 0; i < _parts.Count; i++) {
                if (IPuzzle.IsCompatible(puzzle, _parts[i])) {
                    if (i == 0 || IPuzzle.IsCompatible(_parts[i - 1], puzzle)) {
                        InsertAt(i, puzzle);
                        return true;
                    }
                }
                else if (IPuzzle.IsCompatible(_parts[i], puzzle)) {
                    if (i == _parts.Count - 1 || IPuzzle.IsCompatible(puzzle, _parts[i + 1])) {
                        InsertAt(i + 1, puzzle);
                        return true;
                    }
                }
            }

            return false;
        }

        private void InsertAt(int position, IPuzzle puzzle) {
            if (puzzle is PuzzlePiece piece) {
                _parts.Insert(position, piece);
            }
            else if (puzzle is PuzzleLine line) {
                _parts.InsertRange(position, line._parts);
            }
        }

        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append(_parts.First().LeftSide());
            foreach (var part in _parts) {
                sb.Append(part.String.Substring(2));
            }

            return sb.ToString();
        }
    }
}
