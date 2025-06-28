namespace _11_Linq
{
    public static class ExtensionMethods
    {
        public static int Power(this int value, int power)
        {
            return (int)Math.Pow(value, power);
        }

        public static string Capitalize(this string value)
        {
            string result = string.Empty;
            result += char.ToUpper(value[0]);
            result += value.Substring(1).ToLower();
            return result;
        }
    }
}
