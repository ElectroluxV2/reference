using System.Linq;

namespace reference.builder;

public class GETQueryBuilder: HTTPQueryBuilder
{
    private string? _getParameters;
    public GETQueryBuilder(string route) : base(route)
    {
    }

    public override IQueryBuilder WithParameters(Dictionary<string, string> parameters)
    {
        _getParameters = "?" + parameters
            .Select(parameter => $"{parameter.Key}={parameter.Value}")
            .Aggregate((current, next) => $"{current},{next}");
        return this;
    }

    public override string Build()
    {
        var sb = new List<string>
        {
            "POST:",
            string.IsNullOrEmpty(_getParameters) ? RequestRoute : string.Concat(RequestRoute, _getParameters)
        };

        if (!string.IsNullOrEmpty(AcceptedContentType)) sb.Add($"ACCEPTS:{AcceptedContentType}");
        if (!string.IsNullOrEmpty(AcceptedResponseCode)) sb.Add($"REQUIRES:{AcceptedResponseCode}");
        
        return sb.Aggregate((current, next) => $"{current}|{next}");
    }
}