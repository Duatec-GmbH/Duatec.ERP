using System.Linq;
using System.Text;

namespace WebVella.Erp.Utilities
{
    public static class Text
    {
        public static string FancyfySnakeCase(string entityName) 
            => entityName.ToLower().Replace('_', ' ');

        public static string FancyfyPascalCase(string text)
        {
            if(string.IsNullOrEmpty(text))
                return string.Empty;

            if (text.Length == 1)
                return text;

            var sb = new StringBuilder(text.Length * 2);

            sb.Append(text[0]);
            foreach(var c in text.Skip(1))
            {
                if (char.IsUpper(c))
                    sb.Append($" {c}");
                else sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
