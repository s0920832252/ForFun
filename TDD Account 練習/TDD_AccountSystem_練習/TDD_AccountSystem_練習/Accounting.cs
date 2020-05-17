using System;
using System.Linq;

namespace TDD_AccountSystem_練習
{
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
                    int days;
                    if (currentDate.ToString("yyyyMM") == startDate.ToString("yyyyMM"))
                    {
                        var start = startDate;
                        var dateTime = budget.DateTimeFromBudget();
                        var end = new DateTime(dateTime.Year, dateTime.Month, budget.DaysInMonth());
                        days = (end - start).Days + 1;
                    }
                    else if (currentDate.ToString("yyyyMM") == endDate.ToString("yyyyMM"))
                    {
                        var dateTime = budget.DateTimeFromBudget();
                        var start = new DateTime(dateTime.Year,dateTime.Month,1);
                        var end = endDate;
                        days = (end - start).Days + 1;
                    }
                    else
                    {
                        var dateTime = budget.DateTimeFromBudget();
                        var start    = new DateTime(dateTime.Year, dateTime.Month, 1);
                        var end = new DateTime(dateTime.Year, dateTime.Month, budget.DaysInMonth());
                        days = (end - start).Days + 1;
                    }

                    var daysInMonth = budget.DaysInMonth();
                    amountOfBudget += (decimal)budget.Amount / daysInMonth * days;
                }

                currentDate = currentDate.AddMonths(1);
            }

            return amountOfBudget;
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