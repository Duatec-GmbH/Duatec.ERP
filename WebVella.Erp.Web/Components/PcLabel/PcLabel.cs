using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Services;
using WebVella.Erp.Exceptions;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace WebVella.Erp.Web.Components
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
	[PageComponent(	Label = "Label", Library = "WebVella", Description = "Renders a label", Version = "0.0.1",
					IconClass = "fas fa-font", IsInline = true)]
	public class PcLabel : PageComponent
	{
		protected ErpRequestContext ErpRequestContext { get; set; }

		public PcLabel([FromServices] ErpRequestContext coreReqCtx)
		{
			ErpRequestContext = coreReqCtx;
		}

		public class PcLabelOptions
		{
			[JsonProperty(PropertyName = "is_visible")]
			public string IsVisible { get; set; } = "";

			[JsonProperty(PropertyName = "class")]
			public string Class { get; set; } = "";

			[JsonProperty(PropertyName = "id")]
			public string Id { get; set; } = "";

			[JsonProperty(PropertyName = "text")]
			public string Text { get; set; } = "";
		}

		public async Task<IViewComponentResult> InvokeAsync(PageComponentContext context)
		{
			try
			{
				ErpPage currentPage;

				if (context.Node == null)
					return await Task.FromResult<IViewComponentResult>(Content("Error: The node Id is required to be set as query parameter 'nid', when requesting this component"));

				var pageFromModel = context.DataModel.GetProperty("Page");

				if (pageFromModel is ErpPage page)
					currentPage = page;
				else
					return await Task.FromResult<IViewComponentResult>(Content("Error: PageModel does not have Page property or it is not from ErpPage Type"));

				var options = context.Options == null
					? new PcLabelOptions()
					: JsonConvert.DeserializeObject<PcLabelOptions>(context.Options.ToString());

				var componentMeta = new PageComponentLibraryService().GetComponentMeta(context.Node.ComponentName);

				ViewBag.Options = options;
				ViewBag.Node = context.Node;
				ViewBag.ComponentMeta = componentMeta;
				ViewBag.RequestContext = ErpRequestContext;
				ViewBag.AppContext = ErpAppContext.Current;

				if (context.Mode != ComponentMode.Options && context.Mode != ComponentMode.Help)
				{
					var isVisible = true;
					var isVisibleDS = context.DataModel.GetPropertyValueByDataSource(options.IsVisible);

					if (isVisibleDS is string && !string.IsNullOrWhiteSpace(isVisibleDS.ToString()))
					{
						if (bool.TryParse(isVisibleDS.ToString(), out bool outBool))
						{
							isVisible = outBool;
						}
					}
					else if (isVisibleDS is bool b)
					{
						isVisible = b;
					}

					ViewBag.IsVisible = isVisible;

					options.Text = context.DataModel.GetPropertyValueByDataSource(options.Text) as string;
					options.Class = context.DataModel.GetPropertyValueByDataSource(options.Class) as string;
				}

				switch (context.Mode)
				{
					case ComponentMode.Display:
						return await Task.FromResult<IViewComponentResult>(View("Display"));
					case ComponentMode.Design:
						return await Task.FromResult<IViewComponentResult>(View("Design"));
					case ComponentMode.Options:
						return await Task.FromResult<IViewComponentResult>(View("Options"));
					case ComponentMode.Help:
						return await Task.FromResult<IViewComponentResult>(View("Help"));
					default:
						ViewBag.Error = new ValidationException()
						{
							Message = "Unknown component mode"
						};
						return await Task.FromResult<IViewComponentResult>(View("Error"));
				}
			}
			catch (ValidationException ex)
			{
				ViewBag.Error = ex;
				return await Task.FromResult<IViewComponentResult>(View("Error"));
			}
			catch (Exception ex)
			{
				ViewBag.Error = new ValidationException()
				{
					Message = ex.Message
				};
				return await Task.FromResult<IViewComponentResult>(View("Error"));
			}
		}
	}
}
