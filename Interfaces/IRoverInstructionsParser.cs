using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Interfaces
{
    interface IRoverInstructionsParser
    {
        IEnumerable<ActionType> Parse(string s);
    }
}
