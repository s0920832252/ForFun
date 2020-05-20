using System;
using System.Linq;

namespace TDD_AccountSystem_練習
{
    class Accounting
    {
        public decimal QueryBudget(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return 0;

            var budgets = Repo.GetAll();
            return budgets.Sum(budget => budget.AmountOfBudget(new Period(startDate, endDate)));
        }


        public IBudgetRepo Repo { get; set; }
    }
}
