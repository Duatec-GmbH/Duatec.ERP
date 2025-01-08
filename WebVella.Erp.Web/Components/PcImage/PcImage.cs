using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Services;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace WebVella.Erp.Web.Components
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
	[PageComponent(	Label = "Image", Library = "WebVella", Description = "Renders a image", Version = "0.0.1", 
					IconClass = "fab fa-font-awesome-alt", IsInline = true)]
	public class PcImage : PageComponent
	{
		protected ErpRequestContext ErpRequestContext { get; set; }

		public PcImage([FromServices]ErpRequestContext coreReqCtx)
		{
			ErpRequestContext = coreReqCtx;
		}

		public class PcImageOptions
		{
			[JsonProperty(PropertyName = "is_visible")]
			public string IsVisible { get; set; } = "";

			[JsonProperty(PropertyName = "id")]
			public string Id { get; set; } = "";

			[JsonProperty(PropertyName = "source")]
			public string Source { get; set; } = "";

			[JsonProperty(PropertyName = "class")]
			public string Class { get; set; } = "";

			[JsonProperty(PropertyName = "width")]
			public string Width { get; set; } = "";

			[JsonProperty(PropertyName = "height")]
			public string Height { get; set; } = "";
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
					? new PcImageOptions()
					: JsonConvert.DeserializeObject<PcImageOptions>(context.Options.ToString());

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

					options.Source = context.DataModel.GetPropertyValueByDataSource(options.Source) as string;
					options.Width = context.DataModel.GetPropertyValueByDataSource(options.Width) as string;
					options.Height = context.DataModel.GetPropertyValueByDataSource(options.Height) as string;
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
