using Entities.Strategy;
using Range = Entities.BasicViews.Range;

namespace Entities.ViewsByKingdom.Orcs;

public class OrcRange : Range
{
    public OrcRange(int health, int accuracy, int initiative, int arrows, int agility, int damage, IStrategy strategy) :
        base(health, accuracy, initiative, arrows, agility, damage, strategy)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(OrcRange)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(Agility))
        {
            Console.WriteLine($"{nameof(OrcRange)} смог увернуться от атаки");
        }
        else if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(OrcRange)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(OrcRange)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (Arrows > 0)
        {
            Arrows--;
            if (ProbabilityBy(Accuracy))
            {
                Console.WriteLine(_strategy.Attack(this, unit, Damage));
            }
            else
            {
                Console.WriteLine($"{nameof(OrcRange)} промахивается");
            }
        }
        else
        {
            Console.WriteLine($"У {nameof(OrcRange)} закончились стрелы");
        }
        
    }
}