using WebVella.Erp.Api;
using WebVella.Erp.Api.Models;
using WebVella.Erp.Utilities;

namespace WebVella.Erp.TypedRecords.Util
{
    public static class ListOfTypedEntityRecordWrapperExtensions
    {
        public static IEnumerable<T> Include<T, TEntity>(IEnumerable<T> records, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
            where TEntity : TypedEntityRecordWrapper, new()
        {
            recMan ??= new();
            var relation = GetRelation<T, TEntity>(recMan);
            return Include(records, $"${relation.Name}", recMan);
        }

        public static List<T> Include<T, TEntity>(List<T> records, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
            where TEntity : TypedEntityRecordWrapper, new()
        {
            recMan ??= new();
            var relation = GetRelation<T, TEntity>(recMan);
            return Include(records, $"${relation.Name}", recMan);
        }

        public static IEnumerable<T> Include<T>(IEnumerable<T> records, string relationPaths, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
        {
            return EntityRecordCollectionExtensions.Include(records, relationPaths, recMan);
        }

        public static List<T> Include<T>(List<T> records, string relationPaths, RecordManager? recMan = null)
            where T : TypedEntityRecordWrapper, new()
        {
            EntityRecordCollectionExtensions.Include(records, relationPaths, recMan);
            return records;
        }

        private static EntityRelation GetRelation<TEntity1, TEntity2>(RecordManager? recMan = null)
            where TEntity1 : TypedEntityRecordWrapper, new()
            where TEntity2 : TypedEntityRecordWrapper, new()
        {
            var entity1 = new TEntity1().EntityName;
            var entity2 = new TEntity2().EntityName;

            recMan ??= new();

            var result = recMan.RelationManager.Read().Object
                .Single(r => r.TargetEntityName == entity1 && r.OriginEntityName == entity2 || r.OriginEntityName == entity1 && r.TargetEntityName == entity2);

            return result;
        }
    }
}
