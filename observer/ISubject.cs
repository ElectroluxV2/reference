namespace reference.observer;

public interface ISubject<T>
{
    public void Attach(in Action<T> observer);

    public void Detach(in Action<T> observer);

    public void Next(T value);
}