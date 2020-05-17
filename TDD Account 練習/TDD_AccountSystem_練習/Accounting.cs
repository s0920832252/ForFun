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

            var queryPeriod = new Period(startDate, endDate);
            return Repo.GetAll().Sum(budget => budget.OverLappingAmount(queryPeriod));
        }

        public IBudgetRepo Repo { get; set; }
    }
}