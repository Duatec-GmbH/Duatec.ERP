using WebVella.Erp.Eql;
using WebVella.Erp.Test.Eql.Resources;

namespace WebVella.Erp.Test.Eql
{
    internal class EqlParserTests
    {
        [Test]
        [TestCaseSource(typeof(Queries), nameof(Queries.ValidSelectStatements))]
        public void ParsingValidSelectStatement_DoesNotReportAnyError(string query)
        {
            var result = Parsing.GetTree(query);

            Assert.That(result.HasErrors(), Is.False);
        }
    }
}
