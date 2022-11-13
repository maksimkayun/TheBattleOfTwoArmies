using Entities;
using Entities.ViewsByKingdom.Orcs;

namespace Kingdoms.Factories;

public class OrcFactory : AbstractFabric
{
    public override Unit CreateHeal() => new OrcHeal(300, 65, 20, 80);

    public override Unit CreateMelee() => new OrcMelee(750, 40, 80, 85, 40, 70);

    public override Unit CreateRange() => new OrcRange(500, 60, 50, 80, 50, 70);
}