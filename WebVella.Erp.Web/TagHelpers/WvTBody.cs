using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-tbody", ParentTag = "wv-table")]
	public class WvTBody : TagHelperBase
	{
		protected override string OutputTag => "tbody";
	}
}
