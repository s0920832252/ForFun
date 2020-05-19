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

            var budgets = Repo.GetAll();

            var startBudget = budgets.FirstOrDefault(budget => budget.YearMonth == startDate.ToString("yyyyMM"));
            decimal amountOfStartBudget = 0m;
            if (startBudget != null)
            {
                var startBudgetAmount = startBudget.Amount;
                var startDateDay = startDate.Day - 1;
                var startDateTime = CreateDateTime(startBudget);
                var startMonthDays = DateTime.DaysInMonth(startDateTime.Year, startDateTime.Month);
                amountOfStartBudget = startBudgetAmount / startMonthDays * startDateDay;
            }

            var endBudget = budgets.FirstOrDefault(budget => budget.YearMonth == endDate.ToString("yyyyMM"));
            decimal amountOfEndBudget = 0m;
            if (endBudget != null)
            {
                var endBudgetAmount = endBudget.Amount;
                var endDateTime = CreateDateTime(endBudget);
                var endMonthDays = DateTime.DaysInMonth(endDateTime.Year, endDateTime.Month);
                var endDateDay = endMonthDays - endDate.Day;
                amountOfEndBudget = endBudgetAmount / endMonthDays * endDateDay;
            }

            var amountOfBudget = 0m;
            var currentDate = new DateTime(startDate.Year, startDate.Month, 1);
            while (currentDate <= endDate)
            {
                var findBudget = budgets.FirstOrDefault(budget => budget.YearMonth == currentDate.ToString("yyyyMM"));
                amountOfBudget += findBudget?.Amount ?? 0;

                currentDate = currentDate.AddMonths(1);
            }
            return amountOfBudget - amountOfStartBudget - amountOfEndBudget;
        }

        private static DateTime CreateDateTime(Budget budget)
        {
            return DateTime.ParseExact(budget.YearMonth, "yyyyMM", null);
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
