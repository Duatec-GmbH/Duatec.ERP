using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-td", ParentTag = "wv-tr")]
	public class WvTd : TagHelperBase
	{
		protected override string OutputTag => "td";

		[HtmlAttributeName("width")]
		public string Width { get; set; }

		[HtmlAttributeName("text-nowrap")]
		public bool TextNoWrap { get; set; }

		[HtmlAttributeName("horizontal-align")]
		public WvHorizontalAlignmentType HorizontalAlignment { get; set; }

		[HtmlAttributeName("vertical-align")]
		public WvVerticalAlignmentType VerticalAlignment { get; set; }

		protected override IEnumerable<string> GetStyles()
		{
			var result = base.GetStyles();
			if (TextNoWrap)
				result = result.Append("white-space:nowrap");

			if (!string.IsNullOrEmpty(Width)) 
				result = result.Append($"width:{Width}");

			result = AppendString(result, HorizontalAlignment.ToStyle());
			result = AppendString(result, VerticalAlignment.ToStyle());

			return result;
		}
	}
}
