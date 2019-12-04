using System;

namespace AoC2019.Day1
{
    public sealed class SimpleFuelCalculator : IFuelCalculator
    {
        private IFuelCalculator _additionalCalculator;

        public SimpleFuelCalculator(IFuelCalculator additionalCalculator = null)
        {
            _additionalCalculator = additionalCalculator;
        }

        public int CalculateFuelRequirements(int mass)
        {
            var fuelRequired = (int)Math.Floor(mass / 3M) - 2;

            if (_additionalCalculator == null) return fuelRequired;

            return fuelRequired += _additionalCalculator.CalculateFuelRequirements(fuelRequired);
        }
    }
}
