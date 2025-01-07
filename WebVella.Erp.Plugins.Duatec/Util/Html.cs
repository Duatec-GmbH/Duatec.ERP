namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal class Html
    {
        public static string UrlImage(string? url, int? height, int? width)
        {
            var img = $"<img src=\"{url}\"";
            if (height.HasValue)
                img += $" height=\"{height}\"";
            if(width.HasValue)
                img += $" width=\"{width}\"";
            img += "/>";
            return img ;
        }
    }
}
