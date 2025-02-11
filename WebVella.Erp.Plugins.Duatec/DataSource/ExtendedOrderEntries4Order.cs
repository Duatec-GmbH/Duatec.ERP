﻿using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Plugins.Duatec.DataTransfere;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.DataSource
{
    internal class ExtendedOrderEntries4Order : CodeDataSource
    {
        public static class Arguments
        {
            public const string Order = "order";
            public const string PartNumber = "partNumber";
            public const string TypeNumber = "typeNumber";
            public const string OrderNumber = "orderNumber";
            public const string Manufacturer = "manufacturer";
            public const string Designation = "designation";
            public const string State = "state";
            public const string Page = "page";
            public const string PageSize = "pageSize";
        }

        public ExtendedOrderEntries4Order()
        {
            Id = new Guid("98fe56ae-6fba-4182-99fd-d07a511708a8");
            Description = "Extended order entries for given order";
            Name = nameof(ExtendedOrderEntries4Order);
            ResultModel = nameof(EntityRecordList);

            Parameters.Add(new() { Name = Arguments.Order, Type = "Guid", Value = "null" });
            Parameters.Add(new() { Name = Arguments.PartNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.TypeNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.OrderNumber, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Manufacturer, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.Designation, Type = "text", Value = "null" });
            Parameters.Add(new() { Name = Arguments.State, Type = typeof(OrderEntryState).FullName, Value = "null" });
            Parameters.Add(new() { Name = Arguments.Page, Type = "int", Value = "1" });
            Parameters.Add(new() { Name = Arguments.PageSize, Type = "int", Value = "10" });
        }

        public override object Execute(Dictionary<string, object> arguments)
        {
            if (!arguments.TryGetValue(Arguments.Order, out var idVal) || idVal is not Guid id || id == Guid.Empty)
                return new EntityRecordList();

            var page = (int)arguments[Arguments.Page];
            var pageSize = (int)arguments[Arguments.PageSize];

            var resultList = ApplyFilters(arguments, Execute(id)).ToList();

            var result = new EntityRecordList();
            result.AddRange(resultList.Skip((page - 1) * pageSize).Take(pageSize));
            result.TotalCount = resultList.Count;

            return result;
        }

        public static IEnumerable<ExtendedOrderEntry> Execute(Guid orderId)
        {
            var recMan = new RecordManager();

            var orderRepo = new OrderRepository(recMan);
            var goodsReceivingRepo = new GoodsReceivingRepository(recMan);
            var manufacturerRepo = new CompanyRepository(recMan);
            var articleRepo = new ArticleRepository(recMan);

            var allEntries = orderRepo.FindManyEntriesByOrder(orderId, $"*, ${OrderEntry.Relations.Article}.*")
                .Select(TypedEntityRecordWrapper.Wrap<ExtendedOrderEntry>);

            var manufacturerIds = allEntries
                .Select(oe => oe.GetArticle().ManufacturerId)
                .Distinct()
                .ToArray();

            var typeIds = allEntries
                .Select(oe => oe.GetArticle().TypeId)
                .Distinct()
                .ToArray();

            var manufacturers = manufacturerRepo.FindMany($"id, {Company.Fields.Name}", manufacturerIds);

            const string receivedQuery = $"*, ${GoodsReceivingEntry.Relations.GoodsReceiving}.{GoodsReceiving.Fields.Order}";

            var recievedAmountsLookup = goodsReceivingRepo.FindManyEntriesByOrder(orderId, receivedQuery)
                .GroupBy(e => e.Article)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));


            var typeLookup = articleRepo.FindManyTypesById(typeIds);

            foreach (var orderEntry in allEntries)
            {
                var article = orderEntry.GetArticle();

                if (manufacturers.TryGetValue(article.ManufacturerId, out var manufacturer) && manufacturer != null)
                    article.SetManufacturer(manufacturer);

                if (typeLookup.TryGetValue(article.TypeId, out var type) && type != null)
                    article.SetArticleType(type);

                var receivedAmount = 0m;
                if (recievedAmountsLookup.TryGetValue(orderEntry.Article, out var amount))
                    receivedAmount = amount;
                

                orderEntry.ReceivedAmount = receivedAmount;
                orderEntry.State = orderEntry.Amount <= receivedAmount
                    ? OrderEntryState.Complete : OrderEntryState.Incomplete;

                yield return orderEntry;
            }
        }

        private static IEnumerable<ExtendedOrderEntry> ApplyFilters(Dictionary<string, object> arguments, IEnumerable<ExtendedOrderEntry> orderEntries)
        {
            var partNumber = arguments[Arguments.PartNumber] as string;
            var typeNumber = arguments[Arguments.TypeNumber] as string;
            var orderNumber = arguments[Arguments.OrderNumber] as string;
            var manufacturer = arguments[Arguments.Manufacturer] as string;
            var designation = arguments[Arguments.Designation] as string;
            var state = EnumValueFromParameter<OrderEntryState?>(arguments[Arguments.State]);

            if (!string.IsNullOrEmpty(partNumber))
                orderEntries = orderEntries.Where(oe => oe.GetArticle().PartNumber.Contains(partNumber, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(typeNumber))
                orderEntries = orderEntries.Where(oe => oe.GetArticle().TypeNumber.Contains(typeNumber, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(orderNumber))
                orderEntries = orderEntries.Where(oe => oe.GetArticle().OrderNumber.Contains(orderNumber, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(manufacturer))
                orderEntries = orderEntries.Where(oe => oe.GetArticle().GetManufacturer().Name.Contains(manufacturer, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(designation))
                orderEntries = orderEntries.Where(oe => oe.GetArticle().Designation.Contains(designation, StringComparison.OrdinalIgnoreCase));

            if (state.HasValue)
                orderEntries = orderEntries.Where(oe => oe.State == state.Value);

            return orderEntries.OrderBy(oe => oe.GetArticle().PartNumber);
        }
    }
}
