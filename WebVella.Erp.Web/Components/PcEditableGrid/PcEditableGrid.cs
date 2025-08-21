using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Eql;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Web.Models;
using WebVella.Erp.Web.Services;
using WebVella.Erp.Web.Utils;
using WebVella.TagHelpers.Models;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace WebVella.Erp.Web.Components
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
	[PageComponent(Label = "Editable Grid", Library = "WebVella", Description = "Displays data list in a table format which is editable", Version = "0.0.1", IconClass = "fas fa-table")]
	public class PcEditableGrid : PageComponent
	{
		protected ErpRequestContext ErpRequestContext { get; set; }

		public PcEditableGrid([FromServices] ErpRequestContext coreReqCtx)
		{
			ErpRequestContext = coreReqCtx;
		}

		public class PcEditableGridOptions
		{
			[JsonProperty(PropertyName = "is_visible")]
			public string IsVisible { get; set; } = "";

			[JsonProperty(PropertyName = "records")]
			public string Records { get; set; } = "";

			[JsonProperty(PropertyName = "striped")]
			public bool Striped { get; set; } = false;

			[JsonProperty(PropertyName = "bordered")]
			public bool Bordered { get; set; } = false;

			[JsonProperty(PropertyName = "borderless")]
			public bool Borderless { get; set; } = false;

			[JsonProperty(PropertyName = "id")]
			public Guid? Id { get; set; } = null;

			[JsonProperty(PropertyName = "name")]
			public string Name { get; set; } = "";

			[JsonProperty(PropertyName = "class")]
			public string Class { get; set; } = "";

			[JsonProperty(PropertyName = "visible_columns")]
			public int VisibleColumns { get; set; } = 2;

			[JsonProperty(PropertyName = "has_thead")]
			public bool HasThead { get; set; } = true;

			[JsonProperty(PropertyName = "culture")]
			public CultureInfo Culture { get; set; } = new CultureInfo(ErpSettings.Locale);// can be inherited

			[JsonProperty(PropertyName = "has-add-button")]
			public bool HasAddButton { get; set; } = true;

			[JsonProperty(PropertyName = "allow-copy")]
			public bool AllowCopy { get; set; } = true;

			[JsonProperty(PropertyName = "allow-paste")]
			public bool AllowPaste { get; set; } = true;

			[JsonProperty(PropertyName = "allow-delete")]
			public bool AllowDelete { get; set; } = true;

			[JsonProperty(PropertyName = "allow-add")]
			public bool AllowAdd { get; set; } = true;

			[JsonProperty(PropertyName = "has-delete-buttons")]
			public bool HasDeleteButtons { get; set; } = true;

			[JsonProperty(PropertyName = "compatibility")]
			public string Compatibility { get; set; }


			#region << container1 >>

			[JsonProperty(PropertyName = "container1_id")]
			public string Container1Id { get; set; } = "column1";

			[JsonProperty(PropertyName = "container1_name")]
			public string Container1Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container1_label")]
			public string Container1Label { get; set; } = "";

			[JsonProperty(PropertyName = "container1_width")]
			public string Container1Width { get; set; } = "";

			[JsonProperty(PropertyName = "container1_sortable")]
			public bool Container1Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container1_searchable")]
			public bool Container1Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container1_nowrap")]
			public bool Container1NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container1_class")]
			public string Container1Class { get; set; } = "";

			[JsonProperty(PropertyName = "container1_vertical_align")]
			public WvVerticalAlignmentType Container1VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container1_horizontal_align")]
			public WvHorizontalAlignmentType Container1HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;

			#endregion

			#region << container2 >>
			[JsonProperty(PropertyName = "container2_id")]
			public string Container2Id { get; set; } = "column2";

			[JsonProperty(PropertyName = "container2_name")]
			public string Container2Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container2_label")]
			public string Container2Label { get; set; } = "";

			[JsonProperty(PropertyName = "container2_width")]
			public string Container2Width { get; set; } = "";

			[JsonProperty(PropertyName = "container2_sortable")]
			public bool Container2Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container2_searchable")]
			public bool Container2Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container2_nowrap")]
			public bool Container2NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container2_class")]
			public string Container2Class { get; set; } = "";

			[JsonProperty(PropertyName = "container2_vertical_align")]
			public WvVerticalAlignmentType Container2VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container2_horizontal_align")]
			public WvHorizontalAlignmentType Container2HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container3 >>
			[JsonProperty(PropertyName = "container3_id")]
			public string Container3Id { get; set; } = "column3";

			[JsonProperty(PropertyName = "container3_name")]
			public string Container3Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container3_label")]
			public string Container3Label { get; set; } = "";

			[JsonProperty(PropertyName = "container3_width")]
			public string Container3Width { get; set; } = "";

			[JsonProperty(PropertyName = "container3_sortable")]
			public bool Container3Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container3_searchable")]
			public bool Container3Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container3_nowrap")]
			public bool Container3NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container3_class")]
			public string Container3Class { get; set; } = "";

			[JsonProperty(PropertyName = "container3_vertical_align")]
			public WvVerticalAlignmentType Container3VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container3_horizontal_align")]
			public WvHorizontalAlignmentType Container3HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container4 >>
			[JsonProperty(PropertyName = "container4_id")]
			public string Container4Id { get; set; } = "column4";

			[JsonProperty(PropertyName = "container4_name")]
			public string Container4Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container4_label")]
			public string Container4Label { get; set; } = "";

			[JsonProperty(PropertyName = "container4_width")]
			public string Container4Width { get; set; } = "";

			[JsonProperty(PropertyName = "container4_sortable")]
			public bool Container4Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container4_searchable")]
			public bool Container4Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container4_nowrap")]
			public bool Container4NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container4_class")]
			public string Container4Class { get; set; } = "";

			[JsonProperty(PropertyName = "container4_vertical_align")]
			public WvVerticalAlignmentType Container4VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container4_horizontal_align")]
			public WvHorizontalAlignmentType Container4HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container5 >>
			[JsonProperty(PropertyName = "container5_id")]
			public string Container5Id { get; set; } = "column5";

			[JsonProperty(PropertyName = "container5_name")]
			public string Container5Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container5_label")]
			public string Container5Label { get; set; } = "";

			[JsonProperty(PropertyName = "container5_width")]
			public string Container5Width { get; set; } = "";

			[JsonProperty(PropertyName = "container5_sortable")]
			public bool Container5Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container5_searchable")]
			public bool Container5Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container5_nowrap")]
			public bool Container5NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container5_class")]
			public string Container5Class { get; set; } = "";

			[JsonProperty(PropertyName = "container5_vertical_align")]
			public WvVerticalAlignmentType Container5VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container5_horizontal_align")]
			public WvHorizontalAlignmentType Container5HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container6 >>
			[JsonProperty(PropertyName = "container6_id")]
			public string Container6Id { get; set; } = "column6";

			[JsonProperty(PropertyName = "container6_name")]
			public string Container6Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container6_label")]
			public string Container6Label { get; set; } = "";

			[JsonProperty(PropertyName = "container6_width")]
			public string Container6Width { get; set; } = "";

			[JsonProperty(PropertyName = "container6_sortable")]
			public bool Container6Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container6_searchable")]
			public bool Container6Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container6_nowrap")]
			public bool Container6NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container6_class")]
			public string Container6Class { get; set; } = "";

			[JsonProperty(PropertyName = "container6_vertical_align")]
			public WvVerticalAlignmentType Container6VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container6_horizontal_align")]
			public WvHorizontalAlignmentType Container6HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container7 >>
			[JsonProperty(PropertyName = "container7_id")]
			public string Container7Id { get; set; } = "column7";

			[JsonProperty(PropertyName = "container7_name")]
			public string Container7Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container7_label")]
			public string Container7Label { get; set; } = "";

			[JsonProperty(PropertyName = "container7_width")]
			public string Container7Width { get; set; } = "";

			[JsonProperty(PropertyName = "container7_sortable")]
			public bool Container7Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container7_searchable")]
			public bool Container7Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container7_nowrap")]
			public bool Container7NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container7_class")]
			public string Container7Class { get; set; } = "";

			[JsonProperty(PropertyName = "container7_vertical_align")]
			public WvVerticalAlignmentType Container7VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container7_horizontal_align")]
			public WvHorizontalAlignmentType Container7HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container8 >>
			[JsonProperty(PropertyName = "container8_id")]
			public string Container8Id { get; set; } = "column8";

			[JsonProperty(PropertyName = "container8_name")]
			public string Container8Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container8_label")]
			public string Container8Label { get; set; } = "";

			[JsonProperty(PropertyName = "container8_width")]
			public string Container8Width { get; set; } = "";

			[JsonProperty(PropertyName = "container8_sortable")]
			public bool Container8Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container8_searchable")]
			public bool Container8Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container8_nowrap")]
			public bool Container8NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container8_class")]
			public string Container8Class { get; set; } = "";

			[JsonProperty(PropertyName = "container8_vertical_align")]
			public WvVerticalAlignmentType Container8VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container8_horizontal_align")]
			public WvHorizontalAlignmentType Container8HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container9 >>
			[JsonProperty(PropertyName = "container9_id")]
			public string Container9Id { get; set; } = "column9";

			[JsonProperty(PropertyName = "container9_name")]
			public string Container9Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container9_label")]
			public string Container9Label { get; set; } = "";

			[JsonProperty(PropertyName = "container9_width")]
			public string Container9Width { get; set; } = "";

			[JsonProperty(PropertyName = "container9_sortable")]
			public bool Container9Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container9_searchable")]
			public bool Container9Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container9_nowrap")]
			public bool Container9NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container9_class")]
			public string Container9Class { get; set; } = "";

			[JsonProperty(PropertyName = "container9_vertical_align")]
			public WvVerticalAlignmentType Container9VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container9_horizontal_align")]
			public WvHorizontalAlignmentType Container9HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container10 >>
			[JsonProperty(PropertyName = "container10_id")]
			public string Container10Id { get; set; } = "column10";

			[JsonProperty(PropertyName = "container10_name")]
			public string Container10Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container10_label")]
			public string Container10Label { get; set; } = "";

			[JsonProperty(PropertyName = "container10_width")]
			public string Container10Width { get; set; } = "";

			[JsonProperty(PropertyName = "container10_sortable")]
			public bool Container10Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container10_searchable")]
			public bool Container10Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container10_nowrap")]
			public bool Container10NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container10_class")]
			public string Container10Class { get; set; } = "";

			[JsonProperty(PropertyName = "container10_vertical_align")]
			public WvVerticalAlignmentType Container10VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container10_horizontal_align")]
			public WvHorizontalAlignmentType Container10HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container11 >>
			[JsonProperty(PropertyName = "container11_id")]
			public string Container11Id { get; set; } = "column11";

			[JsonProperty(PropertyName = "container11_name")]
			public string Container11Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container11_label")]
			public string Container11Label { get; set; } = "";

			[JsonProperty(PropertyName = "container11_width")]
			public string Container11Width { get; set; } = "";

			[JsonProperty(PropertyName = "container11_sortable")]
			public bool Container11Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container11_searchable")]
			public bool Container11Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container11_nowrap")]
			public bool Container11NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container11_class")]
			public string Container11Class { get; set; } = "";

			[JsonProperty(PropertyName = "container11_vertical_align")]
			public WvVerticalAlignmentType Container11VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container11_horizontal_align")]
			public WvHorizontalAlignmentType Container11HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion

			#region << container12 >>
			[JsonProperty(PropertyName = "container12_id")]
			public string Container12Id { get; set; } = "column12";

			[JsonProperty(PropertyName = "container12_name")]
			public string Container12Name { get; set; } = ""; //For URL purposes

			[JsonProperty(PropertyName = "container12_label")]
			public string Container12Label { get; set; } = "";

			[JsonProperty(PropertyName = "container12_width")]
			public string Container12Width { get; set; } = "";

			[JsonProperty(PropertyName = "container12_sortable")]
			public bool Container12Sortable { get; set; } = false;

			[JsonProperty(PropertyName = "container12_searchable")]
			public bool Container12Searchable { get; set; } = false;

			[JsonProperty(PropertyName = "container12_nowrap")]
			public bool Container12NoWrap { get; set; } = false;

			[JsonProperty(PropertyName = "container12_class")]
			public string Container12Class { get; set; } = "";

			[JsonProperty(PropertyName = "container12_vertical_align")]
			public WvVerticalAlignmentType Container12VerticalAlign { get; set; } = WvVerticalAlignmentType.None;

			[JsonProperty(PropertyName = "container12_horizontal_align")]
			public WvHorizontalAlignmentType Container12HorizontalAlign { get; set; } = WvHorizontalAlignmentType.None;
			#endregion
		}

		public static void ModifyChildElement(PageBodyNode childNode, JObject childOptions, int rowIndex, 
			EntityRecord record,
			PageComponentContext componentContext, 
			Dictionary<string, Dictionary<string, SelectOption>> cachedSelectOptions)
		{
			if(childNode.Nodes.Count > 0)
			{
				// node container

				foreach(var n in childNode.Nodes)
				{
					var options = PageUtils.ConvertStringToJObject(n.Options.ToString());

					var context = new PageComponentContext(n, componentContext.DataModel, ComponentMode.Display, options, componentContext.Items);
					context.DataModel.SetRowRecord(record);

					ModifyChildElement(n, options, rowIndex, record, context, cachedSelectOptions);
					n.Options = JsonConvert.SerializeObject(options);
				}

				return;
			}

			var name = $"{childOptions["name"]}";
			var brackOpenIndex = name.IndexOf('[');

			if (brackOpenIndex >= 0)
				name = name[..brackOpenIndex];

			if (string.IsNullOrWhiteSpace(name))
				return;

			childOptions["name"] = $"{name}[{rowIndex}]";

			#region Performance increase by caching datasources of select options and reduce to selected element

			var nodeComponentName = "";
			if (childNode != null)
			{
				var nameArray = childNode.ComponentName.Split('.');
				nodeComponentName = nameArray[^1];
			}

			if (nodeComponentName == "PcFieldSelect")
			{
				var selectOptions = PageUtils.ConvertStringToJObject(childOptions["options"]?.ToString());

				if (selectOptions["type"]?.ToString() == "0")
				{
					var dataSourceName = $"{selectOptions["string"]}";

					if (!string.IsNullOrEmpty(dataSourceName))
					{
						if (!dataSourceName.Contains("RowRecord"))
						{
							var valueOptions = PageUtils.ConvertStringToJObject(childOptions["value"]?.ToString());

							if (valueOptions["type"]?.ToString() == "0")
							{
								var value = componentContext.DataModel.GetProperty($"{valueOptions["string"]}");

								if (!cachedSelectOptions.TryGetValue(dataSourceName, out var lookup))
								{
									if (componentContext.DataModel.GetProperty(dataSourceName) is List<SelectOption> options)
									{
										lookup = options.ToDictionary(o => o.Value, o => o);
										cachedSelectOptions.Add(dataSourceName, lookup);
									}
								}

								if (lookup != null)
								{
									if (lookup.TryGetValue($"{value}", out var selectedOption))
										childOptions["options"] = JsonConvert.SerializeObject(new SelectOption[] { selectedOption });
									else
									{
										selectOptions["string"] = string.Empty;
										childOptions["options"] = selectOptions.ToString();
									}
								}
							}
						}
					}
				}
			}
			#endregion
		}


		public async Task<IViewComponentResult> InvokeAsync(PageComponentContext context)
		{
			ErpPage currentPage;

			try
			{

				#region << Init >>
				if (context.Node == null)
				{
					return await Task.FromResult<IViewComponentResult>(Content("Error: The node Id is required to be set as query parameter 'nid', when requesting this component"));
				}

				var pageFromModel = context.DataModel.GetProperty("Page");
				if (pageFromModel == null)
				{
					return await Task.FromResult<IViewComponentResult>(Content("Error: PageModel cannot be null"));
				}
				else if (pageFromModel is ErpPage page)
				{
					currentPage = page;
				}
				else
				{
					return await Task.FromResult<IViewComponentResult>(Content("Error: PageModel does not have Page property or it is not from ErpPage Type"));
				}

				var options = new PcEditableGridOptions();
				if (context.Options != null)
				{
					options = JsonConvert.DeserializeObject<PcEditableGridOptions>(context.Options.ToString());
				}

				var componentMeta = new PageComponentLibraryService().GetComponentMeta(context.Node.ComponentName);
				#endregion

				ViewBag.Options = options;
				ViewBag.Node = context.Node;
				ViewBag.ComponentMeta = componentMeta;
				ViewBag.RequestContext = ErpRequestContext;
				ViewBag.AppContext = ErpAppContext.Current;
				ViewBag.ComponentContext = context;

				ViewBag.Page = 1;
				ViewBag.TotalCount = 0;
				ViewBag.PageSize = 0;

				if (context.Mode != ComponentMode.Options && context.Mode != ComponentMode.Help)
				{
					var isVisible = true;
					var isVisibleDS = context.DataModel.GetPropertyValueByDataSource(options.IsVisible);
					if (isVisibleDS is string s && !string.IsNullOrWhiteSpace(s))
					{
						if (bool.TryParse(isVisibleDS.ToString(), out bool outBool))
							isVisible = outBool;
					}
					else if (isVisibleDS is bool b)
					{
						isVisible = b;
					}

					ViewBag.IsVisible = isVisible;
					ViewBag.Records = context.DataModel.GetPropertyValueByDataSource(options.Records)
						as EntityRecordList ?? [];

					if (ViewBag.Records.Count > 0)
					{
						ViewBag.TotalCount = ((EntityRecordList)ViewBag.Records).TotalCount;
					}
					//Could be a simple List<EntityRecord> (if from relation)
					if (ViewBag.Records.Count == 0)
					{
						ViewBag.Records = context.DataModel.GetPropertyValueByDataSource(options.Records)
							as List<EntityRecord> ?? [];
					}
				}
				else
				{
					ViewBag.VerticalAlignmentOptions = WebVella.TagHelpers.Utilities.ModelExtensions.GetEnumAsSelectOptions<WvVerticalAlignmentType>();
					ViewBag.HorizontalAlignmentOptions = WebVella.TagHelpers.Utilities.ModelExtensions.GetEnumAsSelectOptions<WvHorizontalAlignmentType>();
				}
				var columns = new List<WvGridColumnMeta>();


				#region << Init Columns >>
				if (options.VisibleColumns > 0)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container1Id,
						Name = options.Container1Name,
						Label = options.Container1Label,
						Searchable = options.Container1Searchable,
						Sortable = options.Container1Sortable,
						Width = options.Container1Width
					});
				}
				if (options.VisibleColumns > 1)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container2Id,
						Name = options.Container2Name,
						Label = options.Container2Label,
						Searchable = options.Container2Searchable,
						Sortable = options.Container2Sortable,
						Width = options.Container2Width
					});
				}
				if (options.VisibleColumns > 2)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container3Id,
						Name = options.Container3Name,
						Label = options.Container3Label,
						Searchable = options.Container3Searchable,
						Sortable = options.Container3Sortable,
						Width = options.Container3Width
					});
				}
				if (options.VisibleColumns > 3)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container4Id,
						Name = options.Container4Name,
						Label = options.Container4Label,
						Searchable = options.Container4Searchable,
						Sortable = options.Container4Sortable,
						Width = options.Container4Width
					});
				}
				if (options.VisibleColumns > 4)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container5Id,
						Name = options.Container5Name,
						Label = options.Container5Label,
						Searchable = options.Container5Searchable,
						Sortable = options.Container5Sortable,
						Width = options.Container5Width
					});
				}
				if (options.VisibleColumns > 5)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container6Id,
						Name = options.Container6Name,
						Label = options.Container6Label,
						Searchable = options.Container6Searchable,
						Sortable = options.Container6Sortable,
						Width = options.Container6Width
					});
				}
				if (options.VisibleColumns > 6)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container7Id,
						Name = options.Container7Name,
						Label = options.Container7Label,
						Searchable = options.Container7Searchable,
						Sortable = options.Container7Sortable,
						Width = options.Container7Width
					});
				}
				if (options.VisibleColumns > 7)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container8Id,
						Name = options.Container8Name,
						Label = options.Container8Label,
						Searchable = options.Container8Searchable,
						Sortable = options.Container8Sortable,
						Width = options.Container8Width
					});
				}
				if (options.VisibleColumns > 8)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container9Id,
						Name = options.Container9Name,
						Label = options.Container9Label,
						Searchable = options.Container9Searchable,
						Sortable = options.Container9Sortable,
						Width = options.Container9Width
					});
				}
				if (options.VisibleColumns > 9)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container10Id,
						Name = options.Container10Name,
						Label = options.Container10Label,
						Searchable = options.Container10Searchable,
						Sortable = options.Container10Sortable,
						Width = options.Container10Width
					});
				}
				if (options.VisibleColumns > 10)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container11Id,
						Name = options.Container11Name,
						Label = options.Container11Label,
						Searchable = options.Container11Searchable,
						Sortable = options.Container11Sortable,
						Width = options.Container11Width
					});
				}
				if (options.VisibleColumns > 11)
				{
					columns.Add(new WvGridColumnMeta()
					{
						ContainerId = options.Container12Id,
						Name = options.Container12Name,
						Label = options.Container12Label,
						Searchable = options.Container12Searchable,
						Sortable = options.Container12Sortable,
						Width = options.Container12Width
					});
				}
				#endregion

				ViewBag.Columns = columns;

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
			catch (EqlException ex)
			{
				var errors = new List<ValidationError>();
				foreach (var error in ex.Errors)
				{
					errors.Add(new ValidationError("eql", $"Line {error.Line}, Column {error.Column}: {error.Message}"));
				}
				ViewBag.Error = new ValidationException()
				{
					Message = ex.Message,
					Errors = errors
				};
				return await Task.FromResult<IViewComponentResult>(View("Error"));
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
