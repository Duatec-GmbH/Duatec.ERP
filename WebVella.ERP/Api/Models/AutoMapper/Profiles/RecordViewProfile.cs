﻿using AutoMapper;
using System;
using WebVella.ERP.Storage;

namespace WebVella.ERP.Api.Models.AutoMapper.Profiles
{
	internal class RecordViewProfile : Profile
	{
		IErpService service;

		public RecordViewProfile(IErpService service)
		{
			this.service = service;
		}

		protected override void Configure()
		{
			Mapper.CreateMap<RecordViewHtmlItem, IStorageRecordViewHtmlItem>().ConstructUsing(x => CreateEmptyRecordViewHtmlItemObject(x));
			Mapper.CreateMap<IStorageRecordViewHtmlItem, RecordViewHtmlItem>();
			Mapper.CreateMap<RecordViewHtmlItem, InputRecordViewHtmlItem>();
			Mapper.CreateMap<InputRecordViewHtmlItem, RecordViewHtmlItem>();

			Mapper.CreateMap<RecordViewRelationFieldItem, IStorageRecordViewRelationFieldItem>().ConstructUsing(x => CreateEmptyRecordViewRelationFieldItemObject(x));
			Mapper.CreateMap<IStorageRecordViewRelationFieldItem, RecordViewRelationFieldItem>();
			Mapper.CreateMap<RecordViewRelationFieldItem, InputRecordViewRelationFieldItem>();
			Mapper.CreateMap<InputRecordViewRelationFieldItem, RecordViewRelationFieldItem>()
				.ForMember(x => x.FieldId, opt => opt.MapFrom(y => (y.FieldId.HasValue) ? y.FieldId.Value : Guid.Empty))
				.ForMember(x => x.RelationId, opt => opt.MapFrom(y => (y.RelationId.HasValue) ? y.RelationId.Value : Guid.Empty));


			Mapper.CreateMap<RecordViewViewItem, IStorageRecordViewViewItem>().ConstructUsing(x => CreateEmptyRecordViewViewItemObject(x));
			Mapper.CreateMap<IStorageRecordViewViewItem, RecordViewViewItem>();
			Mapper.CreateMap<RecordViewViewItem, InputRecordViewViewItem>();
			Mapper.CreateMap<InputRecordViewViewItem, RecordViewViewItem>()
				.ForMember(x => x.ViewId, opt => opt.MapFrom(y => (y.ViewId.HasValue) ? y.ViewId.Value : Guid.Empty));


			Mapper.CreateMap<RecordViewListItem, IStorageRecordViewListItem>().ConstructUsing(x => CreateEmptyRecordViewListItemObject(x));
			Mapper.CreateMap<IStorageRecordViewListItem, RecordViewListItem>();
			Mapper.CreateMap<RecordViewListItem, InputRecordViewListItem>();
			Mapper.CreateMap<InputRecordViewListItem, RecordViewListItem>()
				.ForMember(x => x.ListId, opt => opt.MapFrom(y => (y.ListId.HasValue) ? y.ListId.Value : Guid.Empty));


			Mapper.CreateMap<RecordViewFieldItem, IStorageRecordViewFieldItem>().ConstructUsing(x => CreateEmptyRecordViewFieldItemObject(x));
			Mapper.CreateMap<IStorageRecordViewFieldItem, RecordViewFieldItem>();
			Mapper.CreateMap<RecordViewFieldItem, InputRecordViewFieldItem>();
			Mapper.CreateMap<InputRecordViewFieldItem, RecordViewFieldItem>()
				.ForMember(x => x.FieldId, opt => opt.MapFrom(y => (y.FieldId.HasValue) ? y.FieldId.Value : Guid.Empty));


			Mapper.CreateMap<RecordViewItemBase, IStorageRecordViewItemBase>().ConstructUsing(x => CreateEmptyRecordViewItemBaseObject(x))
				.Include<RecordViewFieldItem, IStorageRecordViewFieldItem>()
				.Include<RecordViewListItem, IStorageRecordViewListItem>()
				.Include<RecordViewViewItem, IStorageRecordViewViewItem>()
				.Include<RecordViewRelationFieldItem, IStorageRecordViewRelationFieldItem>()
				.Include<RecordViewHtmlItem, IStorageRecordViewHtmlItem>();
			Mapper.CreateMap<IStorageRecordViewItemBase, RecordViewItemBase>()
				.Include<IStorageRecordViewFieldItem, RecordViewFieldItem>()
				.Include<IStorageRecordViewListItem, RecordViewListItem>()
				.Include<IStorageRecordViewViewItem, RecordViewViewItem>()
				.Include<IStorageRecordViewRelationFieldItem, RecordViewRelationFieldItem>()
				.Include<IStorageRecordViewHtmlItem, RecordViewHtmlItem>();
			Mapper.CreateMap<RecordViewItemBase, InputRecordViewItemBase>()
				.Include<RecordViewFieldItem, InputRecordViewFieldItem>()
				.Include<RecordViewListItem, InputRecordViewListItem>()
				.Include<RecordViewViewItem, InputRecordViewViewItem>()
				.Include<RecordViewRelationFieldItem, InputRecordViewRelationFieldItem>()
				.Include<RecordViewHtmlItem, InputRecordViewHtmlItem>();
			Mapper.CreateMap<InputRecordViewItemBase, RecordViewItemBase>()
				.Include<InputRecordViewFieldItem, RecordViewFieldItem>()
				.Include<InputRecordViewListItem, RecordViewListItem>()
				.Include<InputRecordViewViewItem, RecordViewViewItem>()
				.Include<InputRecordViewRelationFieldItem, RecordViewRelationFieldItem>()
				.Include<InputRecordViewHtmlItem, RecordViewHtmlItem>();


			Mapper.CreateMap<RecordViewColumn, IStorageRecordViewColumn>().ConstructUsing(x => CreateEmptyRecordViewColumnObject(x));
			Mapper.CreateMap<IStorageRecordViewColumn, RecordViewColumn>();
			Mapper.CreateMap<RecordViewColumn, InputRecordViewColumn>();
			Mapper.CreateMap<InputRecordViewColumn, RecordViewColumn>();


			Mapper.CreateMap<RecordViewRow, IStorageRecordViewRow>().ConstructUsing(x => CreateEmptyRecordViewRowObject(x));
			Mapper.CreateMap<IStorageRecordViewRow, RecordViewRow>();
			Mapper.CreateMap<RecordViewRow, InputRecordViewRow>();
			Mapper.CreateMap<InputRecordViewRow, RecordViewRow>()
				.ForMember(x => x.Id, opt => opt.MapFrom(y => (y.Id.HasValue) ? y.Id.Value : Guid.Empty));


			Mapper.CreateMap<RecordViewSection, IStorageRecordViewSection>().ConstructUsing(x => CreateEmptyRecordViewSectionObject(x));
			Mapper.CreateMap<IStorageRecordViewSection, RecordViewSection>();
			Mapper.CreateMap<RecordViewSection, InputRecordViewSection>();
			Mapper.CreateMap<InputRecordViewSection, RecordViewSection>()
				.ForMember(x => x.Id, opt => opt.MapFrom(y => (y.Id.HasValue) ? y.Id.Value : Guid.Empty))
				.ForMember(x => x.Collapsed, opt => opt.MapFrom(y => (y.Collapsed.HasValue) ? y.Collapsed.Value : false))
				.ForMember(x => x.ShowLabel, opt => opt.MapFrom(y => (y.ShowLabel.HasValue) ? y.ShowLabel.Value : false));


			Mapper.CreateMap<RecordViewRegion, IStorageRecordViewRegion>().ConstructUsing(x => CreateEmptyRecordViewRegionObject(x));
			Mapper.CreateMap<IStorageRecordViewRegion, RecordViewRegion>();
			Mapper.CreateMap<RecordViewRegion, InputRecordViewRegion>();
			Mapper.CreateMap<InputRecordViewRegion, RecordViewRegion>()
				.ForMember(x => x.Render, opt => opt.MapFrom(y => (y.Render.HasValue) ? y.Render.Value : false));


			Mapper.CreateMap<RecordViewSidebarList, IStorageRecordViewSidebarList>().ConstructUsing(x => CreateEmptyRecordViewSidebarListObject(x));
			Mapper.CreateMap<IStorageRecordViewSidebarList, RecordViewSidebarList>();
			Mapper.CreateMap<RecordViewSidebarList, InputRecordViewSidebarList>();
			Mapper.CreateMap<InputRecordViewSidebarList, RecordViewSidebarList>()
				.ForMember(x => x.EntityId, opt => opt.MapFrom(y => (y.EntityId.HasValue) ? y.EntityId.Value : Guid.Empty))
				.ForMember(x => x.ListId, opt => opt.MapFrom(y => (y.ListId.HasValue) ? y.ListId.Value : Guid.Empty))
				.ForMember(x => x.RelationId, opt => opt.MapFrom(y => (y.RelationId.HasValue) ? y.RelationId.Value : Guid.Empty));


			Mapper.CreateMap<RecordViewSidebar, IStorageRecordViewSidebar>().ConstructUsing(x => CreateEmptyRecordViewSidebarObject(x));
			Mapper.CreateMap<IStorageRecordViewSidebar, RecordViewSidebar>();
			Mapper.CreateMap<RecordViewSidebar, InputRecordViewSidebar>();
			Mapper.CreateMap<InputRecordViewSidebar, RecordViewSidebar>()
				.ForMember(x => x.Render, opt => opt.MapFrom(y => (y.Render.HasValue) ? y.Render.Value : false));


			Mapper.CreateMap<RecordView, IStorageRecordView>().ConstructUsing(x => CreateEmptyRecordViewObject(x))
				.ForMember(x => x.Type, opt => opt.MapFrom(y => GetViewTypeId(y.Type)));
			Mapper.CreateMap<IStorageRecordView, RecordView>()
				.ForMember(x => x.Type, opt => opt.MapFrom(y => Enum.GetName(typeof(RecordViewType), y.Type).ToLower()));
			Mapper.CreateMap<RecordView, InputRecordView>();
			Mapper.CreateMap<InputRecordView, RecordView>()
				.ForMember(x => x.Id, opt => opt.MapFrom(y => (y.Id.HasValue) ? y.Id.Value : Guid.Empty));

		}

