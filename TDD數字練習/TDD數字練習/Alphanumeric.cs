using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TDD數字練習
{
    public class Alphanumeric
    {
        public string GetStr(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new NotImplementedException();
            }

            if (str?.Length == 1)
            {
                return str;
            }

            if (str?.Length == 2)
            {
                var firstChar  = str[0];
                var secondChar = str[1];
                return $"{GetCorrectFormatStr(firstChar, 1)}-{GetCorrectFormatStr(secondChar, 2)}";
            }

            if (str?.Length == 3)
            {
                var firstChar  = str[0];
                var secondChar = str[1];
                var thirdChar  = str[2];
                return
                        $"{GetCorrectFormatStr(firstChar, 1)}-{GetCorrectFormatStr(secondChar, 2)}-{GetCorrectFormatStr(thirdChar, 3)}";
            }

            return null;
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