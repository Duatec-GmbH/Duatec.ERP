using WebVella.Erp.Plugins.Duatec.FileImports.CsvTypes;

namespace WebVella.Erp.Plugins.Duatec.FileImports
{
    internal static class Csv
    {
        public static List<CsvArticleDto> GetArticles(Stream stream)
        {
            var sr = new StreamReader(stream);
            var header = sr.ReadLine();

            if (header == null)
                return [];

            var delimiter = GetDelimiter(header);

            var headers = header.Split(delimiter, StringSplitOptions.TrimEntries);

            var partNumberIndex = Array.IndexOf(headers, "part_number");
            var orderNumberIndex = Array.IndexOf(headers, "order_number");
            var amountIndex = Array.IndexOf(headers, "amount");

            var result = new List<CsvArticleDto>();

            var line = sr.ReadLine();

            while(line != null)
            {
                var cols = line.Split(delimiter, StringSplitOptions.TrimEntries);

                var csvArticle = new CsvArticleDto(
                    partNumber: GetValue(cols, partNumberIndex),
                    orderNumber: GetValue(cols, orderNumberIndex),
                    amount: GetAmount(cols, amountIndex));

                result.Add(csvArticle);

                line = sr.ReadLine();
            }
            return result;
        }

        private static int GetAmount(string[] line, int index)
        {
            var val = GetValue(line, index);
            if (int.TryParse(val, out var result))
                return result;
            return 0;
        }

        private static string GetValue(string[] line, int index)
        {
            if (index < 0 || index >= line.Length)
                return string.Empty;
            return line[index];
        }

        private static char GetDelimiter(string line)
        {
            var tabLen = line.Split('\t').Length;
            var semiColonLen = line.Split(';').Length;
            var commaLen = line.Split(',').Length;

            var max = Math.Max(Math.Max(tabLen, semiColonLen), commaLen);
            if(max == semiColonLen)
                return ';';

            if (max == tabLen)
                return '\t';

            return ',';
        }
    }
}
