using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Interfaces
{
    interface IRover
    {
        Coordinate Position { get; }

        CardinalDirection Direction { get; }

        ISurface Surface { get; }

        void Land(ISurface surface, Coordinate initialPosition, CardinalDirection initialDirection);

        void Move(string s);

        void TurnLeft();

        void TurnRight();

        void MoveForward();
    }
}
