namespace Entities.Strategy.Implementations;

public class SupportStrategy : IStrategy
{
    public string Attack(Unit attackPerson, Unit person, int damage) => string.Empty;
    
    public string Support(Unit healer, Unit person, int health)
    {
        person.Health += health;
        return $"{healer.GetType().Name} вылечил {person.GetType().Name} на {health}";
    }
}