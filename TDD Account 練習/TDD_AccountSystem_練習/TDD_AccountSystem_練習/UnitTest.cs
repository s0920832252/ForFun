using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace TDD_AccountSystem_練習
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void QueryBudget_InvalidInput_GetZero()
        {
            var givenBudgets = GivenBudgets(new Budget { });
            QueryAmountShouldBe(0, new DateTime(2020, 4, 1), new DateTime(2020, 03, 31), givenBudgets);
        }


        [Test]
        public void QueryBudget_QueryOneMonthInDB_GetBudgetOfBudget()
        {
            var accounting = GivenBudgets(new Budget {YearMonth = "202004", Amount = 30});
            QueryAmountShouldBe(30, DateTime.Parse("2020/04/01"), DateTime.Parse("2020/04/30"), accounting);
        }

        [Test]
        public void QueryBudget_QueryOneDay_GetBudgetOfDay()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30});
            QueryAmountShouldBe(1, new DateTime(2020, 4, 1), new DateTime(2020, 4, 1), givenBudgets);
        }

        [Test]
        public void QueryBudget_QueryDays_GetBudgetOfDays()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30});
            QueryAmountShouldBe(7, DateTime.Parse("2020/04/01"), DateTime.Parse("2020/04/07"), givenBudgets);
        }

        [Test]
        public void QueryBudget_QueryAcrossTwoMonth_GetBudget()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30},
                                            new Budget() {YearMonth = "202005", Amount = 31});
            QueryAmountShouldBe(2, new DateTime(2020, 4, 30), new DateTime(2020, 5, 1), givenBudgets);
        }

        [Test]
        public void QueryBudget_QueryAcrossThirdMonth_GetBudget()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30},
                                            new Budget() {YearMonth = "202005", Amount = 31},
                                            new Budget() {YearMonth = "202006", Amount = 30});
            QueryAmountShouldBe(33, new DateTime(2020, 4, 30), new DateTime(2020, 6, 1), givenBudgets);
        }

        [Test]
        public void QueryBudget_QueryOutSingleRangeOfDB_GetBudgetOfIntersection()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30});
            QueryAmountShouldBe(7, new DateTime(2020, 1, 1), new DateTime(2020, 4, 7), givenBudgets);
            QueryAmountShouldBe(7, new DateTime(2020, 4, 24), new DateTime(2020, 12, 7), givenBudgets);
        }

        [Test]
        public void QueryBudget_QueryOutTwoSideRangeOfDb_GetBudgetOfIntersection()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30});
            QueryAmountShouldBe(30, new DateTime(2020, 1, 1), new DateTime(2020, 12, 30), givenBudgets);
        }

        [Test]
        public void QueryableBudget_QueryYears_GetBudgetOfYears()
        {
            var givenBudgets = GivenBudgets(new Budget() {YearMonth = "202004", Amount = 30},
                                            new Budget() {YearMonth = "202104", Amount = 30},
                                            new Budget() {YearMonth = "202205", Amount = 31});
            QueryAmountShouldBe(91, new DateTime(2020, 1, 1), new DateTime(2022, 12, 7), givenBudgets);
        }

        private static void QueryAmountShouldBe(int        expected, DateTime startDate, DateTime endDate,
                                                Accounting accounting)
        {
            var actual = accounting.QueryBudget(startDate, endDate);
            Assert.AreEqual(expected, actual);
        }

        private static Accounting GivenBudgets(params Budget[] budgets)
        {
            var mock = new Mock<IBudgetRepo>();
            mock.Setup(s => s.GetAll())
                .Returns(budgets.ToList());
            var accounting = new Accounting() {Repo = mock.Object};
            return accounting;
        }
    }
}