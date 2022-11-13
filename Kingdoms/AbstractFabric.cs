using Entities;

namespace Kingdoms;

public abstract class AbstractFabric
{
    public abstract Unit CreateHeal();
    public abstract Unit CreateMelee();
    public abstract Unit CreateRange();
}