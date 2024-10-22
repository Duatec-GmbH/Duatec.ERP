﻿using WebVella.Erp.Api.Models;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Entities;
using WebVella.Erp.Plugins.Duatec.Hooks.Base;

namespace WebVella.Erp.Plugins.Duatec.Hooks.ArticleTypes
{
    [HookAttachment(key: HookKeys.ArticleType.Manage)]
    public class ArticleTypeManageHook : ManageOnListHook
    {
        protected override EntityRecord? Find(Guid id) 
            => ArticleType.Find(id);
    }
}
