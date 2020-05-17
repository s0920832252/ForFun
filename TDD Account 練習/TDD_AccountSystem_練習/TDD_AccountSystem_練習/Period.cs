using System;

namespace TDD_AccountSystem_練習
{
    internal class Period
    {
        public Period(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate   = endDate;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate   { get; private set; }

        public int OverLappingDays(Budget budget)
        {
            DateTime budgetTime = budget.DateTimeFromBudget();
            DateTime start;
            DateTime end;
            if (budgetTime.ToString("yyyyMM") == StartDate.ToString("yyyyMM"))
            {
                start = StartDate;
                end   = budget.LastDay();
            }
            else if (budgetTime.ToString("yyyyMM") == EndDate.ToString("yyyyMM"))
            {
                start = budget.FirstDay();
                end   = EndDate;
            }
            else
            {
                start = budget.FirstDay();
                end   = budget.LastDay();
            }

            var days = (end - start).Days + 1;
            return days;
        }
    }
}