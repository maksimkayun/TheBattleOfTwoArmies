using Entities;
using Entities.ViewsByKingdom.Elves;

namespace Kingdoms.Factories;

public class ElfFactory : AbstractFabric
{
    public override Unit CreateHeal() => new ElfHeal(180, 80, 15, 100);

    public override Unit CreateMelee() => new ElfMelee(560, 60, 50, 60, 50, 60);

    public override Unit CreateRange() => new ElfRange(380, 85, 35, 50, 75, 85);
}