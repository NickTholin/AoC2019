namespace AoC2019.Day1
{
    public sealed class RecursiveFuelCalculator : IFuelCalculator
    {
        private IFuelCalculator _additionalCalculator;

        public RecursiveFuelCalculator(IFuelCalculator additionalCalculator)
        {
            _additionalCalculator = additionalCalculator;
        }

        public int CalculateFuelRequirements(int mass)
        {
            var fuelRequired = _additionalCalculator.CalculateFuelRequirements(mass);
            var extraFuelToCarryFuel = 0;

            if (fuelRequired > 0)
                extraFuelToCarryFuel = CalculateFuelRequirements(fuelRequired);
            else
                return 0;

            return fuelRequired + extraFuelToCarryFuel;
        }

    }
}
