using System.Text.RegularExpressions;
using WebVella.Erp.Database;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Pages.Articles
{
    internal static partial class Images
    {
        public static string FilePath = "/fs/images/";

        public static DbFile? GetOrDownload(string filePathOrUrl, Guid? userId, DbContext? dbContext = null)
        {
            if (string.IsNullOrEmpty(filePathOrUrl))
                return null;

            var fileRepo = new DbFileRepository(dbContext);
            DbFile dbFile;

            if (filePathOrUrl.StartsWith(FilePath))
            {
                dbFile = fileRepo.Find(filePathOrUrl["/fs".Length..]);
                if (dbFile != null)
                    return dbFile;
            }

            var name = filePathOrUrl;

            if (name.StartsWith("https://"))
                name = name["https://".Length..];

            if (name.StartsWith("www."))
                name = name["www.".Length..];

            name = FileRegex().Replace(name, "_");
            name = $"/images/{name}".ToLowerInvariant();

            dbFile = fileRepo.Find(name);
            if (dbFile == null)
            {
                using var client = new HttpClient()
                {
                    Timeout = new TimeSpan(0, 0, 10),
                    MaxResponseContentBufferSize = 51200,
                };

                try
                {
                    var t = client.GetStreamAsync(filePathOrUrl);
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

            dbFile.FilePath = "/fs" + dbFile.FilePath;
            return dbFile;
        }

        [GeneratedRegex("[^\\w\\d.+ -]+")]
        private static partial Regex FileRegex();
    }
}
