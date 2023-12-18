using Entities.Strategy;

namespace Entities.BasicViews;

public abstract class Heal : Unit
{
    public int Intelligence { get; set; }

    public Heal(int health, int accuracy, int initiative, int intelligence, IStrategy strategy) : base(health, accuracy, initiative, strategy)
    {
        Intelligence = intelligence;
    }

    public abstract void TargetHeal(Unit unit);
    public abstract void GroupHeal(List<Unit> units);
}