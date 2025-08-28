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

            var partNumberIndex = -1;
            var orderNumberIndex = -1;
            var amountIndex = -1;

            const StringComparison comparison = StringComparison.OrdinalIgnoreCase;

            for (var i = 0; i < headers.Length; i++)
            {
                var s = headers[i];

                if (partNumberIndex < 0 && (s.Equals("part_number", comparison) || s.Equals("part number", comparison) || s.Equals("partnumber", comparison)))
                    partNumberIndex = i;

                else if (orderNumberIndex < 0 && (s.Equals("order_number", comparison) || s.Equals("order number", comparison) || s.Equals("ordernumber", comparison)))
                    orderNumberIndex = i;

                else if (amountIndex < 0 && s.Equals("amount", comparison))
                    amountIndex = i;
            }

            var result = new List<CsvArticleDto>();

            var line = sr.ReadLine();

            while(line != null)
            {
                var cols = line.Split(delimiter, StringSplitOptions.TrimEntries);

                var csvArticle = new CsvArticleDto(
                    partNumber: GetValue(cols, partNumberIndex),
                    orderNumber: GetValue(cols, orderNumberIndex),
                    amount: GetAmount(cols, amountIndex),
                    denomination: GetDenomination(cols, amountIndex));

                result.Add(csvArticle);

                line = sr.ReadLine();
            }
            return result;
        }

        private static int GetAmount(string[] line, int index)
        {
            var val = GetValue(line, index);

            if (val.Contains('x'))
                val = val[..val.IndexOf('x')];
            else if (val.Contains('x'))
                val = val[..val.IndexOf('X')];

            if (int.TryParse(val.Trim(), out var result))
                return result;

            return 0;
        }

        private static int GetDenomination(string[] line, int index)
        {
            var val = GetValue(line, index);

            if (val.Contains('x'))
                val = val[(val.IndexOf('x') + 1)..];
            else if (val.Contains('x'))
                val = val[(val.IndexOf('X') + 1)..];
            else
                return 0;

            if (int.TryParse(val.Trim(), out var result))
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
