using System;
using System.Collections.Generic;
using System.Linq;
using WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries.Base;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets.OrderLists.Entries
{
    [Snippet]
    internal class OrderListEntryOrderedAmountSnippet : OrderListEntryAmountSnippetBase
    {
        protected override decimal? GetAmount(BaseErpPageModel pageModel)
            => GetDataSourcePropertyFromRecord(pageModel, "ordered") as decimal?;
    }
}
