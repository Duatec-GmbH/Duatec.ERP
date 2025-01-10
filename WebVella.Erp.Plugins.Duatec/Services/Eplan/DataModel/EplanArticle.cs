namespace WebVella.Erp.Plugins.Duatec.Services.Eplan.DataModel
{
    internal class EplanArticle
    {
        private EplanArticle(string partNumber, string typeNumber, string orderNumber, string description)
        {
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Description = description;
        }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public string Description { get; }

        public static EplanArticle FromPart(EplanPart part)
        {
            return new(
                partNumber: part.PartNumber,
                typeNumber: part.TypeNumber,
                orderNumber: part.OrderNumber,
                description: part.Description);
        }
    }
}
