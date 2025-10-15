using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    public class PartListController : Controller
    {
        const int sumUp = 0;
        const int rollOut = 1;
        const int threeColumns = 2;

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        [Route("/api/v3.0/p/part-lists/{id}/export")]
        public ActionResult GetExportData([FromRoute] Guid id, [FromQuery] string? delimiter = "tab", [FromQuery] int option = sumUp)
        {
            var recMan = new RecordManager();
            var entries = new PartListRepository(recMan).FindManyEntriesByPartList(id)
                .Include($"${PartListEntry.Relations.Article}.${Article.Relations.Type}")
                .Include($"${PartListEntry.Relations.Article}.${Article.Relations.Manufacturer}");

            if (delimiter == "comma")
                delimiter = ",";
            else if (delimiter == "semicolon")
                delimiter = ";";
            else
                delimiter = "\t";

            var sb = new StringBuilder();

            foreach (var g in entries.GroupBy(e => e.ArticleId).OrderBy(g => g.First().GetArticle().PartNumber))
            {
                var article = g.First().GetArticle();
                var type = article.GetArticleType();

                var designation = article.Designation.Trim()
                    .Replace(delimiter, " ")
                    .Replace("\r\n", " ")
                    .Replace("\n", " ");

                var lineStart = $"{article.PartNumber}{delimiter}" +
                    $"{article.TypeNumber}{delimiter}" +
                    $"{article.OrderNumber}{delimiter}" +
                    $"{article.GetManufacturer().Name}{delimiter}" +
                    $"{designation}{delimiter}";

                if (option == sumUp)
                {
                    var amount = g.Sum(e => (e.Denomination == 0 ? 1 : e.Denomination) * e.Amount);
                    sb.AppendLine($"{lineStart}{amount}");
                }
                else
                {
                    foreach (var entry in g)
                    {
                        if (!type.IsDivisible || entry.Denomination == 0)
                        {
                            sb.AppendLine($"{lineStart}{entry.Amount}");
                        }
                        else
                        {
                            if (option == rollOut)
                            {
                                for (var i = 0; i < entry.Amount; i++)
                                    sb.AppendLine($"{lineStart}{entry.Denomination}");
                            }
                            else if (option == threeColumns)
                            {
                                sb.AppendLine($"{lineStart}{entry.Amount}{delimiter}{entry.Denomination}");
                            }
                            else // ERP Format
                            {
                                sb.AppendLine($"{lineStart}{entry.Amount}x{entry.Denomination}");
                            }
                        }
                    }
                }
            }

            return Json(sb.ToString());
        }
    }
}
