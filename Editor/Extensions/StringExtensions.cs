namespace Juce.ImplementationSelector.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveTail(this string source, string tail)
        {
            if (string.IsNullOrEmpty(tail))
            {
                return source;
            }

            int index = source.LastIndexOf(tail);

            if (index == -1)
            {
                return source;
            }

            return source.Substring(0, index);
        }
    }
}