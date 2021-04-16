using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model
{
    class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Size(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }
    }
}
