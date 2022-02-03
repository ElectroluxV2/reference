namespace reference.builder;

public class GETQueryBuilder: HTTPQueryBuilder
{
    private string? _getParameters;
    public GETQueryBuilder(string route) : base(route)
    {
    }

    public override IQueryBuilder WithParameters(Dictionary<string, string> parameters)
    {
        _getParameters = "?" + string.Join(",",
            parameters.Select(parameter => string.Join("=", parameter.Key, parameter.Value)));
        return this;
    }

    public override string Build()
    {
        var stringJoiner = new List<string>
        {
            "POST:",
            string.IsNullOrEmpty(_getParameters) ? RequestRoute : string.Concat(RequestRoute, _getParameters)
        };

        if (!string.IsNullOrEmpty(AcceptedContentType)) stringJoiner.Add(string.Join( ":", "ACCEPTS", AcceptedContentType));
        if (!string.IsNullOrEmpty(AcceptedResponseCode)) stringJoiner.Add(string.Join(":", "REQUIRES", AcceptedResponseCode));

        return string.Join("|", stringJoiner);
    }
}