namespace reference.utils;

public static class StringUtils
{
    public static string MakeFirstLetterLarge(this string input)
    {
        return input.Length > 1 ? string.Concat(input[..1].ToUpper(), input[1..]) : input.ToUpper();
    }
}