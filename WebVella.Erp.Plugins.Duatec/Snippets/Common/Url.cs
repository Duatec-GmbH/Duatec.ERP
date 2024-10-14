using System.Text.RegularExpressions;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Common
{
    public static class Url
    {
        public static string ReplacePageKind(BaseErpPageModel pageModel, char pageKind)
        {
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
            var match = Regex.Match(pageModel.CurrentUrl, "/[a-z]/", RegexOptions.Compiled);
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
            if (!match.Success)
                return null!;

            var result = pageModel.CurrentUrl[..(match.Index + 1)] + $"{pageKind}/";
            var guidStart = result.Length;
            var guidEnd = pageModel.CurrentUrl.IndexOf('/', guidStart);
            var guid = pageModel.CurrentUrl[guidStart..guidEnd];

            return result + guid;
        }
    }
}
