﻿using Entities;
using Entities.Strategy.Implementations;
using Entities.ViewsByKingdom.Orcs;

namespace Kingdoms.Factories;

public class OrcFactory : AbstractFabric
{
    public override Unit CreateHeal() => new OrcHeal(600, 65, 20, 80, new SupportStrategy());

    public override Unit CreateMelee() => new OrcMelee(1000, 40, 80, 85, 40, 70, new AttackStrategy());

    public override Unit CreateRange() => new OrcRange(750, 60, 50, 80, 50, 70, new AttackStrategy());
}