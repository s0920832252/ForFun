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
                    if (currentDate.Month == startDate.Month)
                    {
                        days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month) - startDate.Day + 1;
                    }
                    else if (currentDate.Year == endDate.Year && currentDate.Month == endDate.Month)
                    {
                        days = endDate.Day;
                    }
                    else
                    {
                        days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                    }

                    var daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
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
