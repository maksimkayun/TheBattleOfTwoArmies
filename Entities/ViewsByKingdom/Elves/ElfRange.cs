﻿using Range = Entities.BasicViews.Range;

namespace Entities.ViewsByKingdom.Elves;

public class ElfRange : Range
{
    public ElfRange(int health, int accuracy, int initiative, int arrows, int agility, int damage) :
        base(health, accuracy, initiative, arrows, agility, damage)
    {
    }

    public override void Run()
    {
        throw new NotImplementedException();
    }

    public override void Attack(Unit unit)
    {
        throw new NotImplementedException();
    }
}