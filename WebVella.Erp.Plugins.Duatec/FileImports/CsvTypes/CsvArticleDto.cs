using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebVella.Erp.Plugins.Duatec.FileImports.CsvTypes
{
    internal class CsvArticleDto
    {
        public string PartNumber { get; }

        public string OrderNumber { get; }

        public string TypeNumber { get; }

        public string ManufacturerShortName { get; }
    }
}
