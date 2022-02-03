namespace reference.strategy;

public class MergeAndFormatTextStrategy: IStrategy<string, List<string>>
{
    private readonly string _separator;
    public MergeAndFormatTextStrategy(string separator = " ")
    {
        _separator = separator;
    }

    public string Execute(List<string> data)
    {
        var clean = data
            .Select(word => word.Trim().ToLower())
            .Aggregate((current, next) => $"{current}{_separator}{next}");
        
        return clean.Length > 1 ? $"{clean.Substring(0, 1).ToUpper()}{clean.Substring(1)}" : clean;
    }
}