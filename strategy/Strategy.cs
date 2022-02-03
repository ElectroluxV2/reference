namespace reference.strategy;

public interface IStrategy<out T, in TE>
{
    public T Execute(TE data);
}