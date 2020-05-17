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


            var currentDate = new DateTime(startDate.Year, startDate.Month, 1);
            var amountOfBudget = 0m;
            var queryPeriod = new Period(startDate, endDate);
            foreach (var budget in Repo.GetAll())
            {
                amountOfBudget += budget.OverLappingAmount(queryPeriod);
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