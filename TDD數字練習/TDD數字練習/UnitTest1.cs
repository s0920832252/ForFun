using NUnit.Framework;

namespace TDD數字練習
{
    /// <summary>
    /// 英數字重構練習專案 : 
    /// e.g. input A -> output A
    ///      input B -> output B
    ///      input Aa -> output A-Aa
    ///      input aa -> output A-Aa
    ///      input aA -> output A-Aa
    ///      input AA -> output A-Aa
    ///      input ab -> output A-Bb
    ///      input ba -> output B-Aa
    ///      input abc -> A-Bb-Ccc
    ///      input 無字母 or null -> 丟例外
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetStr_A_A()
        {
            AssertStr("A", "A");
        }

        [Test]
        public void GetStr_B_B()
        {
            AssertStr("B","B");
        }

        [Test]
        public void GetStr_Aa_AAa()
        {
            AssertStr("Aa","A-Aa");
        }

        [Test]
        public void GetStr_aa_AAa()
        {
            AssertStr("aa","A-Aa");
        }

        [Test]
        public void GetStr_aA_AAa()
        {
            AssertStr("aA","A-Aa");
        }

        [Test]
        public void GetStr_AA_AAa()
        {
            AssertStr("AA","A-Aa");
        }

        [Test]
        public void GetStr_ab_ABb()
        {
            AssertStr("ab","A-Bb");
        }

        [Test]
        public void GetStr_ba_BAa()
        {
            AssertStr("ba","B-Aa");
        }

     

        private static void AssertStr(string input, string expected)
        {
            Assert.AreEqual(expected, new Alphanumeric().GetStr(input));
        }
    }
}