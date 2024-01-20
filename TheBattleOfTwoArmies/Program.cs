using System;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace TheBattleOfTwoArmies
{
    static class Program
    {
        public static void Main(string[] args)
        {
            List<string> results = new List<string>();
            var facade = new GameFacade();
            facade.SetLogEnabling(false);
            for (int i = 0; i < 100; i++)
            {
                var elfUnits = facade.CreateElfArmy();
                var orcUnits = facade.CreateOrcArmy();
                results.Add(facade.MakeWar(elfUnits, orcUnits));
            }
            
            Console.WriteLine($"Побед эльфов: {results.Count(e => e.Contains("ЭЛЬФЫ"))}\n" +
                              $"Побед орков:  {results.Count(e => e.Contains("ОРКИ"))}");
        }
    }
}