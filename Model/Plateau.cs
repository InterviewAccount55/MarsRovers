using MarsRovers.Interfaces;
using System;

namespace MarsRovers.Model
{
    class Plateau : ISurface
    {
        public Size Size { get; private set; }

        public Plateau(Size size)
        {
            this.Size = size;
        }
    }
}
