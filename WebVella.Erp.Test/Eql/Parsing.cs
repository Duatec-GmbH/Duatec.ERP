using Irony.Parsing;
using WebVella.Erp.Eql;

namespace WebVella.Erp.Test.Eql
{
    internal static class Parsing
    {
        public static ParseTree GetTree(string source)
        {
            var grammar = new EqlGrammar();
            var language = new LanguageData(grammar);
            var parser = new Parser(language);
            return parser.Parse(source);
        }
    }
}
