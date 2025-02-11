using System.Text;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class Text
    {
        public static string FancyfySnakeCase(string entityName)
            => entityName.ToLower().Replace('_', ' ');

        public static string FancyfyPascalCase(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (text.Length == 1)
                return text;

            var sb = new StringBuilder(text.Length * 2);

            sb.Append(text[0]);
            foreach (var c in text.Skip(1))
            {
                if (char.IsUpper(c))
                    sb.Append($" {char.ToLower(c)}");
                else sb.Append(c);
            }
            return sb.ToString();
        }

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
