namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class ListManageSnippetBase : ParameterizedHookFromListSnippetBase
    {
        protected virtual string IdProperty => "hId";

        protected override (string HookParameter, string RecordParameter)[] ParameterInfos
            => [(IdProperty, "id")];
    }
}
