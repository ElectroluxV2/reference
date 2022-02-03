namespace reference.builder;

public abstract class HTTPQueryBuilder: IQueryBuilder
{
    protected string RequestRoute { get; }
    protected string? AcceptedContentType { get; private set; }
    protected string? AcceptedResponseCode { get; private set; }

    protected HTTPQueryBuilder(string route)
    {
        RequestRoute = route;
    }
    
    public abstract IQueryBuilder WithParameters(Dictionary<string, string> parameters);

    public virtual IQueryBuilder WithAcceptedContentType(string acceptedContentType)
    {
        AcceptedContentType = acceptedContentType;
        return this;
    }

    public virtual IQueryBuilder WithAcceptedResponseCode(string acceptedResponseCode)
    {
        AcceptedResponseCode = acceptedResponseCode;
        return this;
    }

    public abstract string Build();
}