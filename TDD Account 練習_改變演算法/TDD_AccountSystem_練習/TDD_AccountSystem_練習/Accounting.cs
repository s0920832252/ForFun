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
                amountOfStartBudget = AmountBeforeTheDay(startBudget, startDate);
            }

            var endBudget = budgets.FirstOrDefault(budget => budget.YearMonth == endDate.ToString("yyyyMM"));
            decimal amountOfEndBudget = 0m;
            if (endBudget != null)
            {
                amountOfEndBudget = AmountAfterTheDay(endBudget, endDate);
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

        private static decimal AmountAfterTheDay(Budget budget, DateTime endDate)
        {
            decimal amountOfEndBudget;
            var     endBudgetAmount = budget.Amount;
            var     endMonthDays    = DaysInMonth(budget);
            var     endDateDay      = endMonthDays - endDate.Day;
            amountOfEndBudget = endBudgetAmount / endMonthDays * endDateDay;
            return amountOfEndBudget;
        }

        private static decimal AmountBeforeTheDay(Budget Budget, DateTime startDate)
        {
            decimal amountOfStartBudget;
            var     startBudgetAmount = Budget.Amount;
            var     startDateDay      = startDate.Day - 1;
            var     startMonthDays    = DaysInMonth(Budget);
            amountOfStartBudget = startBudgetAmount / startMonthDays * startDateDay;
            return amountOfStartBudget;
        }

        private static int DaysInMonth(Budget budget)
        {
            var startDateTime  = CreateDateTime(budget);
            var startMonthDays = DateTime.DaysInMonth(startDateTime.Year, startDateTime.Month);
            return startMonthDays;
        }

        private static DateTime CreateDateTime(Budget budget)
        {
            return DateTime.ParseExact(budget.YearMonth, "yyyyMM", null);
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
