﻿using WebVella.Erp.Web.Models;
using WebVella.Erp.Utilities;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;

namespace WebVella.Erp.Plugins.Duatec.Snippets
{
    [Snippet]
    public class ManageUrlSnippet : SnippetBase
    {
        protected override object? GetValue(BaseErpPageModel pageModel)
            => Url.ReplacePageKind(pageModel.CurrentUrl, 'm');
    }
}