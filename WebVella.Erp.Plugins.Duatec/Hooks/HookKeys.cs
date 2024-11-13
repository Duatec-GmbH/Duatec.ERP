
namespace WebVella.Erp.Plugins.Duatec.Hooks
{
    public static class HookKeys
    {
        public static class Article
        {
            public const string Create = "article_create";
            public const string EplanImport = "article_eplan_import";
            public const string Update = "article_update";
            public const string Delete = "article_delete";
            public const string FileUpload = "article_file_upload";
            public const string FileImport = "article_file_import";

            public static class Type
            {
                public const string Create = "article_type_create";
                public const string Manage = "article_type_manage";
                public const string Delete = "article_type_delete";
                public const string Update = "article_type_update";
            }

            public static class Stock
            {
                public const string Create = "article_stock_create";
                public const string Update = "article_stock_update";
                public const string Move = "article_stock_move";
            }
        }

        public static class Manufacturer
        {
            public const string Create = "manufacturer_create";
            public const string Update = "manufacturer_update";
            public const string EplanImport = "manufacturer_eplan_import";
        }

        public static class Warehouse
        {
            public const string Create = "warehouse_create";
            public const string Manage = "warehouse_manage";
            public const string Delete = "warehouse_delete";
            public const string Update = "warehouse_update";

            public static class Location
            {
                public const string Create = "warehouse_location_create";
                public const string Manage = "warehouse_location_manage";
                public const string Delete = "warehouse_location_delete";
                public const string Update = "warehouse_location_update";
            }
        }

        public static class Project
        {
            public const string Create = "project_create";
            public const string Update = "project_update";
        }

        public static class PartList
        {
            public const string Create = "part_list_create";
            public const string Update = "part_list_update";
            public const string Delete = "project_update";
        }
    }
}
