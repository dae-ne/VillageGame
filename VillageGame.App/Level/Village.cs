using System.Threading.Tasks;

namespace VillageGame.App.Level
{
    class Village
    {
        public int Money { get; private set; } = 2000;
        public int Counter { get; private set; } = 0;

        public bool BuildGoldMine() => BuildBuilding(5000, 100);
        public bool BuildQuarry() => BuildBuilding(500, 200);
        public bool BuildSawmill() => BuildBuilding(3000, 500);
        public bool BuildCottage() => BuildBuilding(1500, 300);
        public bool BuildMint() => BuildBuilding(10000, 500);

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
