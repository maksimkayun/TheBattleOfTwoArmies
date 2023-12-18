using Entities.Strategy;

namespace Entities;

public abstract class Unit
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Accuracy { get; set; }
    public int Initiative { get; set; }
    protected IStrategy _strategy;
    
    protected Unit(int health, int accuracy, int initiative, IStrategy strategy)
    {
        Health = health;
        MaxHealth = health;
        Accuracy = accuracy;
        Initiative = initiative;
        _strategy = strategy;
    }

    public abstract void Run(List<Unit> enemyUnits, List<Unit> friendlyUnits);

    protected bool ProbabilityBy(int value) => new Random().Next(1, 101) <= value;

    public virtual void TakeAttack(int valueDamage)
    {
        Health -= valueDamage;
    }
}