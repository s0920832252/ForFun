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
            var input        = "A";
            var expected     = "A";
            var alphanumeric = new Alphanumeric();
            var result       = alphanumeric.GetStr(input);
            Assert.AreEqual(expected, result);
        }
    }
}