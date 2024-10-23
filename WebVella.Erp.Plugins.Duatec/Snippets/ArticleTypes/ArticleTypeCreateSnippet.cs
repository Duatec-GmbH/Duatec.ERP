using WebVella.Erp.Plugins.Duatec.Hooks;
using WebVella.Erp.Plugins.Duatec.Snippets.Base;
using WebVella.Erp.Plugins.Duatec.Util;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleTypeCreateSnippet : ParameterizedHookFromListSnippetBase
{
    protected override string HookKey => HookKeys.ArticleType.Create;

    protected override (string HookParameter, string RecordParameter)[] ParameterInfos 
        => [];

    protected override object? GetValue(BaseErpPageModel pageModel)
    {
        pageModel.CurrentUrl = Url.RemoveParameter(pageModel.CurrentUrl, "hId");
        return base.GetValue(pageModel);
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

