namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class StringExtensions
    {
        public static string FirstToUpper(this string? s)
        {
            if(string.IsNullOrEmpty(s))
                return string.Empty;
            if (!char.IsLetter(s[0]))
                return s;

            return char.ToUpper(s[0]) + s[1..];
        }
    }
}
