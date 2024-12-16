using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPuzzle.Model
{
    public class PuzzleStringBuilder
    {
        private readonly List<string> _parts;
        public int Count {
            get => _parts.Count;
        }

        public PuzzleStringBuilder() {
            _parts = new List<string>();
        }

        public bool TryAttach(PuzzleStringBuilder line) {
            if (_parts.Count == 0) {
                _parts.AddRange(line._parts);
                return true;
            }

            for (int i = 0; i < _parts.Count; i++) {
                if (IsConnnectionPossible(line, _parts[i])) {
                    if (i == 0 || IsConnnectionPossible(_parts[i - 1], line)) {
                        _parts.InsertRange(i, line._parts);
                        return true;
                    }
                }
                else if (IsConnnectionPossible(_parts[i], line)) {
                    if (i == _parts.Count - 1 || IsConnnectionPossible(line, _parts[i + 1])) {
                        _parts.InsertRange(i + 1, line._parts);
                        return true;
                    }
                }
            }

            return false;
        }
        public bool TryAttach(string puzzle) {
            if (puzzle.Length != 6) return false;
            if (_parts.Count == 0) {
                _parts.Add(puzzle);
                return true;
            }

            for (int i = 0; i < _parts.Count; i++) {
                if (IsConnnectionPossible(puzzle, _parts[i])) {
                    if (i == 0 || IsConnnectionPossible(_parts[i - 1], puzzle)) {
                        _parts.Insert(i, puzzle);
                        return true;
                    }
                }
                else if (IsConnnectionPossible(_parts[i], puzzle)) {
                    if (i == _parts.Count - 1 || IsConnnectionPossible(puzzle, _parts[i + 1])) {
                        _parts.Insert(i + 1, puzzle);
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool IsConnnectionPossible(string left, string right) {
            if (left.Length != 6 || right.Length != 6) throw new Exception("puzzles must be 6 digit long");

            if (left[4] == right[0] && left[5] == right[1])
                return true;

            return false;
        }
        public static bool IsConnnectionPossible(PuzzleStringBuilder left, string right) {
            if (right.Length != 6) throw new Exception("puzzles must be 6 digit long");
            if (left.Count == 0) return false;

            if (left._parts.LastOrDefault()?[4] == right[0] && left._parts.LastOrDefault()?[5] == right[1])
                return true;

            return false;
        }
        public static bool IsConnnectionPossible(string left, PuzzleStringBuilder right) {
            if (left.Length != 6) throw new Exception("puzzles must be 6 digit long");
            if (right.Count == 0) return false;

            if (left[4] == right._parts.FirstOrDefault()?[0] && left[5] == right._parts.FirstOrDefault()?[1])
                return true;

            return false;
        }
        public static bool IsConnnectionPossible(PuzzleStringBuilder left, PuzzleStringBuilder right) {
            if (left.Count == 0 || right.Count == 0) return false;

            if (left._parts.LastOrDefault()?[4] == right._parts.FirstOrDefault()?[0] && left._parts.LastOrDefault()?[5] == right._parts.FirstOrDefault()?[1])
                return true;

            return false;
        }

        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append(_parts.FirstOrDefault()?.Substring(0, 2));
            foreach (var part in _parts) {
                sb.Append(part.Substring(2));
            }

            return sb.ToString();
        }
    }
}
