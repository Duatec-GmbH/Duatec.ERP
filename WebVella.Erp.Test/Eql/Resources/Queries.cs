namespace WebVella.Erp.Test.Eql.Resources
{
    internal class Queries
    {
        public static string QueryWithRelationalOrder 
            => "SELECT * FROM article_stock ORDER BY $article.$article_manufacturer.designation";

        public static string QueryWithRelationalOrder_WithDirection 
            => QueryWithRelationalOrder + " ASC";

        public static readonly string[] RelationalOrderByResources =
        [
            QueryWithRelationalOrder,
            QueryWithRelationalOrder_WithDirection,
        ];
    }
}
