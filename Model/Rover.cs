using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;

namespace MarsRovers.Model
{
    class Rover : IRover
    {
        public Coordinate Position { get; private set; }

        public CardinalDirection Direction { get; private set; }

        public ISurface Surface { get; private set; }

        private IRoverInstructionsParser _roverInstructionParser;

        private Dictionary<ActionType, Action> _actionMappings; 

        public Rover(IRoverInstructionsParser roverInstructionsParser)
        {
            this._roverInstructionParser = roverInstructionsParser;
            this._actionMappings = new Dictionary<ActionType, Action>()
            {
                { ActionType.Left, TurnLeft },
                { ActionType.Right, TurnRight },
                { ActionType.MoveForward, MoveForward }
            };
        }

        public void Land(ISurface surface, Coordinate initialPosition, CardinalDirection initialDirection)
        {
            this.Position = initialPosition;
            this.Direction = initialDirection;
            this.Surface = surface;

            if (!IsValidPosition(initialPosition))
            {
                throw new System.Exception("Rover landing failed");
            }
        }

        public void Move(string instructions)
        {
            var actions = _roverInstructionParser.Parse(instructions);

            foreach(var action in actions)
            {
                _actionMappings[action]();
            }
        }

        public void TurnLeft()
        {
            switch(Direction)
            {
                case CardinalDirection.N: this.Direction = CardinalDirection.W; break;
                case CardinalDirection.S: this.Direction = CardinalDirection.E; break;
                case CardinalDirection.E: this.Direction = CardinalDirection.N; break;
                case CardinalDirection.W: this.Direction = CardinalDirection.S; break;
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case CardinalDirection.N: this.Direction = CardinalDirection.E; break;
                case CardinalDirection.S: this.Direction = CardinalDirection.W; break;
                case CardinalDirection.E: this.Direction = CardinalDirection.S; break;
                case CardinalDirection.W: this.Direction = CardinalDirection.N; break;
            }
        }

        public void MoveForward()
        {
            Coordinate newPosition = new Coordinate(this.Position.X, this.Position.Y);

            switch(Direction)
            {
                case CardinalDirection.N: newPosition.Y += 1; break;
                case CardinalDirection.S: newPosition.Y -= 1; break;
                case CardinalDirection.E: newPosition.X += 1; break;
                case CardinalDirection.W: newPosition.X -= 1; break;
            }

            if(IsValidPosition(newPosition))
            {
                this.Position = newPosition;
            }
        }

        private bool IsValidPosition(Coordinate position)
        {
            if(position.X <= this.Surface.Size.Width && position.X >= 0 && position.Y <= this.Surface.Size.Height && position.Y >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
