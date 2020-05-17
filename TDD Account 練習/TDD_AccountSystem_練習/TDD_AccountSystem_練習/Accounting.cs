﻿using System;
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
                    var days = Days(startDate, endDate, budget);
                    var daysInMonth = budget.DaysInMonth();
                    amountOfBudget += (decimal)budget.Amount / daysInMonth * days;
                }

                currentDate = currentDate.AddMonths(1);
            }

            return amountOfBudget;
        }

        private static int Days(DateTime startDate, DateTime endDate, Budget budget)
        {
            DateTime budgetTime = budget.DateTimeFromBudget();
            DateTime start;
            DateTime end;
            if (budgetTime.ToString("yyyyMM") == startDate.ToString("yyyyMM"))
            {
                start = startDate;
                end   = budget.LastDay();
            }
            else if (budgetTime.ToString("yyyyMM") == endDate.ToString("yyyyMM"))
            {
                start = budget.FirstDay();
                end   = endDate;
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