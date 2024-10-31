using WebVella.Erp.Eql;
using WebVella.Erp.Test.Eql.Resources;

namespace WebVella.Erp.Test.Eql
{
    internal class EqlBuilderTests
    {
        [Test]
        [TestCaseSource(typeof(Queries), nameof(Queries.RelationalOrderByResources))]
        public void EqlBuilderCanOrderByRelationProperties(string query)
        {
            var builder = new EqlBuilder(query);
            var result = builder.Build();

            Assert.That(result.Errors.Count, Is.Zero);
        }
    }
}
