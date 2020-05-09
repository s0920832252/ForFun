namespace TDD數字練習
{
    public class Alphanumeric
    {
        public string GetStr(string str)
        {
            if (str.Length > 1)
            {
                return $"{char.ToUpper(str[0])}-{char.ToUpper(str[1])}{char.ToLower(str[1])}";
            }

            return str;
        }
    }
}