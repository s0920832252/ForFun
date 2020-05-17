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
            var currentDate    = new DateTime(startDate.Year, startDate.Month, 1);


            while (currentDate <= endDate)
            {
                var budget = Repo.GetAll().FirstOrDefault(model => model.YearMonth == currentDate.ToString("yyyyMM"));
                if (budget != null)
                {
                    int days;
                    if (currentDate.ToString("yyyyMM") == startDate.ToString("yyyyMM"))
                    {
                        var daysOfMonth = DaysInMonth(budget);
                        days = daysOfMonth - startDate.Day + 1;
                    }
                    else if (currentDate.ToString("yyyyMM") == endDate.ToString("yyyyMM"))
                    {
                        days = endDate.Day;
                    }
                    else
                    {
                        var dayOfMonth = DaysInMonth(budget);
                        days = dayOfMonth;
                    }

                    var daysInMonth = DaysInMonth(budget);
                    amountOfBudget += (decimal) budget.Amount / daysInMonth * days;
                }

                currentDate = currentDate.AddMonths(1);
            }

            return amountOfBudget;
        }

        private static int DaysInMonth(Budget budget)
        {
            var dateTimeFromBudget = DateTimeFromBudget(budget);
            return DateTime.DaysInMonth(dateTimeFromBudget.Year, dateTimeFromBudget.Month);
        }

        private static DateTime DateTimeFromBudget(Budget budget)
        {
            return DateTime.ParseExact(budget.YearMonth,"yyyyMM",null);
        }

        private decimal BudgetOfMonth(DateTime startDate, int days)
        {
            var daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            var budget = Repo.GetAll().FirstOrDefault(model => model.YearMonth == startDate.ToString("yyyyMM"));
            if (budget != null) return (decimal) budget.Amount / daysInMonth * days;
            return 0;
        }


        public IBudgetRepo Repo { get; set; }
    }
}