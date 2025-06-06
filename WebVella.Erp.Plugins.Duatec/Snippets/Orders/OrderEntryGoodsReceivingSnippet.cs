﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.Orders
{
    [Snippet]
    internal class OrderEntryGoodsReceivingSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
        {
            var rec = pageModel.TryGetDataSourceProperty<EntityRecord>("RowRecord");
            if (rec == null)
                return string.Empty;

            var receivings = rec[$"${ExtendedOrderEntry.ExtendedRelations.GoodsReceivings}"] as List<EntityRecord>;
            if (receivings == null || receivings.Count == 0)
                return string.Empty;

            var links = receivings
                .OrderBy(o => (DateTime)o[GoodsReceiving.Fields.TimeStamp])
                .Select(AnchorTag);

            return string.Join(", ", links);
        }

        private static string AnchorTag(EntityRecord record)
            => $"<a target=\"_blank\" href=\"{Url(record)}\">{Presentation(record)}</a>";

        private static string Url(EntityRecord record)
            => $"/goods-receiving/history/goods-receiving/r/{record["id"]}/detail";

        private static string Presentation(EntityRecord record)
        {
            var dt = (DateTime)record[GoodsReceiving.Fields.TimeStamp];
            dt = TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.FindSystemTimeZoneById(ErpSettings.TimeZoneName));
            return dt.Date.ToString("dd.MMM.yyyy");
        }
    }
}
