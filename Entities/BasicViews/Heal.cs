namespace Entities.BasicViews;

public abstract class Heal : Unit
{
    public int Intelligence { get; set; }

    public Heal(int health, int accuracy, int initiative, int intelligence) : base(health, accuracy, initiative)
    {
        Intelligence = intelligence;
    }

    public abstract void TargetHeal(Unit unit);
    public abstract void GroupHeal(List<Unit> units);
}