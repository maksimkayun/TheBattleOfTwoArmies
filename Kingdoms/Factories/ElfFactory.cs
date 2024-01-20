using Entities;
using Entities.Strategy.Implementations;
using Entities.ViewsByKingdom.Elves;

namespace Kingdoms.Factories;

public class ElfFactory : AbstractFabric
{
    public override Unit CreateHeal() => new ElfHeal(250, 80, 15, 100, new SupportStrategy());

    public override Unit CreateMelee() => new ElfMelee(400, 60, 50, 60, 50, 60, new AttackStrategy());

    public override Unit CreateRange() => new ElfRange(380, 85, 35, 50, 75, 85, new AttackStrategy());
}