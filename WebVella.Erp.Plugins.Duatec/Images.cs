using System.Text.RegularExpressions;
using WebVella.Erp.Database;

namespace WebVella.Erp.Plugins.Duatec
{
    public static partial class Images
    {
        public static string FilePath = "/fs/image/";

        public static string? GetOrDownload(string url, Guid? userId, DbContext? dbContext = null)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            var fileRepo = new DbFileRepository(dbContext);
            DbFile dbFile;

            if (LooksLikeSystemImage(url))
            {
                var filePath = SystemFilePath(url);
                dbFile = fileRepo.Find(filePath);
                if (dbFile != null)
                    return "/fs" + filePath;
            }

            var name = TrimFront(url);
            while (name.StartsWith('/'))
                name = name[1..];

            name = FileRegex().Replace(name, "_");

            if (string.IsNullOrEmpty(url))
                return null;

            if (!char.IsLetter(name[0]))
                name = 'i' + name;

            name = $"/image/{name}".ToLowerInvariant();
            dbFile = fileRepo.Find(name);

            if (dbFile == null)
            {
                using var client = new HttpClient()
                {
                    Timeout = new TimeSpan(0, 0, 10),
                    MaxResponseContentBufferSize = 52428800,
                };

                try
                {
                    var t = client.GetStreamAsync(url);
                    t.Wait();

                    using var stream = t.Result;
                    using var ms = new MemoryStream();

                    stream.CopyTo(ms);
                    var bytes = ms.ToArray();

                    dbFile = fileRepo.Create(name, bytes, DateTime.UtcNow, userId);
                }
                catch
                {
                    return null;
                }
            }

            return "/fs" + dbFile.FilePath;
        }

        [GeneratedRegex("[^\\w\\d._+ -]+")]
        private static partial Regex FileRegex();

        private static bool LooksLikeSystemImage(string url)
        {
            if (url.StartsWith(FilePath))
                return true;
            else if (url.Contains(FilePath))
            {
                url = TrimFront(url);
                url = url[url.IndexOf('/')..];
                return url.StartsWith(FilePath);
            }
            return false;
        }

        private static string SystemFilePath(string url)
        {
            url = TrimFront(url);
            url = url[url.IndexOf('/')..];
            url = url["/fs".Length..];
            url = TrimEnd(url);
            return url;
        }

        private static string TrimFront(string url)
        {
            if (url.StartsWith("https://"))
                return url["https://".Length..];
            else if (url.StartsWith("http://"))
                return url["http://".Length..];
            return url;
        }

        private static string TrimEnd(string url)
        {
            if (url.Contains('?'))
                return url[..url.IndexOf('?')];
            return url;
        }
    }
}
