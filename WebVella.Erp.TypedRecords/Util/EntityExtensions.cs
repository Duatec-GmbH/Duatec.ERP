using System.Text;
using WebVella.Erp.Api.Models;

namespace WebVella.Erp.TypedRecords.Util
{
    public static class EntityExtensions
    {
        public static string FancyName(this Entity entity)
            => FancyfySnakeCase(entity.Name);

        public static string FancyfySnakeCase(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return string.Empty;

            var sb = new StringBuilder();
            var idx = 0;
            while(idx < s.Length)
            {
                var nextCharIdx = idx;
                while (nextCharIdx < s.Length && s[nextCharIdx] == '_')
                    nextCharIdx++;

                if (nextCharIdx == idx)
                {
                    sb.Append(s[idx]);
                    idx++;
                }
                else if (nextCharIdx < s.Length)
                {
                    sb.Append(' ');
                    sb.Append(s[nextCharIdx]);
                    idx = nextCharIdx + 1;
                }
                else break;
            }
            return sb.ToString();
        }
    }
}
