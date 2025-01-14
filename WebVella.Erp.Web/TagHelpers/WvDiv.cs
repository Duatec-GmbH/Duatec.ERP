using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebVella.Erp.Web.TagHelpers
{
	[HtmlTargetElement("wv-div")]
	public class WvDiv : TagHelperBase
	{
		protected override string OutputTag => "div";
	}
}
