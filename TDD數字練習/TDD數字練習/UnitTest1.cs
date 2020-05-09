using System;
using NUnit.Framework;

namespace TDD數字練習
{
    /// <summary>
    /// 英數字重構練習專案 : 修改看看
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
    ///      突然想起來 , 輸入好像可以是數字 ..................................................X你娘的
    ///      開始補上測試
    ///      input 1 -> output 1
    ///      input a1 -> output A-11
    ///      input 1a -> output 1-Aa
    ///      input 123 -> output 1-22-333
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
            AssertStr("B", "B");
        }

        [Test]
        public void GetStr_Aa_AAa()
        {
            AssertStr("Aa", "A-Aa");
        }

        [Test]
        public void GetStr_aa_AAa()
        {
            AssertStr("aa", "A-Aa");
        }

        [Test]
        public void GetStr_aA_AAa()
        {
            AssertStr("aA", "A-Aa");
        }

        [Test]
        public void GetStr_AA_AAa()
        {
            AssertStr("AA", "A-Aa");
        }

        [Test]
        public void GetStr_ab_ABb()
        {
            AssertStr("ab", "A-Bb");
        }

        [Test]
        public void GetStr_ba_BAa()
        {
            AssertStr("ba", "B-Aa");
        }

        [Test]
        public void GetStr_NullOrEmpty_ThrowException()
        {
            static void TestDelegate() => Alphanumeric.GetStr(string.Empty);

            static void TestDelegate2() => Alphanumeric.GetStr(null);

            Assert.Throws<NotImplementedException>(TestDelegate);
            Assert.Throws<NotImplementedException>(TestDelegate2);
        }

        [Test]
        public void GetStr_1_1()
        {
            AssertStr("1","1");
        }

        [Test]
        public void GetStr_a1_A_11()
        {
            AssertStr("a1","A-11");
        }

        [Test]
        public void GetStr_1a_1Aa()
        {
            AssertStr("1a","1-Aa");
        }

        [Test]
        public void GetStr_123_122333()
        {
            AssertStr("123","1-22-333");
        }

        [Test]
        public void GetStr_abc_ABbCcc()
        {
            AssertStr("abc", "A-Bb-Ccc");
        }

        [Test]
        public void GetStr_A2c4E6_A22Ccc4444Eeeee666666()
        {
            AssertStr("A2c4E6","A-22-Ccc-4444-Eeeee-666666");
        }

        [Test]
        public void GetStr_1a3D5f_1Aa333Dddd55555Ffffff()
        {
            AssertStr("1a3D5f","1-Aa-333-Dddd-55555-Ffffff");
        }

        private static void AssertStr(string input, string expected)
        {
            Assert.AreEqual(expected, Alphanumeric.GetStr(input));
        }
    }
}