using WebVella.Erp.Api;
using WebVella.Erp.Exceptions;
using WebVella.Erp.Plugins.Duatec.Persistance.Entities;
using WebVella.Erp.Plugins.Duatec.Persistance.Repositories;
using WebVella.Erp.Plugins.Duatec.Validators.Properties;
using WebVella.Erp.TypedRecords.Attributes;
using WebVella.Erp.TypedRecords.Validation;

namespace WebVella.Erp.Plugins.Duatec.Validators
{
    using Fields = Image.Fields;

    [TypedValidator(Entity)]
    internal class ImageValidator : IRecordValidator<Image>
    {
        public const string Entity = Image.Entity;
        private static readonly NameUniqueValidator _nameValidator = new(Entity, Fields.Name);

        public List<ValidationError> ValidateOnCreate(Image record)
        {
            var result = _nameValidator.ValidateOnCreate(record.Name, Fields.Name);
            if (string.IsNullOrEmpty(record.Path))
                result.Add(new(Fields.Path, "Image file is required."));
            return result;
        }

        public List<ValidationError> ValidateOnUpdate(Image record)
        {
            var result = _nameValidator.ValidateOnUpdate(record.Name, Fields.Name, record.Id!.Value);
            if (string.IsNullOrEmpty(record.Path))
                result.Add(new(Fields.Path, "Image file is required."));

            if(result.Count == 0)
            {
                var unmodified = new RecordManager()
                    .Find(Entity, record.Id!.Value).Object?.Data?.FirstOrDefault()?[Fields.Path] as string;

                if (!string.IsNullOrEmpty(unmodified) && record.Path != unmodified)
                    return ValidateOnRemoval(unmodified);
            }
            return result;
        }

        public List<ValidationError> ValidateOnDelete(Image record)
            => ValidateOnRemoval(record.Path);

        private static List<ValidationError> ValidateOnRemoval(string path)
        {
            if (!path.StartsWith("/fs/"))
            {
                if (path.StartsWith("/image/"))
                    path = "/fs" + path;
                else if (path.StartsWith("image/"))
                    path = "/fs/" + path;
            }

            var recMan = new RecordManager();

            var articleRepo = new ArticleRepository(recMan);
            if (articleRepo.FindManyByPreview(path, "id").Count > 0)
                return [new ValidationError(string.Empty, $"Image is used as article preview.")];

            var manufacturerRepo = new CompanyRepository(recMan);
            if (manufacturerRepo.FindManyByLogo(path, "id").Count > 0)
                return [new ValidationError(string.Empty, $"Image is used as manufacturer logo.")];

            return [];
        }
    }
}
