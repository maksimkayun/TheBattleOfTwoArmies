using Entities.BasicViews;
using Entities.Strategy;

namespace Entities.ViewsByKingdom.Orcs;

public class OrcMelee : Melee
{
    public OrcMelee(int health, int accuracy, int initiative, int damage, int agility, int strength, IStrategy strategy) : base(health,
        accuracy, initiative, damage, agility, strength, strategy)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(OrcMelee)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(Agility))
        {
            Console.WriteLine($"{nameof(OrcMelee)} смог увернуться от атаки");
        }
        else if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(OrcMelee)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(OrcMelee)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(Accuracy))
        {
            Console.WriteLine(_strategy.Attack(this, unit, Damage));
        }
        else
        {
            Console.WriteLine($"{nameof(OrcMelee)} промахивается");
        }
    }
}