		private RecordViewType GetViewTypeId(string name)
		{
			RecordViewType type = RecordViewType.Details;

			Enum.TryParse(name, out type);

			return type;
        }

		protected IStorageRecordView CreateEmptyRecordViewObject(RecordView view)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewObject();
		}

		protected IStorageRecordViewSidebar CreateEmptyRecordViewSidebarObject(RecordViewSidebar sidebar)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewSidebarObject();
		}

		protected IStorageRecordViewSidebarList CreateEmptyRecordViewSidebarListObject(RecordViewSidebarList sidebarList)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewSidebarListObject();
		}

		protected IStorageRecordViewRegion CreateEmptyRecordViewRegionObject(RecordViewRegion region)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewRegionObject();
		}

		protected IStorageRecordViewSection CreateEmptyRecordViewSectionObject(RecordViewSection section)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewSectionObject();
		}

		protected IStorageRecordViewRow CreateEmptyRecordViewRowObject(RecordViewRow row)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewRowObject();
		}

		protected IStorageRecordViewColumn CreateEmptyRecordViewColumnObject(RecordViewColumn column)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewColumnObject();
		}

		protected IStorageRecordViewItemBase CreateEmptyRecordViewItemBaseObject(RecordViewItemBase item)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewItemBaseObject();
		}

		protected IStorageRecordViewFieldItem CreateEmptyRecordViewFieldItemObject(RecordViewFieldItem item)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewFieldItemObject();
		}

		protected IStorageRecordViewListItem CreateEmptyRecordViewListItemObject(RecordViewListItem item)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewListItemObject();
		}

		protected IStorageRecordViewViewItem CreateEmptyRecordViewViewItemObject(RecordViewViewItem item)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewViewItemObject();
		}

		protected IStorageRecordViewRelationFieldItem CreateEmptyRecordViewRelationFieldItemObject(RecordViewRelationFieldItem item)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewRelationFieldItemObject();
		}

		protected IStorageRecordViewHtmlItem CreateEmptyRecordViewHtmlItemObject(RecordViewHtmlItem item)
		{
			var storageService = service.StorageService;
			return storageService.GetObjectFactory().CreateEmptyRecordViewHtmlItemObject();
		}
	}
}