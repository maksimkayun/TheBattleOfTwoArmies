namespace Entities.Strategy.Implementations;

public class AttackStrategy : IStrategy
{
    public string Run(Unit thisPerson, Unit person, int value) => Attack(thisPerson, person, value);

    public string Attack(Unit attackPerson, Unit person, int damage)
    {
        person.TakeAttack(damage);
        return $"{attackPerson.GetType().Name} атакует";
    }
}