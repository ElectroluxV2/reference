namespace reference.observer;

public interface IObserver<T>
{
    public void Update(in ISubject<T> subject);
}