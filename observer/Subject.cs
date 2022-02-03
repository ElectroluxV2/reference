namespace reference.observer;

public class Subject<T>: ISubject<T>
{
    private readonly List<Action<T>> _observers = new();

    public void Attach(in Action<T> observer)
    {
        _observers.Add(observer);
    }

    public void Detach(in Action<T> observer)
    {
        _observers.Remove(observer);
    }
    
    public void Next(T value)
    {
        _observers.ForEach(observer => observer.Invoke(value));
    }
}