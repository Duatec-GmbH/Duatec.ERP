using HtmlAgilityPack;
using System.Text.Json.Nodes;
using System.Web;

namespace WebVella.Erp.Plugins.Duatec.Services.ArticleFinders
{
    public enum XPathQueryResolveKind
    {
        None,
        InnerText,
        InnerHtml,
        AttributeValue,
    }

    internal class XPathQuery
    {
        public string Query { get; set; } = string.Empty;

        public XPathQueryResolveKind ResolveKind { get; set; }

        public string[] Arguments { get; set; } = [];

        public string Execute(HtmlNode node)
        {
            try
            {
                var nodes = node.SelectNodes(Query);
                if (nodes == null || nodes.Count == 0)
                    return string.Empty;

                var resultNode = nodes[0];

                var result = ResolveKind switch
                {
                    XPathQueryResolveKind.InnerText => resultNode.InnerText,
                    XPathQueryResolveKind.InnerHtml => resultNode.InnerHtml,
                    XPathQueryResolveKind.AttributeValue => resultNode.Attributes[Arguments[0]].Value,
                    _ => resultNode.ToString() ?? string.Empty
                };

                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static XPathQuery? FromJsonNode(JsonNode? node)
        {
            if(node == null)
                return null;

            var query = node["query"]?.GetValue<string>() ?? string.Empty;
            var argumentNodes = node["arguments"]?.AsArray() ?? [];

            var arguments = new string[argumentNodes.Count];

            for(var i = 0; i< argumentNodes.Count; i++)
                arguments[i] = argumentNodes[i]?.GetValue<string>() ?? string.Empty;

            var kindText = node["resolveKind"]?.ToString() ?? string.Empty;

            XPathQueryResolveKind kind;

            if (TextEqualsKind(kindText, XPathQueryResolveKind.InnerHtml))
                kind = XPathQueryResolveKind.InnerHtml;
            else if (TextEqualsKind(kindText, XPathQueryResolveKind.InnerText))
                kind = XPathQueryResolveKind.InnerText;
            else if (TextEqualsKind(kindText, XPathQueryResolveKind.AttributeValue))
                kind = XPathQueryResolveKind.AttributeValue;

            else kind = XPathQueryResolveKind.None;

            return new()
            {
                Arguments = arguments,
                ResolveKind = kind,
                Query = query
            };
        }

        public XPathQuery SetQueryParameter(string parameterName, string value)
        {
            return new XPathQuery()
            {
                Arguments = Arguments,
                Query = Query.Replace("{" + parameterName + "}", value),
                ResolveKind = ResolveKind
            };
        }

        private static bool TextEqualsKind(string? text, XPathQueryResolveKind kind)
        {
            return !string.IsNullOrWhiteSpace(text) && (
                text.Equals(kind.ToString(), StringComparison.OrdinalIgnoreCase)
                || text.Equals(((int)kind).ToString()));
        }
    }
}
