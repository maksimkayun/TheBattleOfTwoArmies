using Range = Entities.BasicViews.Range;

namespace Entities.ViewsByKingdom.Elves;

public class ElfRange : Range
{
    public ElfRange(int health, int accuracy, int initiative, int arrows, int agility, int damage) :
        base(health, accuracy, initiative, arrows, agility, damage)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(ElfRange)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(Agility))
        {
            Console.WriteLine($"{nameof(ElfRange)} смог увернуться от атаки");
        }
        else if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(ElfRange)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Console.WriteLine($"{nameof(ElfRange)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (Arrows > 0)
        {
            Arrows--;
            if (ProbabilityBy(Accuracy))
            {
                Console.WriteLine($"{nameof(ElfRange)} атакует");
                unit.TakeAttack(Damage);
            }
            else
            {
                Console.WriteLine($"{nameof(ElfRange)} промахивается");
            }
        }
        else
        {
            Console.WriteLine($"У {nameof(ElfRange)} закончились стрелы");
            if (ProbabilityBy(Accuracy))
            {
                Console.WriteLine($"{nameof(ElfRange)} атакует в ближнем бою");
                unit.TakeAttack((int) (Damage - 0.5 * Damage));
            }
            else
            {
                Console.WriteLine($"{nameof(ElfRange)} промахивается");
            }
        }
    }
}