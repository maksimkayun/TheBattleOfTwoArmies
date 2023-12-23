namespace Entities.Strategy;

public interface IStrategy
{
    public string Run(Unit thisPerson, Unit person, int value);
}