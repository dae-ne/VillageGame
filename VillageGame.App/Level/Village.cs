using System.Threading.Tasks;

namespace VillageGame.App.Level
{
    class Village
    {
        private bool _isGoldMineBuilt = false;
        private bool _isQuarryBuilt = false;
        private bool _isSawmillBuilt = false;
        private bool _isCottageBuilt = false;
        private bool _isMintBuilt = false;

        public int Money { get; private set; } = 2000;
        public int Counter { get; private set; } = 0;

        public bool BuildGoldMine()
        {
            return BuildBuilding(5000, 100);
            _isGoldMineBuilt = true;
        }

        public bool BuildQuarry()
        {
            return BuildBuilding(500, 200);
            _isQuarryBuilt = true;
        }

        public bool BuildSawmill()
        {
            return BuildBuilding(3000, 500);
            _isSawmillBuilt = true;
        }

        public bool BuildCottage()
        {
            return BuildBuilding(1500, 300);
            _isCottageBuilt = true;
        }

        public bool BuildMint()
        {
            return BuildBuilding(10000, 500);
            _isCottageBuilt = true;
        }

        public VillageMomento SaveStateToMomento()
        {
            return new VillageMomento(Money, Counter);
        }

        public void RestoreStateFromMomento(VillageMomento momento)
        {
            Money = momento.Money;
            Counter = momento.Counter;
        }

        private bool BuildBuilding(int money, int income)
        {
            if (money > Money)
            {
                return false;
            }

            Money -= money;
            _ = GenerateIncomeAsync(income, Counter++);
            return true;
        }

        private async Task GenerateIncomeAsync(int income, int counter)
        {
            while (counter < Counter)
            {
                await Task.Delay(10000);

                if (counter < Counter)
                {
                    Money += income;
                }
            }
        }
    }
}
