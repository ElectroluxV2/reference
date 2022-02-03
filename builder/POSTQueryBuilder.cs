namespace reference.builder;

public class POSTQueryBuilder: HTTPQueryBuilder
{
    private string? _jsonParameters;
    
    public override IQueryBuilder WithParameters(Dictionary<string, string> parameters)
    {
        var parametersList = parameters
            .Select(parameter => @$"""{parameter.Key}"": ""{parameter.Value}""")
            .Aggregate((current, next) => $"{current},{next}");

        _jsonParameters = @$"{{{parametersList}}}";
        return this;
    }

    public override string Build()
    {
        var sb = new List<string>
        {
            "POST:",
            RequestRoute
        };

        if (!string.IsNullOrEmpty(_jsonParameters)) sb.Add($"BODY:{_jsonParameters}");
        if (!string.IsNullOrEmpty(AcceptedContentType)) sb.Add($"ACCEPTS:{AcceptedContentType}");
        if (!string.IsNullOrEmpty(AcceptedResponseCode)) sb.Add($"REQUIRES:{AcceptedResponseCode}");
        
        return sb.Aggregate((current, next) => $"{current}|{next}");
    }

    public POSTQueryBuilder(string route) : base(route)
    {
    }
}