namespace WebVella.Erp.Plugins.Duatec
{
    public enum LanguageKey
    {
        en_US,
        de_DE,
    }

    internal static class LanguageKeys
    {
        public static LanguageKey English => LanguageKey.en_US;

        public static LanguageKey German = LanguageKey.de_DE;

        public static LanguageKey[] All => (LanguageKey[])Enum.GetValues(typeof(LanguageKey));
    }
}
