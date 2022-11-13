using Entities.BasicViews;

namespace Entities.ViewsByKingdom.Orcs;

public class OrcHeal : Heal
{
    public OrcHeal(int health, int accuracy, int initiative, int intelligence) : base(health, accuracy, initiative,
        intelligence)
    {
    }

    public override void Run()
    {
        throw new NotImplementedException();
    }

    public override void TargetHeal(Unit unit)
    {
        throw new NotImplementedException();
    }

    public override void GroupHeal(List<Unit> units)
    {
        throw new NotImplementedException();
    }
}