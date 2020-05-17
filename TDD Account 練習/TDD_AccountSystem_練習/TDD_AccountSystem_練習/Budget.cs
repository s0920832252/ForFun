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
    }
}
