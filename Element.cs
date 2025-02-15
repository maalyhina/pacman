using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanLibrary
{
    public class Element : GraphicPoint
    {
        public Element(int x, int y) : base(x, y)
        {
            X = x * 16;
            Y = y * 16;
        }
    }
}
