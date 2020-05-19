using System;

namespace TDD_AccountSystem_練習
{
    public class Budget
    {
        public string  YearMonth { get; set; }
        public decimal Amount { get; set; }

        public DateTime CreateDateTime()
        {
            return DateTime.ParseExact(YearMonth, "yyyyMM", null);
        }

        public int DaysInMonth()
        {
            var startDateTime = CreateDateTime();
            return DateTime.DaysInMonth(startDateTime.Year, startDateTime.Month);
        }

        public decimal AmountBeforeTheDay(DateTime startDate)
        {
            return Amount / DaysInMonth() * (startDate.Day - 1);
        }

        public decimal AmountAfterTheDay(DateTime endDate)
        {
            return Amount / DaysInMonth() * (DaysInMonth() - endDate.Day);
        }
    }
}
