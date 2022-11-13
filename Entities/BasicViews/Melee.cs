namespace Entities.BasicViews;

public abstract class Melee : Unit
{
    public int Damage { get; set; }
    public int Agility { get; set; }
    public int Strength { get; set; }

    public Melee(int health, int accuracy, int initiative, int damage, int agility, int strength) : base(health,
        accuracy, initiative)
    {
        Damage = damage;
        Agility = agility;
        Strength = strength;
    }

    public abstract void Attack(Unit unit);
}