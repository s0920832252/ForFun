using System;

namespace TDD_AccountSystem_練習
{
    public class Budget
    {
        public string  YearMonth { get; set; }
        public decimal Amount { get; set; }

        public DateTime DateTimeFromBudget()
        {
            return DateTime.ParseExact(YearMonth,"yyyyMM",null);
        }

        public int DaysInMonth()
        {
            var dateTimeFromBudget = DateTimeFromBudget();
            return DateTime.DaysInMonth(dateTimeFromBudget.Year, dateTimeFromBudget.Month);
        }

        public DateTime FirstDay()
        {
            var dateTime = DateTimeFromBudget();
            var start    = new DateTime(dateTime.Year, dateTime.Month, 1);
            return start;
        }

        public DateTime LastDay()
        {
            var dateTime = DateTimeFromBudget();
            var end      = new DateTime(dateTime.Year, dateTime.Month, DaysInMonth());
            return end;
        }
    }
}
