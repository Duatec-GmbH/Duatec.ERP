#pragma warning disable IDE0005
using System;
#pragma warning restore IDE0005
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataModel;
using WebVella.Erp.Web.Models;

#pragma warning disable CA1050 // Compiler can not create assemblies at runtime
public class ArticleDetailImageSnippet : ICodeVariable
{
    public object Evaluate(BaseErpPageModel pageModel)
    {
        try
        {
            var url = pageModel.TryGetDataSourceProperty<EntityRecord>("Record")?[EntityInfo.Article.Image];
            return $"<img src=\"{url}\" widht=\"200\" height=\"200\"/>";
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }
}
#pragma warning restore CA1050 // Compiler can not create assemblies at runtime

