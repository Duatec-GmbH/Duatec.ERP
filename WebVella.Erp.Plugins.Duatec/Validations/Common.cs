namespace WebVella.Erp.Plugins.Duatec.Validations
{
    internal class Common
    {
        public static string InvalidCharacters(string value, Predicate<char> isValid)
        {
            var invalidChars = value.Where(value => !isValid(value))
                .Order()
                .Distinct()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();

            if (invalidChars.Length == 0)
                return string.Empty;

            if (invalidChars.Length == 1)
                return $"'{invalidChars[0]}'";

            return $"{{ {string.Join(", ", invalidChars.Select(c => $"'{c}'")) }}}";
        }
    }
}
