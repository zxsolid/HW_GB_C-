namespace ImplicitCasting.Base.Infrastructure
{
    internal static class SizeOf
    {
        public static int DataTypeInBytes(string value)
        {
            int size = 0;

            if (value.Contains("bool")) size = sizeof(bool);
            else if (value.Contains("byte")) size = sizeof(byte);
            else if (value.Contains("int")) size = sizeof(int);
            else if (value.Contains("long")) size = sizeof(long);
            else if (value.Contains("double")) size = sizeof(double);
            // и тд.

            return size;
        }
    }
}