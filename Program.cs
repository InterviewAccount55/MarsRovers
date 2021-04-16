using MarsRovers.Interfaces;
using MarsRovers.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"5 5 
                             1 2 N
                             MMMMMMMMMM
                             3 3 E
                             MMRMMRMRRM
                             5 5 S
                             MMLMRMLMRMLMRMLMRM";

            string[] lines = input.Split("\n").Select(l => l.Trim()).ToArray();

            int surfaceWidth = Convert.ToInt32(lines[0].Split(" ")[0]);
            int surfaceHeigth = Convert.ToInt32(lines[0].Split(" ")[1]);

            ISurface plateau = new Plateau(new Size(surfaceWidth, surfaceHeigth));

            IList<IRover> deployedRovers = new List<IRover>();

            for(int i = 1; i < lines.Length; i+=2)
            {
                IRover rover;

                string[] data = lines[i].Split(" ");

                int x = Convert.ToInt32(data[0]);
                int y = Convert.ToInt32(data[1]);
                CardinalDirection direction = Enum.Parse<CardinalDirection>(data[2]);
                    
                rover = new Rover(new RoverInstructionParser());
                rover.Land(plateau, new Coordinate(x, y), direction);
                rover.Move(lines[i + 1]);

                deployedRovers.Add(rover);
            }

            foreach(var deployedRover in deployedRovers)
            {
                Console.WriteLine($"{deployedRover.Position.X} {deployedRover.Position.Y} {deployedRover.Direction}");
            }

            Console.ReadKey(true);

        }
    }
}
