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
        Logger.Log($"{nameof(OrcRange)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(Agility))
        {
            Logger.Log($"{nameof(OrcRange)} смог увернуться от атаки");
        }
        else if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Logger.Log($"{nameof(OrcRange)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Logger.Log($"{nameof(OrcRange)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (Arrows > 0)
        {
            Arrows--;
            if (ProbabilityBy(Accuracy))
            {
                Logger.Log(Strategy.Run(this, unit, Damage));
            }
            else
            {
                Logger.Log($"{nameof(OrcRange)} промахивается");
            }
        }
        else
        {
            Logger.Log($"У {nameof(OrcRange)} закончились стрелы");
        }
        
    }
}