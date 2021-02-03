namespace ManagedHelpers
{
    public static class Utils
    {
        public static T GetObjectSafeCastedAs<T>(this object objToCast)
        {
            if (objToCast is T)
            {
                return (T) objToCast;
            }
            return default(T);
        }
    }
}
