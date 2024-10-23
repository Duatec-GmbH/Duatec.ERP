namespace WebVella.Erp.Plugins.Duatec.Snippets.Base
{
    public abstract class ListManageSnippetBase : ParameterizedHookFromListSnippetBase
    {
        protected override (string HookParameter, string RecordParameter)[] ParameterInfos
            => [("hId", "id")];
    }
}
