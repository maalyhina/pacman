using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace PacmanLibrary
{
    public class GraphicPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Bitmap Sprite { get; set; } = null;
        
        public GraphicPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
