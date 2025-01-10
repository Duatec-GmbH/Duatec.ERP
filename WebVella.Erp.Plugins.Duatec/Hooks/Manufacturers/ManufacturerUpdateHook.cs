﻿using Microsoft.AspNetCore.Mvc;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Hooks;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Services;
using WebVella.Erp.Plugins.Duatec.Validators;
using WebVella.Erp.Web.Hooks;
using WebVella.Erp.Web.Pages.Application;
using WebVella.TypedRecords;

namespace WebVella.Erp.Plugins.Duatec.Hooks.Manufacturers
{
    [HookAttachment(key: HookKeys.Manufacturer.Update)]
    internal class ManufacturerUpdateHook : IRecordManagePageHook
    {
        private readonly static CompanyValidator _validator = new();

        public IActionResult? OnPostManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel)
        {
            return null;
        }

        public IActionResult? OnPreManageRecord(EntityRecord record, Entity entity, RecordManagePageModel pageModel, List<ValidationError> validationErrors)
        {
            var company = TypedEntityRecordWrapper.WrapElseDefault<Company>(record)!;
            var oldRec = RepositoryService.CompanyRepository.Find(company.Id!.Value);
            company.EplanId = oldRec?.EplanId;

            var errors = _validator.ValidateOnUpdate(company);
            validationErrors.AddRange(errors);

            return null;
        }
    }
}
