using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-table")]
	public class WvTable : TagHelperBase
	{
		protected override string OutputTag => "table";
	}
}
