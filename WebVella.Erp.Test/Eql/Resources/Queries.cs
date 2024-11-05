namespace WebVella.Erp.Test.Eql.Resources
{
    internal class Queries
    {
        public static readonly string[] ValidSelectStatements =
        [
            "SELECT * FROM article ORDER BY part_number",
            "SELECT * FROM article ORDER BY part_number ASC",
            "SELECT * FROM article_stock ORDER BY $article.part_number",
            "SELECT * FROM article_stock ORDER BY $article.part_number DESC",
            "SELECT * FROM article_stock ORDER BY $article.$article_manufacturer.designation",
            "SELECT * FROM article_stock ORDER BY $article.$article_manufacturer.designation ASC",
            "SELECT * FROM article_stock ORDER BY $article.part_number, amount",
            "SELECT * FROM article_stock ORDER BY $article.part_number ASC, amount DESC",

@"SELECT *, $article.*, $article.$article_article_type.unit, $warehouse_location.designation, $warehouse_location.$warehouse.designation, $project.number
FROM article_stock
WHERE (@warehouseLocation = null or $warehouse_location.designation ~* @warehouseLocation)
    AND (@warehouse = null or $warehouse_location.$warehouse.designation ~* @warehouse)
    AND (@partNumber = null or $article.part_number ~* @partNumber)
    AND (@project = null or $project.number STARTSWITH @project)
ORDER BY $warehouse_location.designation, $article.part_number",
        ];
    }
}
