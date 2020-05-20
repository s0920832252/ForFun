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
            var amountOfBudget = 0m;
            var period = new Period(startDate, endDate);
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
                    InRange(period, budget))
                {
                    amountOfBudget += budget.Amount;
                }
            }
            return amountOfBudget;
        }

        private static bool InRange(Period period, Budget budget)
        {
            return period.StartDate <= budget.CreateDateTime() && period.EndDate >= budget.CreateDateTime();
        }


        public IBudgetRepo Repo { get; set; }
    }
}
