using StringPuzzle.Model;

namespace StringPuzzle
{
    internal class Program
    {
        static List<PuzzleLine> lines = new List<PuzzleLine>();

        static void Main(string[] args)
        {
            var reader = new StreamReader(File.OpenRead("values.txt"));

            string? puzzlestr;
            PuzzlePiece puzzle;

            bool success = false;

            while ((puzzlestr = reader.ReadLine()) != null) {
                puzzle = new PuzzlePiece(puzzlestr);

                foreach (var line in lines) {
                    if (line.TryAttach(puzzle)) {
                        success = true;

                        AttemptLineConnect(line);
                        break;
                    }

                    break;
                }
                if (!success) {
                    lines.Add(new PuzzleLine(puzzle));
                }

                success = false;
            }

            var longest = lines.FirstOrDefault();
            foreach (var line in lines) {
                if (line.Count > longest?.Count) longest = line;
            }

            Console.WriteLine($"longest puzzle line: {longest?.ToString() ?? "none"} ({longest?.Count ?? 0} puzzles, {longest?.ToString()?.Length ?? 0} digits)");
        }

        static void AttemptLineConnect(PuzzleLine line) {
            foreach (var otherLine in lines) {
                if (otherLine == line) continue;

                if (otherLine.TryAttach(line)) {
                    lines.Remove(line);
                    AttemptLineConnect(otherLine);

                    break;
                }
            }
        }
    }
}
