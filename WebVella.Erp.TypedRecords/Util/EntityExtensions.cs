using System.Text;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Util
{
    public static class EntityExtensions
    {
        public static string FancyName(this Entity entity)
            => FancyfyPascalCase(entity.Name);

        internal static string FancyfyPascalCase(string text)
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
                    sb.Append($" {c}");
                else sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
