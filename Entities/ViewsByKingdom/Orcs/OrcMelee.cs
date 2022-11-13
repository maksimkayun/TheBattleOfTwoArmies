using Entities.BasicViews;

namespace Entities.ViewsByKingdom.Orcs;

public class OrcMelee : Melee
{
    public OrcMelee(int health, int accuracy, int initiative, int damage, int agility, int strength) : base(health,
        accuracy, initiative, damage, agility, strength)
    {
    }

    public override void Run()
    {
        throw new NotImplementedException();
    }

    public override void Attack(Unit unit)
    {
        throw new NotImplementedException();
    }
}