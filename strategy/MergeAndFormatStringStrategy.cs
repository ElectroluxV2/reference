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
        var clean = data
            .Select(word => word.Trim().ToLower())
            .Aggregate((current, next) => $"{current}{separator}{next}");
        
        return clean.Length > 1 ? $"{clean[..1].ToUpper()}{clean[1..]}" : clean;
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