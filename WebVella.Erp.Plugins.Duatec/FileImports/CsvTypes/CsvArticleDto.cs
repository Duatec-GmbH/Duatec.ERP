namespace WebVella.Erp.Plugins.Duatec.FileImports.CsvTypes
{
    internal class CsvArticleDto
    {
        public CsvArticleDto(string partNumber, string orderNumber, string typeNumber, string manufacturerShortName, int amount)
        {
            PartNumber = partNumber;
            OrderNumber = orderNumber;
            TypeNumber = typeNumber;
            ManufacturerShortName = manufacturerShortName;
            Amount = amount;
        }

        public string PartNumber { get; }

        public string OrderNumber { get; }

        public string TypeNumber { get; }

        public string ManufacturerShortName { get; }

        public int Amount { get; }
    }
}
