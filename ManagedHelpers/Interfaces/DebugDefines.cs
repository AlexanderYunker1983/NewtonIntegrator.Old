namespace ManagedHelpers.Interfaces
{
    public static class DebugDefines
    {
        public static bool UsePropertyNamesVerification = true;

	public static bool IsDebug
        {
            get
            {
#if DEBUG
                return true;
#else
                return false;
#endif //DEBUG
            }
        }
    }
}