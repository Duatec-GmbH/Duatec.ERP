using WebVella.Erp.Api.Models;

namespace WebVella.Erp.Plugins.Duatec
{
    public enum OrderListEntryState
    {
        [SelectOption(Label = "Incomplete")]
        Incomplete = 0,
        [SelectOption(Label = "Complete")]
        Complete = 1,
        [SelectOption(Label = "To order")]
        ToOrder = 2,
        [SelectOption(Label = "Abundance")]
        Abundance,
    }

    public enum OrderEntryState
    {
        [SelectOption(Label = "Incomplete")]
        Incomplete = 0,
        [SelectOption(Label = "Complete")]
        Complete = 1,
    }
}
