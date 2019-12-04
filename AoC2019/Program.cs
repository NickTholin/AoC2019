using System;
using AoC2019.Day1;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1
            var fuelCalculator = new RecursiveFuelCalculator(new SimpleFuelCalculator());
            var componentList = new ComponentList(@"Day1/ComponentMasses.txt", fuelCalculator);
            Console.WriteLine($"Required Fuel: {componentList.FuelRequired}");
            Console.ReadKey();
        }
    }
}
