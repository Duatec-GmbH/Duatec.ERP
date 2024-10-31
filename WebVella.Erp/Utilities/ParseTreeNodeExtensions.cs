using System.Linq;
using Irony.Parsing;

namespace WebVella.Erp.Utilities
{
	internal static class ParseTreeNodeExtensions
	{
		public static string GetText(this ParseTreeNode node)
		{
			var s = node.Token != null ?
				node.Token.ValueString : string.Empty;

			if (node.ChildNodes != null && node.ChildNodes.Count > 0)
				s += string.Concat(node.ChildNodes.Select(child => child.GetText()));

			return s;
		}
	}
}
