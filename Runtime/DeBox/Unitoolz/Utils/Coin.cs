namespace DeBox.Unitoolz.Utils
{
    public class Coin
    {
        private const int CHANCE_RESOLUTION = 1000;

        private readonly ChanceTable<bool> _chanceTable = new ChanceTable<bool>();

        public static readonly Coin FairCoin = new Coin(0.5f);

        public Coin(float trueChance)
        {
            int trueChanceValue = (int)(trueChance * CHANCE_RESOLUTION);
            int falseChanceValue = CHANCE_RESOLUTION - trueChanceValue;
            _chanceTable.RegisterChance(true, trueChanceValue);
            _chanceTable.RegisterChance(false, falseChanceValue);
        }

        public bool Flip()
        {
            return _chanceTable.Roll();
        }
    }
}