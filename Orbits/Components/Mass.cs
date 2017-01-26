namespace Orbits.Components
{
    public class Mass: Component
    {
        public float Amount;

        public Mass(float amount)
        {
            Flag = ComponentFlag.Mass;
            Amount = amount;
        }
    }
}
