using Kingdoms.Factories;

namespace Kingdoms;

public class Kingdoms
{
    public enum KingdomsEnum
    {
        OrcKingdom = 1,
        ElfKingdom = 2
    }

    public AbstractFabric? GetFabricForKingdom(KingdomsEnum kingdom)
    {
        AbstractFabric? result = null;
        switch (kingdom)
        {
            case KingdomsEnum.OrcKingdom:
            {
                result = new OrcFactory();
                break;
            }
            case KingdomsEnum.ElfKingdom:
            {
                result = new ElfFactory();
                break;
            }
        }

        return result;
    }
}