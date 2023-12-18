using Entities.Strategy;

namespace Entities.BasicViews;

public abstract class Range : Unit
{
    public int Arrows { get; set; }
    public int Agility { get; set; }
    public int Damage { get; set; }


    protected Range(int health, int accuracy, int initiative, int arrows, int agility, int damage, IStrategy strategy) :
        base(health, accuracy, initiative, strategy)
    {
        Arrows = arrows;
        Agility = agility;
        Damage = damage;
    }
    
    public abstract void Attack(Unit unit);
}