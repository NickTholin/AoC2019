namespace AoC2019.Day1
{
    public class Component
    {
        private readonly IFuelCalculator fuelCalculator;

        public int Mass { get; }
        public int RequiredFuel => CalculateFuelRequirements();

        public Component(IFuelCalculator fuelCalculator, int mass)
        {
            this.fuelCalculator = fuelCalculator;
            Mass = mass;
        }

        public int CalculateFuelRequirements()
        {
            return fuelCalculator.CalculateFuelRequirements(Mass);
        }
    }
}
