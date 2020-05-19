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

            var startBudget = budgets.FirstOrDefault(budget => budget.YearMonth == startDate.ToString("yyyyMM"));
            decimal amountOfStartBudget = 0m;
            if (startBudget != null)
            {
                amountOfStartBudget = startBudget.AmountBeforeTheDay(startDate);
            }

            var endBudget = budgets.FirstOrDefault(budget => budget.YearMonth == endDate.ToString("yyyyMM"));
            decimal amountOfEndBudget = 0m;
            if (endBudget != null)
            {
                amountOfEndBudget = endBudget.AmountAfterTheDay(endDate);
            }

            var amountOfBudget = 0m;
            var currentDate = new DateTime(startDate.Year, startDate.Month, 1);
            while (currentDate <= endDate)
            {
                var findBudget = budgets.FirstOrDefault(budget => budget.YearMonth == currentDate.ToString("yyyyMM"));
                amountOfBudget += findBudget?.Amount ?? 0;

                currentDate = currentDate.AddMonths(1);
            }
            return amountOfBudget - amountOfStartBudget - amountOfEndBudget;
        }

        private decimal BudgetOfMonth(DateTime startDate, int days)
        {


            var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            var budget = Repo.GetAll().FirstOrDefault(model => model.YearMonth == startDate.ToString("yyyyMM"));
            if (budget != null) return (decimal)budget.Amount / daysInMonth * days;
            return 0;
        }



        public IBudgetRepo Repo { get; set; }
    }
}
