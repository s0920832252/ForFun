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
            var start = budget.FirstDay() > StartDate ? budget.FirstDay() : StartDate;
            var end   = budget.LastDay()  > EndDate ? EndDate : budget.LastDay();
            return (end - start).Days + 1;
        }
    }
}