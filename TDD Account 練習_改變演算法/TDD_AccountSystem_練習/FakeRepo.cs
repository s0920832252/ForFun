using System.Collections.Generic;

namespace TDD_AccountSystem_練習
{
    class FakeRepo : IBudgetRepo
    {
        public List<Budget> GetAll()
        {
            var list  = new List<Budget>();
            var dec09 = new Budget {Amount = 30, YearMonth = "201909"};
            list.Add(dec09);

            var dec11 = new Budget {Amount = 300, YearMonth = "201911"};
            list.Add(dec11);

            var dec12 = new Budget {Amount = 3100, YearMonth = "201912"};
            list.Add(dec12);

            var dec01 = new Budget {Amount = 31000, YearMonth = "202001"};
            list.Add(dec01);

            var dec202012 = new Budget {Amount = 310000, YearMonth = "202012"};
            list.Add(dec202012);

            return list;
        }
    }
}