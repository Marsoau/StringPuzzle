using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPuzzle.Model
{
    public interface IPuzzle
    {
        public string LeftSide();
        public string RightSide();

        public static bool IsCompatible(IPuzzle left, IPuzzle right) {
            return left.RightSide() == right.LeftSide();
        }
    }
}
