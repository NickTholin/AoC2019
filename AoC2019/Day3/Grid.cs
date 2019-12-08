using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System;

namespace AoC2019.Day3
{
    public class Grid
    {
        private List<Point> wire1Positions = new List<Point>();
        private List<Point> wire2Positions = new List<Point>();

        public void RunWires(string wire1Paths, string wire2Paths)
        {
            wire1Positions = RunWire(wire1Paths);
            wire2Positions = RunWire(wire2Paths);
        }

        private List<Point> RunWire(string wirePaths)
        {
            var positionsVisited = new List<Point>();
            var wirePositions = new List<Point>() { new Point(0, 0) };

            var mappings = wirePaths
                .Split(',')
                .Select(x => new Vector(x))
                .ToList();

            foreach (var mapping in mappings)
            {
                wirePositions.AddRange(CalculatePositionsVisitedFromCentralPort(mapping, wirePositions.Last()));
            }

            return wirePositions;
        }

        public int DistanceOfClosestCrossing()
        {
            if (!(wire1Positions.Any() || wire2Positions.Any())) throw new InvalidOperationException();

            var crossings = wire1Positions.Intersect(wire2Positions);
            
            //remove crossings at origin per instructions
            crossings = crossings.Where(x => Math.Abs(x.X) + Math.Abs(x.Y) != 0);

            return crossings.Min(x => Math.Abs(x.X) + Math.Abs(x.Y));
        }

        private List<Point> CalculatePositionsVisitedFromCentralPort(Vector vector, Point currentPosition)
        {
            //used to set negative if necessary
            var modifier = 1;
            var positionsVisited = new List<Point>();

            if (vector.Direction == "D" || vector.Direction == "L") modifier = -1;

            var goingVertical = (vector.Direction == "D" || vector.Direction == "U");

            //calculate point 1 position away from current.  values are in relation to origin (0,0)
            for (int i = 1; i <= vector.Distance; i++)
            {
                if (goingVertical)
                    currentPosition.Y = currentPosition.Y + (1 * modifier);
                else
                    currentPosition.X = currentPosition.X + (1 * modifier);
                positionsVisited.Add(currentPosition);
            }

            return positionsVisited;
        }
        
        private class Vector
        {
            public string Direction { get; set; }
            public int Distance { get; set; }


            public Vector(string path)
            {
                Direction = path[0].ToString();
                Distance = int.Parse(string.Join("",path.Skip(1)));
            }
        }
    }
}
