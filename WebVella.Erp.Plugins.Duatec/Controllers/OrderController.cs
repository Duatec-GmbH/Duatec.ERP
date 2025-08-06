using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;

namespace WebVella.Erp.Plugins.Duatec.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly RecordManager _recMan = new();

        [HttpGet]
        [Route("/api/v3.0/o/orders/free-order-numbers/all")]
        public ActionResult GetFreeOrderNumberLookup()
        {
            var orders = new OrderRepository(_recMan).FindAll();
            var projects = new ProjectRepository(_recMan).FindAll()
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
