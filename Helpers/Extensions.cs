using System;

public static class Extensions
{
    public static string[] SplitRemoveEmptyEntries(this string source, string seperator)
    {
        return source.Split(new string[] { seperator }, StringSplitOptions.RemoveEmptyEntries);
    }
}