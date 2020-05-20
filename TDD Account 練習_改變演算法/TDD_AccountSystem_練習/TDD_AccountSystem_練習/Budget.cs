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

        public decimal AmountBeforeTheDay(Period period)
        {
            return period.IsSameWithStart(this) ? AmountBeforeTheDay(period.StartDate) : 0;
        }

        public decimal AmountAfterTheDay(Period period)
        {
            return period.IsSameWithEnd(this) ? AmountAfterTheDay(period.EndDate) : 0;
        }

        public decimal AmountBetweenRange(Period period)
        {
            return period.IsBetweenRange(this) ? Amount : 0;
        }

        public decimal AmountOfBudget(Period period)
        {
            var amountOfBudget = 0m;
            amountOfBudget -= AmountBeforeTheDay(period);
            amountOfBudget -= AmountAfterTheDay(period);
            amountOfBudget += AmountBetweenRange(period);
            return amountOfBudget;
        }
    }
}
