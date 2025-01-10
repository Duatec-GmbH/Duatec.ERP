using System.Text.RegularExpressions;

namespace WebVella.Erp.Utilities
{
    public static partial class Url
    {
        [GeneratedRegex("/[a-z]/", RegexOptions.Compiled)]
        private static partial Regex PageKindRegex();

        public static string ReplacePageKind(string url, char pageKind)
        {
            var match = PageKindRegex().Match(url);

            if (!match.Success)
                return null!;

            var result = url[..(match.Index + 1)] + $"{pageKind}/";
            var guidStart = result.Length;
            var guidEnd = url.IndexOf('/', guidStart);
            var guid = url[guidStart..guidEnd];

            return result + guid;
        }

        public static string RemoveParameters(string url)
        {
            var idx = url.IndexOf('?');
            return idx < 0 ? url : url[..idx];
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
