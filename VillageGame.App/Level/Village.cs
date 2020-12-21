using System.Threading.Tasks;

namespace VillageGame.App.Level
{
    class Village
    {
        private bool _isGoldMineBuilt = false;
        private bool _isQuarryBuilt = false;
        private bool _isSawmillBuilt = false;
        private bool _isCottageBuilt = false;

        public int Money { get; private set; } = 2000;
        public int Counter { get; private set; } = 0;

        public bool BuildGoldMine()
        {
            if (!_isQuarryBuilt && !_isSawmillBuilt)
            {
                return false;
            }

            _isGoldMineBuilt = true;
            return BuildBuilding(5000, 100);
        }

        public bool BuildQuarry()
        {
            _isQuarryBuilt = true;
            return BuildBuilding(500, 200);
        }

        public bool BuildSawmill()
        {
            if (!_isCottageBuilt)
            {
                return false;
            }

            _isSawmillBuilt = true;
            return BuildBuilding(3000, 500);
        }

        public bool BuildCottage()
        {
            _isCottageBuilt = true;
            return BuildBuilding(1500, 300);
        }

        public bool BuildMint()
        {
            if (!_isGoldMineBuilt)
            {
                return false;
            }

            _isCottageBuilt = true;
            return BuildBuilding(10000, 500);
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
