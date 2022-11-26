using Entities.BasicViews;

namespace Entities.ViewsByKingdom.Elves;

public class ElfHeal : Heal
{
    public ElfHeal(int health, int accuracy, int initiative, int intelligence) : base(health, accuracy, initiative,
        intelligence)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Console.WriteLine($"{nameof(ElfHeal)} делает ход");
        if (ProbabilityBy(Initiative)) TargetHeal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else GroupHeal(friendlyUnits);
    }

    public override void TakeAttack(int valueDamage)
    {
        base.TakeAttack(valueDamage);
        Console.WriteLine(Health > 0
            ? $"{nameof(ElfHeal)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}"
            : $"{nameof(ElfHeal)} получил урон и умер");
    }

    public override void TargetHeal(Unit unit)
    {
        string message;
        if (ProbabilityBy(Accuracy))
        {
            var valueIncrease = unit.MaxHealth - unit.Health;
            if (valueIncrease >= Intelligence)
            {
                unit.Health += Intelligence;
                message = $"{nameof(ElfHeal)} вылечил {unit.GetType().Name} на {Intelligence}";
            }
            else
            {
                unit.Health += valueIncrease;
                message = $"{nameof(ElfHeal)} вылечил {unit.GetType().Name} на {valueIncrease}";
            }
        }
        else
        {
            message = $"{nameof(ElfHeal)} промахнулся и не вылечил {unit.GetType().Name}";
        }
        Console.WriteLine(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        Console.WriteLine($"{nameof(ElfHeal)} кастует групповой хил");
        units.ForEach(TargetHeal);
    }
}