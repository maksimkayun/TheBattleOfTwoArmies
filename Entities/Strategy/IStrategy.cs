namespace Entities.Strategy;

public interface IStrategy
{
    public string Attack(Unit attackPerson, Unit person, int damage);
    public string Support(Unit healer, Unit person, int health);
}