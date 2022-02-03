namespace reference.builder;

public interface IQueryBuilder
{
    public IQueryBuilder WithParameters(Dictionary<string, string> parameters);
    public IQueryBuilder WithAcceptedContentType(string acceptedContentType);
    public IQueryBuilder WithAcceptedResponseCode(string acceptedResponseCode);

    public string Build();
}