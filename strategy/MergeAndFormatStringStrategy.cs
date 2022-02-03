using reference.utils;

namespace reference.strategy;

public class MergeAndFormatStringStrategy: IStrategy<string, List<string>>
{
    readonly string separator;
    public MergeAndFormatStringStrategy(string separator = " ")
    {
        this.separator = separator;
    }

    public string Execute(List<string> data)
    {
        var clean = string.Join(separator, data
            .Select(word => word.Trim().ToLower()));
        
        return StringUtils.MakeFirstLetterLarge(clean);
    }

    public override bool Equals(object? obj)
    {
        return obj != null && Equals(obj as MergeAndFormatStringStrategy);
    }

    public bool Equals(MergeAndFormatStringStrategy? other)
    {
        return separator.Equals(other?.separator);
    }

    public override int GetHashCode()
    {
        return separator.GetHashCode();
    }
}