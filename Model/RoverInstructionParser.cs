using MarsRovers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Model
{
    class RoverInstructionParser : IRoverInstructionsParser
    {
        private Dictionary<char, ActionType> _mappings;

        public RoverInstructionParser()
        {
            _mappings = new Dictionary<char, ActionType>()
            {
                { 'L', ActionType.Left },
                { 'R', ActionType.Right },
                { 'M', ActionType.MoveForward }
            };
        }

        public IEnumerable<ActionType> Parse(string s)
        {
            foreach(char c in s)
            {
                if(_mappings.ContainsKey(c))
                {
                    yield return _mappings[c];
                }
            }
        }
    }
}
