namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class Text
    {
        public static string FancyfySnakeCaseStartWithUpper(string entityName)
            => char.ToUpper(entityName[0]) + Utilities.Text.FancyfySnakeCase(entityName[1..]);

        public static string InvalidCharacters(string value, Predicate<char> charIsAllowed)
        {
            var invalidChars = value.Where(value => !charIsAllowed(value))
                .Order()
                .Distinct()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray();

            if (invalidChars.Length == 0)
                return string.Empty;

            if (invalidChars.Length == 1)
                return $"'{invalidChars[0]}'";

            return $"{{ {string.Join(", ", invalidChars.Select(c => $"'{c}'"))}}}";
        }
    }
}
