namespace reference.builder;

public class POSTQueryBuilder: HTTPQueryBuilder
{
    private string? _jsonParameters;
    
    public override IQueryBuilder WithParameters(Dictionary<string, string> parameters)
    {
        var parametersList = string.Join(",",
            parameters.Select(parameter => @$"""{parameter.Key}"": ""{parameter.Value}"""));

        _jsonParameters = @$"{{{parametersList}}}";
        return this;
    }

    public override string Build()
    {
        var stringJoiner = new List<string>
        {
            "POST:",
            RequestRoute
        };
        
        if (!string.IsNullOrEmpty(_jsonParameters)) stringJoiner.Add(string.Join(":", "BODY", _jsonParameters));
        if (!string.IsNullOrEmpty(AcceptedContentType)) stringJoiner.Add(string.Join(":", "ACCEPTS", AcceptedContentType));
        if (!string.IsNullOrEmpty(AcceptedResponseCode)) stringJoiner.Add(string.Join(":", "REQUIRES", AcceptedResponseCode));

        return string.Join("|", stringJoiner);
    }

    public POSTQueryBuilder(string route) : base(route)
    {
    }
}