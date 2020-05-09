using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TDD數字練習
{
    public class Alphanumeric
    {
        public static string GetStr(string str)
        {
            return string.IsNullOrEmpty(str) ?
                           throw new NotImplementedException() :
                           str.Select((c,    index) => GetCorrectFormatStr(c, index + 1))
                              .Aggregate((l, r) => $"{l}-{r}");
        }

        private static string GetCorrectFormatStr(char c, int count)
        {
            return string.Concat(Enumerable.Repeat(c, count)
                                           .Select((s, index) => index == 0 ? ToUpper(s) : ToLower(s)));
        }

        private static char ToLower(char secondChar)
        {
            return char.ToLower(secondChar);
        }

        private static char ToUpper(char c)
        {
            return char.ToUpper(c);
        }
    }
}