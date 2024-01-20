using System.Collections.Generic;
using System.Linq;
using Common;
using Entities;
using Kingdoms;

namespace TheBattleOfTwoArmies;

public class GameFacade
{
    private AbstractFabric fabricOrc = new Kingdoms.Kingdoms().GetFabricForKingdom(Kingdoms.Kingdoms.KingdomsEnum.OrcKingdom);
    private AbstractFabric fabricElv = new Kingdoms.Kingdoms().GetFabricForKingdom(Kingdoms.Kingdoms.KingdomsEnum.ElfKingdom);

    public void SetLogEnabling(bool value)
    {
        ConsoleLogger.Instance.EnableLog = value;
    }

    public List<Unit> CreateElfArmy()
    {
        var result = new List<Unit> { fabricElv?.CreateHeal(), fabricElv?.CreateMelee(), fabricElv?.CreateRange() };
        return result.OrderBy(o => o.Initiative).ToList();
    }

    public List<Unit> CreateOrcArmy() 
    {
        var result = new List<Unit> { fabricOrc?.CreateHeal(), fabricOrc?.CreateMelee(), fabricOrc?.CreateRange() };
        return result.OrderBy(o => o.Initiative).ToList();
    }

    public string MakeWar(List<Unit> elfUnits, List<Unit> orcUnits)
    {
        var iteratorElfs = 0;
        var iteratorOrcs = 0;
        var condition = elfUnits.Count > 0 && orcUnits.Count > 0;
        for (int i = 0; condition; i++)
        {
            if (i % 2 == 0)
            {
                elfUnits[iteratorElfs % elfUnits.Count].Run(orcUnits, elfUnits);
                CheckForUpdate(orcUnits);
                iteratorElfs++;
            }
            else
            {
                orcUnits[iteratorOrcs % orcUnits.Count].Run(elfUnits, orcUnits);
                CheckForUpdate(elfUnits);
                iteratorOrcs++;
            }

            if (orcUnits.Count == 0 || elfUnits.Count == 0)
            {
                break;
            }
        }

        string message;
        if (elfUnits.Count > 0)
        {
            message = "ЭЛЬФЫ ПОБЕДИЛИ";
        }
        else
        {
            message = "ОРКИ ПОБЕДИЛИ";
        }

        ConsoleLogger.Instance.Log(message);
        return message;
    }

    private static void CheckForUpdate(List<Unit> units)
    {
        units.RemoveAll(e => e.Health <= 0);
    }
}