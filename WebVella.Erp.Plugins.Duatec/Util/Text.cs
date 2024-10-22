namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class Text
    {
        public static string FancyfySnakeCase(string entityName) 
            => entityName.ToLower().Replace('_', ' ');

        public static string FancyfySnakeCaseStartUpper(string entityName)
            => char.ToUpper(entityName[0]) + FancyfySnakeCase(entityName[1..]);
    }
}
