using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec
{
    public enum OrderListEntryState
    {
        [SelectOption(Label = "Complete")]
        Complete = 1,
        [SelectOption(Label = "Incomplete")]
        Incomplete = 2,
        [SelectOption(Label = "To Order")]
        ToOrder = 3,
    }
}
