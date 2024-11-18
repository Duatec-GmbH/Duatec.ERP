namespace WebVella.Erp.Plugins.Duatec.Util
{
    internal class Try
    {
        public static bool Get<T>(Func<T> func, out T? result)
        {
            try
            {
                result = func();
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
