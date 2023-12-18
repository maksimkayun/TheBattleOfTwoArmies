namespace Entities.Strategy.Implementations;

public class AttackStrategy : IStrategy
{
    public string Attack(Unit attackPerson, Unit person, int damage)
    {
        person.TakeAttack(damage);
        return $"{attackPerson.GetType().Name} атакует";
    }

    public string Support(Unit healer, Unit person, int health) => string.Empty;
}