namespace TDD數字練習
{
    public class Alphanumeric
    {
        public string GetStr(string str)
        {
            if (str.Length == 2)
            {
                var firstChar = str[0];
                var secondChar = str[1];
                return $"{ToUpper(firstChar)}-{ToUpper(secondChar)}{ToLower(secondChar)}";
            }

            return str;
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