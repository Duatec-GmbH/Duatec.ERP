namespace WebVella.Erp.Plugins.Duatec.FileImports
{
    internal class ArticleImportResult
    {
        internal ArticleImportResult(
            string partNumber, string typeNumber, string orderNumber, string designation, Guid type, decimal amount, decimal denomination, List<string> deviceTags,
            ArticleImportState importState, string action, string[] availableActions)
        {
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Designation = designation;
            ImportState = importState;
            Amount = amount;
            Type = type;
            Action = action;
            AvailableActions = availableActions;
            DeviceTags = deviceTags;
        }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public string Designation { get; }

        public decimal Amount { get; }

        public List<string> DeviceTags { get; }

        public Guid Type { get; }

        public ArticleImportState ImportState { get; }

        public string Action { get; }

        public string[] AvailableActions { get; }
    }
}
