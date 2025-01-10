namespace WebVella.Erp.Plugins.Duatec.Services.EplanTypes
{
    internal class ArticleImportInfo
    {
        public ArticleImportInfo(string partNumber, string action, Guid typeId)
        {
            PartNumber = partNumber;
            Action = action;
            TypeId = typeId;
        }

        public string PartNumber { get; }

        public string Action { get; }

        public Guid TypeId { get; }
    }
}
