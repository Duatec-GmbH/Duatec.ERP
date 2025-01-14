using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-thead", ParentTag = "wv-table")]
	public class WvTHead : TagHelperBase
	{
		protected override string OutputTag => "thead";
	}
}
