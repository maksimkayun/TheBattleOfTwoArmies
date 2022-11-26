using Range = Entities.BasicViews.Range;

namespace Entities.ViewsByKingdom.Orcs;

public class OrcRange : Range
{
    public OrcRange(int health, int accuracy, int initiative, int arrows, int agility, int damage) :
        base(health, accuracy, initiative, arrows, agility, damage)
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
            Console.WriteLine($"{nameof(OrcRange)} получил урон, оставшееся здоровье: {Health}");
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
                Console.WriteLine($"{nameof(OrcRange)} атакует");
                unit.TakeAttack(Damage);
            }
            else
            {
                Console.WriteLine($"{nameof(OrcRange)} промахивается");
            }
        }
        else
        {
            Console.WriteLine($"У {nameof(OrcRange)} закончились стрелы");
            if (ProbabilityBy(Accuracy))
            {
                Console.WriteLine($"{nameof(OrcRange)} атакует в ближнем бою");
                unit.TakeAttack((int) (Damage - 0.5 * Damage));
            }
            else
            {
                Console.WriteLine($"{nameof(OrcRange)} промахивается");
            }
        }
        
    }
}