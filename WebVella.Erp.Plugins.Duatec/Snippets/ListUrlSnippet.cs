﻿using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class ListUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => PageUrl.EntityList(pageModel);
    }
}
