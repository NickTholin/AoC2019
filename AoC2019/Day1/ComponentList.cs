using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2019.Day1
{
    public class ComponentList
    {
        private IEnumerable<Component> components = new List<Component>();

        public int FuelRequired => CalculateFuelRequired();
       
        public ComponentList(string fileName, IFuelCalculator fuelCalculator)
        {
            //Not abstracting out IO because I've over engineered this enough.
            var componentMasses = File.ReadAllText(fileName);
            components = componentMasses
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Component(fuelCalculator, int.Parse(x.Trim())));
        }

        private int CalculateFuelRequired()
        {
            return components.Aggregate(0, (total, current) => total += current.CalculateFuelRequirements());
        }
    }
}
