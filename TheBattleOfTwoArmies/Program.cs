using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Kingdoms;

namespace TheBattleOfTwoArmies
{
    static class Program
    {
        public static void Main(string[] args)
        {
            List<string> results = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                var fabricOrc = new Kingdoms.Kingdoms().GetFabricForKingdom(Kingdoms.Kingdoms.KingdomsEnum.OrcKingdom);
                var fabricElv = new Kingdoms.Kingdoms().GetFabricForKingdom(Kingdoms.Kingdoms.KingdomsEnum.ElfKingdom);
            
                var elfUnits = new List<Unit> {fabricElv?.CreateHeal(), fabricElv?.CreateMelee(), fabricElv?.CreateRange()};
                var orcUnits = new List<Unit> {fabricOrc?.CreateHeal(), fabricOrc?.CreateMelee(), fabricOrc?.CreateRange()};
                results.Add(MakeWar(elfUnits, orcUnits));
            }
            
            Console.WriteLine($"Побед эльфов: {results.Count(e => e.Contains("ЭЛЬФЫ"))}\n" +
                              $"Побед орков:  {results.Count(e => e.Contains("ОРКИ"))}");
        }

        private static string MakeWar(List<Unit> elfUnits, List<Unit> orcUnits)
        {
            elfUnits = elfUnits.OrderBy(e => e.Initiative).ToList();
            orcUnits = orcUnits.OrderBy(o => o.Initiative).ToList();
            
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
            Console.WriteLine(message);
            return message;
        }

        private static void CheckForUpdate(List<Unit> units)
        {
            units.RemoveAll(e => e.Health <= 0);
        }
    }
}