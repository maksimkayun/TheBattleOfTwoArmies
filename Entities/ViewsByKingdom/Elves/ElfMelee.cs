using Entities.BasicViews;
using Entities.Strategy;

namespace Entities.ViewsByKingdom.Elves;

public class ElfMelee : Melee
{
    public ElfMelee(int health, int accuracy, int initiative, int damage, int agility, int strength, IStrategy strategy) : base(health,
        accuracy, initiative, damage, agility, strength, strategy)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(ElfMelee)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(Agility))
        {
            Console.WriteLine($"{nameof(ElfMelee)} смог увернуться от атаки");
        }
        else if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(ElfMelee)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(ElfMelee)} получил урон и умер");
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
            Console.WriteLine($"{nameof(ElfMelee)} промахивается");
        }
    }
}