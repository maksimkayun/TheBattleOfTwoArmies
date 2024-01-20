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
        Logger.Log($"{nameof(OrcMelee)} делает ход");
        Attack(enemyUnits[new Random().Next(0,enemyUnits.Count - 1)]);
    }

    public override void TakeAttack(int valueDamage)
    {
        if (ProbabilityBy(Agility))
        {
            Logger.Log($"{nameof(OrcMelee)} смог увернуться от атаки");
        }
        else if (Health > valueDamage)
        {
            base.TakeAttack(valueDamage);
            Logger.Log($"{nameof(OrcMelee)} получил урон, оставшееся здоровье: {Health}/{MaxHealth}");
        }
        else
        {
            base.TakeAttack(valueDamage);
            Logger.Log($"{nameof(OrcMelee)} получил урон и умер");
        }
    }

    public override void Attack(Unit unit)
    {
        if (ProbabilityBy(Accuracy))
        {
            Logger.Log(Strategy.Run(this, unit, Damage));
        }
        else
        {
            Logger.Log($"{nameof(OrcMelee)} промахивается");
        }
    }
}