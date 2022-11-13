using Entities.BasicViews;

namespace Entities.ViewsByKingdom.Elves;

public class ElfHeal : Heal
{
    public ElfHeal(int health, int accuracy, int initiative, int intelligence) : base(health, accuracy, initiative,
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