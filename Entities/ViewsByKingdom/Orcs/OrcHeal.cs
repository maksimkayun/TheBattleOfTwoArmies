using Entities.BasicViews;
using Entities.Strategy;

namespace Entities.ViewsByKingdom.Orcs;

public class OrcHeal : Heal
{
    public OrcHeal(int health, int accuracy, int initiative, int intelligence, IStrategy strategy) : base(health, accuracy, initiative,
        intelligence, strategy)
    {
    }

    public override void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits)
    {
        Logger.Log($"{nameof(OrcHeal)} делает ход");
        if (ProbabilityBy(Initiative)) TargetHeal(friendlyUnits[new Random().Next(0,friendlyUnits.Count - 1)]);
        else GroupHeal(friendlyUnits);
    }

    public override void TakeAttack(int valueDamage)
    {
        base.TakeAttack(valueDamage);
        Logger.Log(Health > 0
            ? $"{nameof(OrcHeal)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}"
            : $"{nameof(OrcHeal)} получил урон и умер");
    }

    public override void TargetHeal(Unit unit)
    {
        string message;
        if (ProbabilityBy(Accuracy))
        {
            var valueIncrease = unit.MaxHealth - unit.Health;
            if (valueIncrease >= Intelligence)
            {
                message = Strategy.Run(this, unit, Intelligence);
            }
            else
            {
                message = Strategy.Run(this, unit, valueIncrease);
            }
        }
        else
        {
            message = $"{nameof(OrcHeal)} промахнулся и не вылечил {unit.GetType().Name}";
        }
        Logger.Log(message);
    }

    public override void GroupHeal(List<Unit> units)
    {
        Logger.Log($"{nameof(OrcHeal)} кастует групповой хил");
        units.ForEach(TargetHeal);
    }
}