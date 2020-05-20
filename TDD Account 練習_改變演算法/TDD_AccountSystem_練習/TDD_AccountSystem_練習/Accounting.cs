using System;

namespace TDD_AccountSystem_練習
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }

        public bool IsSameWithStart(Budget budget)
        {
            return budget.YearMonth == StartDate.ToString("yyyyMM");
        }

        public bool IsSameWithEnd(Budget budget)
        {
            return budget.YearMonth == EndDate.ToString("yyyyMM");
        }

        public bool InRange(Budget budget)
        {
            return StartDate <= budget.CreateDateTime() && EndDate >= budget.CreateDateTime();
        }

        public bool IsBetweenRange(Budget budget)
        {
            return IsSameWithStart(budget) ||
                   IsSameWithEnd(budget)   ||
                   InRange(budget);
        }
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
                amountOfBudgets += budget.AmountOfBudget(period);
            }
            return amountOfBudgets;
        }


        public IBudgetRepo Repo { get; set; }
    }
}
