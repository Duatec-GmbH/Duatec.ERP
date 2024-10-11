using System.IO;
using System.Reflection;

namespace WebVella.Erp.Web.Models
{
	internal class Snippet
	{
		public string Name { get; set; }

		public Assembly Assembly { get; set; }

		public string GetText()
		{
			using var stream = Assembly.GetManifestResourceStream(Name);
			using var reader = new StreamReader(stream);
			return reader.ReadToEnd();
		}
	}
}
