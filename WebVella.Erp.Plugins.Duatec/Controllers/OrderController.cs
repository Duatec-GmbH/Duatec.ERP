using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Utilities;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        [HttpGet]
        [Route("/api/v3.0/o/orders/{id}/export")]
        public ActionResult GetExportData([FromRoute]Guid id, [FromQuery]string? delimiter = "tab", [FromQuery]int denominationHandle = 0)
        {
            var recMan = new RecordManager();
            var entries = new OrderRepository(recMan).FindManyEntriesByOrder(id)
                .Include($"${OrderEntry.Relations.Article}.${Article.Relations.Type}");

            if (delimiter == "comma")
                delimiter = ",";
            else if (delimiter == "semicolon")
                delimiter = ";";
            else
                delimiter = "\t";

            var sb = new StringBuilder();

            foreach(var entry in entries)
            {
                var article = entry.GetArticle();
                var type = article.GetArticleType();

                if (!type.IsDivisible || entry.Denomination == 0)
                    sb.AppendLine($"{article.OrderNumber}{delimiter}{entry.Amount}");
                else
                {
                    if (denominationHandle == 1) // sum up
                    {
                        sb.AppendLine($"{article.OrderNumber}{delimiter}{entry.Amount * entry.Denomination}");
                    }
                    else if(denominationHandle == 2) // <amount>x<denomination>
                    {
                        sb.AppendLine($"{article.OrderNumber}{delimiter}{entry.Amount}x{entry.Denomination}");
                    }
                    else if(denominationHandle == 3) // <amount>(<denomination>)
                    {
                        sb.AppendLine($"{article.OrderNumber}{delimiter}{entry.Amount}({entry.Denomination})");
                    }
                    else  // roll out
                    {
                        for (var i = 0; i < entry.Amount; i++)
                            sb.AppendLine($"{article.OrderNumber}{delimiter}{entry.Denomination}");
                    }
                }
            }
            return Json(sb.ToString());
        }


        [HttpGet]
        [Route("/api/v3.0/o/orders/free-order-numbers/all")]
        public ActionResult GetFreeOrderNumberLookup()
        {
            var recMan = new RecordManager();
            var orders = new OrderRepository(recMan).FindAll();
            var projects = new ProjectRepository(recMan).FindAll()
                .ToDictionary(p => p.Id!.Value);

            var projectNumbers = projects.Select(kp => kp.Value.Number.ToString())
                .Distinct()
                .ToHashSet();

            var maxNumberLookup = projects
                .ToDictionary(kp => kp.Key, _ => 0L);

            foreach (var order in orders.Where(o => o.Project.HasValue && projects.ContainsKey(o.Project.Value)))
            {
                var number = GetNumber(order.Number, projectNumbers);

                if (number.HasValue)
                {
                    var max = maxNumberLookup[order.Project!.Value];
                    if(number > max)
                    {
                        var p = maxNumberLookup[order.Project.Value];
                        maxNumberLookup[order.Project.Value] =  number.Value;
                    }
                }
            }

            return Json(maxNumberLookup.ToDictionary(kp => kp.Key, kp => $"{projects[kp.Key].Number}_{kp.Value + 1:D3}"));
        }

        private static long? GetNumber(string orderNumber, HashSet<string> projectNumbers)
        {
            var i = 0;
            while(i < orderNumber.Length)
            {
                if (orderNumber[i] == '(' || char.IsWhiteSpace(orderNumber[i]))
                    break;

                else if (char.IsDigit(orderNumber[i]))
                {
                    var j = i + 1;
                    while (j < orderNumber.Length && char.IsDigit(orderNumber[j]))
                        j++;

                    var numberString = orderNumber[i..j];
                    if (!projectNumbers.Contains(numberString) && long.TryParse(numberString, out var l))
                        return l;

                    i = j;
                }
                else i++;
            }

            return null;
        }

    }
}
