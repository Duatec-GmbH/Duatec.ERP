namespace WebVella.Erp.Plugins.Duatec.Services.Eplan
{
    public enum LanguageKey
    {
        en_US,
        de_DE,
    }

    internal static class LanguageKeys
    {
        public static LanguageKey Default => German;

        public static LanguageKey English => LanguageKey.en_US;

        public static LanguageKey German => LanguageKey.de_DE;

        public static LanguageKey[] All => (LanguageKey[])Enum.GetValues(typeof(LanguageKey));

        public static LanguageKey? FallBackLanguage(LanguageKey key)
        {
            return key switch
            {
                LanguageKey.de_DE => LanguageKey.en_US,
                _ => null
            };
        }
    }
}
