namespace Common.Extensions;

public static class StringExtensions
{
    public static IEnumerable<string> Split(this string text, int chunkSize)
    {
        ArgumentException.ThrowIfNullOrEmpty(text);

        var length = 0;

        while (length < text.Length)
        {
            if (length + chunkSize < text.Length)
            {
                yield return text.Substring(length, chunkSize);
            }
            else
            {
                yield return text[length..];
            }

            length += chunkSize;
        }
    }

    public static string SubstringBetween(this string input, char startChar, char endChar)
    {
        var startCharIndex = input.IndexOf(startChar);
        var endCharIndex = input.LastIndexOf(endChar);

        return input.Substring(startCharIndex + 1, endCharIndex - startCharIndex - 1);
    }
}