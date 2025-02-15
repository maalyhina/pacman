using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PacmanLibrary
{
    public class PacmanP : MovingPoint
    {
        public int Lives { get; set; } = 3;
        public bool IsPowered { get; set; } = false;

        public PacmanP(int x = 216, int y = 416, int speed = 1) : base(x, y, speed)
        {
            Sprite = new Bitmap(Properties.Resources.Pacman);
        }

        public void Die()
        {
            X = 216;
            Y = 416;
            Lives--;
        }
    }
}
