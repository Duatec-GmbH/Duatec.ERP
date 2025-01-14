using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebVella.Erp.Web.TagHelpers
{
	public abstract class TagHelperBase : TagHelper
	{
		protected abstract string OutputTag { get; }

		[HtmlAttributeName("is-visible")]
		public bool IsVisible { get; set; } = true;

		[HtmlAttributeName("class")]
		public string Class { get; set; }

		[HtmlAttributeName("id")]
		public string Id { get; set; }

		[HtmlAttributeName("style")]
		public string Style { get; set; }

		[HtmlAttributeName("name")]
		public string Name { get; set; }


		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if(!IsVisible)
			{
				output.SuppressOutput();
				return;
			}

			output.TagName = OutputTag;

			output.SetAttribute("id", Id);
			output.SetAttribute("name", Name);
			output.SetAttribute("class", JoinString(' ', GetClasses()));
			output.SetAttribute("style", JoinString(';', GetStyles()));

			output.Content.AppendHtml(await output.GetChildContentAsync());
		}

		protected static string JoinString(char seperator, IEnumerable<string> values)
			=> string.Join(seperator, values.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct());

		protected static IEnumerable<string> AppendString(IEnumerable<string> styles, string style)
		{
			if (!string.IsNullOrEmpty(style))
				styles = styles.Append(style);
			return styles;
		}

		protected virtual IEnumerable<string> GetStyles()
		{
			if (string.IsNullOrEmpty(Style))
				return [];
			return Style.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		}

		protected virtual IEnumerable<string> GetClasses()
		{
			if (string.IsNullOrEmpty(Class))
				return [];
			return Class.Split(" ", StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
