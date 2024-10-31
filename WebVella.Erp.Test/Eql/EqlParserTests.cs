using Irony.Parsing;
using WebVella.Erp.Eql;
using WebVella.Erp.Test.Eql.Resources;

namespace WebVella.Erp.Test.Eql
{
    internal class EqlParserTests
    {
        private static ParseTree GetParseTree(string source)
        {
            var grammar = new EqlGrammar();
            var language = new LanguageData(grammar);
            var parser = new Parser(language);
            return parser.Parse(source);
        }

        [Test]
        [TestCaseSource(typeof(Queries), nameof(Queries.RelationalOrderByResources))]
        public void GrammarAcceptsNestedRelations(string query)
        {
            var result = GetParseTree(query);

            Assert.That(result.HasErrors(), Is.False);
        }
    }
}
