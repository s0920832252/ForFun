using System;

namespace TDD_AccountSystem_練習
{
    internal class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
    }

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
                amountOfBudgets += AmountOfBudget(budget, period);
            }
            return amountOfBudgets;
        }

        private static decimal AmountOfBudget(Budget budget, Period period)
        {
            var amountOfBudget = 0m;
            amountOfBudget -= IsSameWithStart(budget, period) ? budget.AmountBeforeTheDay(period.StartDate) : 0;

            amountOfBudget -= IsSameWithEnd(budget, period) ? budget.AmountAfterTheDay(period.EndDate) : 0;

            amountOfBudget += IsBetweenRange(budget, period) ? budget.Amount : 0;

            return amountOfBudget;
        }

        private static bool IsBetweenRange(Budget budget, Period period)
        {
            return IsSameWithStart(budget, period) ||
                   IsSameWithEnd(budget, period) ||
                   InRange(period, budget);
        }

        private static bool IsSameWithEnd(Budget budget, Period period)
        {
            return budget.YearMonth == period.EndDate.ToString("yyyyMM");
        }

        private static bool IsSameWithStart(Budget budget, Period period)
        {
            return budget.YearMonth == period.StartDate.ToString("yyyyMM");
        }

        private static bool InRange(Period period, Budget budget)
        {
            return period.StartDate <= budget.CreateDateTime() && period.EndDate >= budget.CreateDateTime();
        }


        public IBudgetRepo Repo { get; set; }
    }
}
