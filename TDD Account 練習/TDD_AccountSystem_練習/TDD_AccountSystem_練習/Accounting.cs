using System;
using System.Linq;

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

            if (startDate.Month == endDate.Month)
            {
                return BudgetOfMonth(startDate, (endDate - startDate).Days + 1);
            }

            var amountOfBudget = 0m;
            var currentDate = new DateTime(startDate.Year, startDate.Month, 1);


            while (currentDate <= endDate)
            {
                var budget = Repo.GetAll().FirstOrDefault(model => model.YearMonth == currentDate.ToString("yyyyMM"));
                if (budget != null)
                {
                    var days = Days(new Period(startDate, endDate), budget);
                    var daysInMonth = budget.DaysInMonth();
                    amountOfBudget += (decimal)budget.Amount / daysInMonth * days;
                }

                currentDate = currentDate.AddMonths(1);
            }

            return amountOfBudget;
        }

        public static int Days(Period period, Budget budget)
        {
            DateTime budgetTime = budget.DateTimeFromBudget();
            DateTime start;
            DateTime end;
            if (budgetTime.ToString("yyyyMM") == period.StartDate.ToString("yyyyMM"))
            {
                start = period.StartDate;
                end   = budget.LastDay();
            }
            else if (budgetTime.ToString("yyyyMM") == period.EndDate.ToString("yyyyMM"))
            {
                start = budget.FirstDay();
                end   = period.EndDate;
            }
            else
            {
                start = budget.FirstDay();
                end   = budget.LastDay();
            }

            var days = (end - start).Days + 1;
            return days;
        }

        private decimal BudgetOfMonth(DateTime startDate, int days)
        {
            var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            var budget = Repo.GetAll().FirstOrDefault(model => model.YearMonth == startDate.ToString("yyyyMM"));
            if (budget != null) return (decimal)budget.Amount / daysInMonth * days;
            return 0;
        }


        public IBudgetRepo Repo { get; set; }
    }
}