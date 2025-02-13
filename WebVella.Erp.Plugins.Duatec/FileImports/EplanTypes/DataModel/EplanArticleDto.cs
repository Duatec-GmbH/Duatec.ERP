namespace WebVella.Erp.Plugins.Duatec.FileImports.EplanTypes.DataModel
{
    internal class EplanArticleDto
    {
        private EplanArticleDto(string partNumber, string typeNumber, string orderNumber, string description, int amount, List<string> deviceTags)
        {
            PartNumber = partNumber;
            TypeNumber = typeNumber;
            OrderNumber = orderNumber;
            Description = description;
            DeviceTags = deviceTags;
            Amount = amount;
        }

        public string PartNumber { get; }

        public string TypeNumber { get; }

        public string OrderNumber { get; }

        public string Description { get; }

        public List<string> DeviceTags { get; }

        public int Amount { get; }

        public static EplanArticleDto FromPart(EplanPartDto part, List<string> deviceTags, int amount)
        {
            return new(
                partNumber: part.PartNumber,
                typeNumber: part.TypeNumber,
                orderNumber: part.OrderNumber,
                description: part.Description,
                amount: amount,
                deviceTags: deviceTags);
        }
    }
}
