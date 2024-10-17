using System.Text.RegularExpressions;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Util
{
    public static partial class Url
    {
        [GeneratedRegex("/[a-z]/", RegexOptions.Compiled)]
        private static partial Regex PageKindRegex();

        public static string ReplacePageKind(BaseErpPageModel pageModel, char pageKind)
        {
            var match = PageKindRegex().Match(pageModel.CurrentUrl);

            if (!match.Success)
                return null!;

            var result = pageModel.CurrentUrl[..(match.Index + 1)] + $"{pageKind}/";
            var guidStart = result.Length;
            var guidEnd = pageModel.CurrentUrl.IndexOf('/', guidStart);
            var guid = pageModel.CurrentUrl[guidStart..guidEnd];

            return result + guid;
        }

        public static string RemoveParameter(string url, string parameter)
        {
            var startIdx = url.IndexOf($"?{parameter}");
            if (startIdx < 0)
                startIdx = url.IndexOf($"&{parameter}");
            if (startIdx < 0)
                return url;

            var endIdx = url.IndexOf('&', startIdx + parameter.Length + 1);
            if (endIdx < 0)
                return url[..startIdx];

            if (url[startIdx] == '?')
                return url[..(startIdx + 1)] + url[(endIdx + 1)..];
            return url[..startIdx] + url[endIdx..];
        }
    }
}
