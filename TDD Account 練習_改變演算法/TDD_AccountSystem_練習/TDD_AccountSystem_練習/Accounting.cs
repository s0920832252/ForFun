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

                var start = new DateTime(startDate.Year, startDate.Month, 1);
                var end = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                var budgetTime = budget.CreateDateTime();
                if (start <= budgetTime && end >= budgetTime)
                {
                    amountOfBudget += budget.Amount;
                }
            }
            return amountOfBudget;
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
