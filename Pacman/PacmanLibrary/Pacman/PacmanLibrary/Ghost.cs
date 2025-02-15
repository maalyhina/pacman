using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PacmanLibrary
{
    public class Ghost : MovingPoint
    {
        public bool IsDead { get; set; }

        public Ghost(int x, int y, int speed = 1) : base(x, y, speed)
        {
            IsDead = false;
            Sprite = new Bitmap(Properties.Resources.Ghost1);
        }

        public void Respawn()
        {
            X = 216;

            Y = 224;

            IsDead = false;
        }
    }
}
