using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-td")]
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

			result = AppendString(result, ToStyle(HorizontalAlignment));
			result = AppendString(result, ToStyle(VerticalAlignment));

			return result;
		}

		private static string ToStyle(WvHorizontalAlignmentType horizontalAlign)
		{
			return horizontalAlign switch
			{
				WvHorizontalAlignmentType.Left => "text-align:left",
				WvHorizontalAlignmentType.Center => "text-align:center",
				WvHorizontalAlignmentType.Right => "text-align:right",
				_ => string.Empty
			};
		}

		private static string ToStyle(WvVerticalAlignmentType horizontalAlign)
		{
			return horizontalAlign switch
			{
				WvVerticalAlignmentType.Top => "vertical-align:top",
				WvVerticalAlignmentType.Middle => "vertical-align:middle",
				WvVerticalAlignmentType.Bottom => "vertical-align:bottom",
				_ => string.Empty
			};
		}
	}
}
