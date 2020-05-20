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
            var amountOfBudgets = 0m;
            var period = new Period(startDate, endDate);
            foreach (var budget in budgets)
            {
                amountOfBudgets += budget.AmountOfBudget(period);
            }
            return amountOfBudgets;
        }


        public IBudgetRepo Repo { get; set; }
    }
}
