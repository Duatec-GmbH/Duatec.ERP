
namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    internal static class HookKeys
    {
        internal static class Article
        {
            public const string Create = "article_create";
            public const string EplanImport = "article_eplan_import";
            public const string Update = "article_update";
        }

        internal static class Manufacturer
        {
            public const string Create = "manufacturer_create";
            public const string EplanImport = "manufacturer_eplan_import";
        }

        internal static class ArticleType
        {
            public const string Create = "article_type_create";
            public const string Manage = "article_type_manage";
            public const string Delete = "article_type_delete";
            public const string Update = "article_type_update";
        }

        internal static class Warehouse
        {
            public const string Create = "warehouse_create";
            public const string Manage = "warehouse_manage";
            public const string Delete = "warehouse_delete";
            public const string Update = "warehouse_update";
        }

        internal static class Shelf
        {
            public const string Create = "shelf_create";
            public const string Manage = "shelf_manage";
            public const string Delete = "shelf_delete";
            public const string Update = "shelf_update";
        }

        internal static class Compartment
        {
            public const string Create = "compartment_create";
            public const string Manage = "compartment_manage";
            public const string Delete = "compartment_delete";
            public const string Update = "compartment_update";
        }
    }
}
