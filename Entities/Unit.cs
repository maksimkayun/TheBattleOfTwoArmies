namespace Entities;

public abstract class Unit
{
    public int Health { get; set; }
    public int Accuracy { get; set; }
    public int Initiative { get; set; }
    
    protected Unit(int health, int accuracy, int initiative)
    {
        Health = health;
        Accuracy = accuracy;
        Initiative = initiative;
    }

    public abstract void Run();
}