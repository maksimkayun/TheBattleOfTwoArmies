namespace Entities.Strategy.Implementations;

public class SupportStrategy : IStrategy
{
    public string Run(Unit thisPerson, Unit person, int value) => Support(thisPerson, person, value);
    
    public string Support(Unit healer, Unit person, int health)
    {
        person.Health += health;
        return $"{healer.GetType().Name} вылечил {person.GetType().Name} на {health}";
    }
}