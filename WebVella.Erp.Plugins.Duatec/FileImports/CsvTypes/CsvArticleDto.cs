namespace WebVella.Erp.Plugins.Duatec.FileImports.CsvTypes
{
    internal class CsvArticleDto
    {
        public CsvArticleDto(string partNumber, string orderNumber, int amount, int denomination)
        {
            PartNumber = partNumber;
            OrderNumber = orderNumber;
            Amount = amount;
            Denomination = denomination;
        }

        public string PartNumber { get; }

        public string OrderNumber { get; }

        public int Amount { get; }

        public int Denomination { get; }
    }
}
