using Common;
using Entities.Strategy;

namespace Entities;

public abstract class Unit
{
    protected readonly ConsoleLogger Logger = ConsoleLogger.Instance;
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Accuracy { get; set; }
    public int Initiative { get; set; }
    protected IStrategy Strategy;

    protected Unit(int health, int accuracy, int initiative, IStrategy strategy)
    {
        Health = health;
        MaxHealth = health;
        Accuracy = accuracy;
        Initiative = initiative;
        Strategy = strategy;
    }

    public abstract void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits);

    protected bool ProbabilityBy(int value) => new Random().Next(1, 101) <= value;

    public virtual void TakeAttack(int valueDamage)
    {
        Health -= valueDamage;
    }
}