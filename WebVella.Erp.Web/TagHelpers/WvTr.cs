using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-tr", ParentTag = "wv-tbody")]
	public class WvTr : TagHelperBase
	{
		protected override string OutputTag => "tr";
	}
}
