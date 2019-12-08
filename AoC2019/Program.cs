using System;
using System.Linq;
using AoC2019.Day1;
using AoC2019.Day2;

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
            Console.ReadKey();

            //Day2
            var intCodeSequence = System.IO.File.ReadAllText("Day2/IntCodes.txt");
            var intCodes = intCodeSequence
                .Split(",")
                .Select(int.Parse)
                .ToList();
            var intCode = new IntCode();
            var memory = intCode.Run(intCodes);

            Console.WriteLine(memory[0]);
            Console.ReadKey();

            //Part2
            var intCodeGoal = intCode.FindIntCodeFromGoal(intCodes, 19690720);
            Console.WriteLine();
            Console.WriteLine($"IntCode[0]: {intCodeGoal.Memory[0]} Noun: {intCodeGoal.Noun} Verb: {intCodeGoal.Verb}");
            Console.ReadKey();

        }

        public static void log(string s)
        {
            Console.WriteLine(s);
        }
    }
}
