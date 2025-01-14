﻿
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

                public static class Reservations
                {
                    public const string MassReservation = "article_stock_reservation_mass_reservation";
                }
            }
        }

        public static class GoodsReceiving
        {
            public static class DeliveryNotes
            {
                public const string Create = "delivery_notes_create";
                public const string Delete = "delivery_notes_delete";
            }

            public static class Entry
            {
                public const string Create = "goods_receiving_entry_create";
                public const string Delete = "goods_receiving_entry_delete";
                public const string Update = "goods_receiving_entry_update";
            }

            public const string Create = "goods_receiving_create";
            public const string Update = "goods_receiving_update";
            public const string Delete = "goods_receiving_delete";
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
            public const string Complete = "project_complete";
            public const string OrderList = "project_order_list";
        }

        public static class PartList
        {
            public static class Entry
            {
                public const string Create = "part_list_entry_create";
                public const string Delete = "part_list_entry_delete";
                public const string Update = "part_list_entry_update";
            }

            public const string Create = "part_list_create";
            public const string Update = "part_list_update";
            public const string Delete = "part_list_delete";
            public const string Import = "part_list_file_import";
        }
    }
}
