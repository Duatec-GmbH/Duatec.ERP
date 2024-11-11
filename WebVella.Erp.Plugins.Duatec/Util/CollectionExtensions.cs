namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal static class CollectionExtensions
    {
        public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        {
            if (!dict.TryGetValue(key, out TValue? value))
                return default;
            return value;
        }
    }
}
