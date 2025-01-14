using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Web.TagHelpers
{
	public static class Extensions
	{
		public static void AddCssClass(this TagHelperOutput output, string cssClass) {
			var processed = false;
			if (output.Attributes.ContainsName("class")) {
				if (output.Attributes.TryGetAttribute("class", out TagHelperAttribute attribute)) {
					if (attribute.Value != null && !String.IsNullOrWhiteSpace(attribute.Value.ToString())) {
						output.Attributes.SetAttribute("class", attribute.Value.ToString() + " " + cssClass);
						processed = true;
					}
				}
			}

			if (!processed) {
				output.Attributes.SetAttribute("class", cssClass);
			}
		}
		public static void AddCssClass(this TagHelperOutput output, List<string> cssClasses) {
			var processed = false;
			if (output.Attributes.ContainsName("class"))
			{
				if (output.Attributes.TryGetAttribute("class", out TagHelperAttribute attribute))
				{
					if (attribute.Value != null && !String.IsNullOrWhiteSpace(attribute.Value.ToString()))
					{
						output.Attributes.SetAttribute("class", attribute.Value.ToString() + " " + String.Join(" ", cssClasses));
						processed = true;
					}
				}
			}

			if (!processed)
			{
				output.Attributes.SetAttribute("class", String.Join(" ", cssClasses));
			}
		}

		internal static string ToStyle(this WvHorizontalAlignmentType horizontalAlign)
		{
			return horizontalAlign switch
			{
				WvHorizontalAlignmentType.Left => "text-align:left",
				WvHorizontalAlignmentType.Center => "text-align:center",
				WvHorizontalAlignmentType.Right => "text-align:right",
				_ => string.Empty
			};
		}

		internal static string ToStyle(this WvVerticalAlignmentType horizontalAlign)
		{
			return horizontalAlign switch
			{
				WvVerticalAlignmentType.Top => "vertical-align:top",
				WvVerticalAlignmentType.Middle => "vertical-align:middle",
				WvVerticalAlignmentType.Bottom => "vertical-align:bottom",
				_ => string.Empty
			};
		}

		internal static void SetAttribute(this TagHelperOutput output, string key, string? value)
		{
			if (!string.IsNullOrEmpty(value))
				output.Attributes.SetAttribute(key, value);
		}
	}
}
