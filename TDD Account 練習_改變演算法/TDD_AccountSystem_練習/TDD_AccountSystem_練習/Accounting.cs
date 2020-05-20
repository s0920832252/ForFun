using System;

namespace TDD_AccountSystem_練習
{
    class Accounting
    {

        public decimal QueryBudget(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return 0;

            var budgets = Repo.GetAll();
            var amountOfBudget = 0m;
            foreach (var budget in budgets)
            {
                if (budget.YearMonth == startDate.ToString("yyyyMM"))
                {
                    amountOfBudget -= budget.AmountBeforeTheDay(startDate);
                }

                if (budget.YearMonth == endDate.ToString("yyyyMM"))
                {
                    amountOfBudget -= budget.AmountAfterTheDay(endDate);
                }

                if (budget.YearMonth == startDate.ToString("yyyyMM") ||
                    budget.YearMonth == endDate.ToString("yyyyMM") ||
                    InRange(startDate, endDate, budget))
                {
                    amountOfBudget += budget.Amount;
                }
            }
            return amountOfBudget;
        }

        private static bool InRange(DateTime startDate, DateTime endDate, Budget budget)
        {
            return startDate <= budget.CreateDateTime() && endDate >= budget.CreateDateTime();
        }


        public IBudgetRepo Repo { get; set; }
    }
}
