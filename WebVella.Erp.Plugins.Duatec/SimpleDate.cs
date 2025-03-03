namespace WebVella.Erp.Plugins.Duatec
{
    internal static class SimpleDate
    {
        public static string ToSimpleDateString(this DateTime dateTime)
        {
            var dt = dateTime.ToLocalTime();

            return $"{dt.Day:00}.{dt.Month:00}.{dt.Year:0000}";
        }

        public static bool TryParse(string s, out DateTime result)
        {
            result = default;

            s = s.Trim();

            var dayString = Extract(ref s, char.IsAsciiDigit);
            if (dayString.Length <= 0 || !int.TryParse(dayString, out var day))
                return false;

            s = s.TrimStart();
            var delimiter = Extract(ref s, IsDelimiter);
            if (delimiter.Length <= 0)
                return false;

            s = s.TrimStart();
            var monthString = Extract(ref s, char.IsAsciiDigit);
            if (monthString.Length <= 0 || !int.TryParse(monthString, out var month))
                return false;

            s = s.TrimStart();
            delimiter = Extract(ref s, IsDelimiter);
            if (delimiter.Length <= 0)
                return false;

            s = s.TrimStart();
            var yearString = Extract(ref s, char.IsAsciiDigit);
            if (yearString.Length < 1 || !int.TryParse(yearString, out var year))
                return false;

            if (yearString.Length < 4)
                year += 2000;

            result = new DateTime(year, month, day);
            return true;
        }

        private static bool IsDelimiter(char c)
            => c == '.';

        private static string Extract(ref string s, Predicate<char> predicate)
        {
            var i = 0;
            while (i < s.Length && predicate(s[i]))
                i++;

            var result = s[0..i];
            s = s[i..];
            return result;
        }
    }
}
