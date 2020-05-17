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

        public int OverLappingDays(Period anotherPeriod)
        {
            var start = anotherPeriod.StartDate > StartDate ? anotherPeriod.StartDate : StartDate;
            var end = anotherPeriod.EndDate > EndDate ? EndDate : anotherPeriod.EndDate;
            var overLappingDays = (end - start).Days + 1;
            return overLappingDays <= 0 ? 0 : overLappingDays;
        }
    }
}