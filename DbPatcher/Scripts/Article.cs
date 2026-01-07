using System.Text;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace DbPatcher.Scripts
{
    public static class Article
    {
        public static void ExportAll(string filePath)
        {
            var articleRepo = new ArticleRepository();


            var sb = new StringBuilder();

            foreach(var article in articleRepo.FindAll().OrderBy(a => a.PartNumber))
                sb.AppendLine($"{article.Id}\t{article.PartNumber}\t{article.TypeNumber}\t{article.Designation.Replace('\n', ' ').Replace("\r", string.Empty).Replace('\t', ' ')}");

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
