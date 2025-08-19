using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Services;
using WebVella.TagHelpers.Models;

namespace WebVella.Erp.Web.Components
{
    [PageComponent(Label = "Div", Library = "WebVella", Description = "Render a div element", Version = "0.0.1", IconClass = "fas fa-poll-h")]
    public class PcDiv : PageComponent
    {
        protected ErpRequestContext ErpRequestContext { get; set; }

        public PcDiv([FromServices]ErpRequestContext coreReqCtx)
        {
            ErpRequestContext = coreReqCtx;
        }

        public class PcDivOptions
        {
            [JsonProperty(PropertyName = "is_visible")]
            public string IsVisible { get; set; } = "";

            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; } = "";

            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; } = "";

            [JsonProperty(PropertyName = "class")]
            public string Class { get; set; } = "";

			[JsonProperty(PropertyName = "label_mode")]
			public WvLabelRenderMode LabelMode { get; set; } = WvLabelRenderMode.Stacked; //To be inherited

			[JsonProperty(PropertyName = "mode")]
			public WvFieldRenderMode Mode { get; set; } = WvFieldRenderMode.Form; //To be inherited
		}

        public async Task<IViewComponentResult> InvokeAsync(PageComponentContext context)
        {
            try
            {
                #region << Init >>
                if (context.Node == null)
                    return await Task.FromResult<IViewComponentResult>(Content("Error: The node Id is required to be set as query parameter 'nid', when requesting this component"));

                var instanceOptions = new PcDivOptions();
                if (context.Options != null)
                    instanceOptions = JsonConvert.DeserializeObject<PcDivOptions>(context.Options.ToString());

                var componentMeta = new PageComponentLibraryService().GetComponentMeta(context.Node.ComponentName);
                #endregion

                ViewBag.Options = instanceOptions;
                ViewBag.Node = context.Node;
                ViewBag.ComponentMeta = componentMeta;
                ViewBag.RequestContext = ErpRequestContext;
                ViewBag.AppContext = ErpAppContext.Current;
                ViewBag.ComponentContext = context;
                ViewBag.LabelRenderModeOptions = WebVella.TagHelpers.Utilities.ModelExtensions.GetEnumAsSelectOptions<WvLabelRenderMode>();
                ViewBag.FieldRenderModeOptions = WebVella.TagHelpers.Utilities.ModelExtensions.GetEnumAsSelectOptions<WvFieldRenderMode>();

                context.Items[typeof(WvLabelRenderMode)] = instanceOptions.LabelMode;
                context.Items[typeof(WvFieldRenderMode)] = instanceOptions.Mode;

                if (context.Mode != ComponentMode.Options && context.Mode != ComponentMode.Help)
                {
                    var isVisible = true;
                    var isVisibleDS = context.DataModel.GetPropertyValueByDataSource(instanceOptions.IsVisible);

                    if (isVisibleDS is string && !string.IsNullOrWhiteSpace(isVisibleDS.ToString()))
                    {
                        if (bool.TryParse(isVisibleDS.ToString(), out var b))
                            isVisible = b;
                    }
                    else if (isVisibleDS is bool b)
                        isVisible = b;

                    ViewBag.IsVisible = isVisible;
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
