using System;
using System.Linq;
using AoC2019.Day1;
using AoC2019.Day2;
using AoC2019.Day3;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1 Part 2
            var fuelCalculator = new RecursiveFuelCalculator(new SimpleFuelCalculator());
            var componentList = new ComponentList(@"Day1/ComponentMasses.txt", fuelCalculator);
            Console.WriteLine($"Required Fuel: {componentList.FuelRequired}");

            //Day2
            var intCodeSequence = System.IO.File.ReadAllText("Day2/IntCodes.txt");
            var intCodes = intCodeSequence
                .Split(",")
                .Select(int.Parse)
                .ToList();
            var intCode = new IntCode();
            var memory = intCode.Run(intCodes);

            Console.WriteLine("- Day 2 -");
            Console.WriteLine("Part 1");
            Console.WriteLine($"Value of address0: {memory[0]}");


            //Part2
            var intCodeGoal = intCode.FindIntCodeFromGoal(intCodes, 19690720);
            Console.WriteLine("Part 2");
            Console.WriteLine($"IntCode[0]: {intCodeGoal.Memory[0]} Noun: {intCodeGoal.Noun} Verb: {intCodeGoal.Verb}");

            //Day3
            var wire1Paths = System.IO.File.ReadAllText("Day3/Wire1Path.txt");
            var wire2Paths = System.IO.File.ReadAllText("Day3/Wire2Path.txt");

            var grid = new Grid();
            grid.RunWires(wire1Paths, wire2Paths);

            Console.WriteLine("- Day3 -");
            Console.WriteLine($"Closest crossing distance from origin: {grid.DistanceOfClosestCrossing()}");
            Console.ReadKey();
        }

        public static void log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
