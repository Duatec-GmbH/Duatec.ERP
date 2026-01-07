using System.Text;
using WebVella.Erp.Plugins.Duatec.DataSource;

namespace DbPatcher.Scripts
{
    internal class OrderList
    {
        public static void Export(Guid projectId, string filePath)
        {
            var records = OrderListEntries4Project.Execute(projectId)
                .OrderBy(oe => oe.GetArticle().PartNumber);

            var sb = new StringBuilder();

            foreach (var record in records)
            {
                sb.Append(record.GetArticle().PartNumber);
                sb.Append('\t');
                sb.Append(record.GetArticle().TypeNumber);
                sb.Append('\t');
                sb.Append(record.GetArticle().OrderNumber);
                sb.Append('\t');
                sb.Append(record.GetArticle().GetManufacturer().Name);
                sb.Append('\t');
                sb.Append(record.GetArticle().Designation.Replace('\n', ' ').Replace("\r", string.Empty).Replace('\t', ' '));
                sb.Append('\t');
                var first = true;
                foreach (var order in record.GetOrders())
                {
                    if (!first)
                        sb.Append(", ");

                    first = false;

                    sb.Append(order.Number);
                }
                sb.Append('\t');
                sb.Append($"{(int)record.Demand}");
                sb.Append('\t');
                sb.Append($"{(int)record.OrderedAmount}");
                sb.Append('\t');
                sb.Append($"{(int)record.ReceivedAmount}");
                sb.Append('\t');
                sb.Append($"{(int)record.InventoryAmount}");
                sb.Append('\t');
                sb.Append($"{record.State}");
                sb.AppendLine();
            }

            using var fs = File.Create(filePath);

            using var writer = new StreamWriter(fs);

            writer.Write(sb.ToString());
        }
    }
}
