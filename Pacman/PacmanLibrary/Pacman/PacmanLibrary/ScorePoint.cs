using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanLibrary
{
    public class ScorePoint : Element
    {
        public int Score { get; }

        public ScorePoint(int x, int y) : base(x, y)
        {
            Score = 10;
        }

        protected ScorePoint(int x, int y, int score) : base(x, y)
        {
            Score = score;
        }
    }
}
