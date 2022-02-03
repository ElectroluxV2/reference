namespace reference.strategy;

public class Context<T, TE>
{
    private IStrategy<T, TE>? _strategy;

    public void SetStrategy(in IStrategy<T, TE> strategy)
    {
        _strategy = strategy;
    }

    public T Execute(TE data)
    {
        if (_strategy == null) throw new NullReferenceException("Strategy is not specified.");
        return _strategy.Execute(data);
    }
}