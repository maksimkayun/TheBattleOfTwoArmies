namespace Common;

public class ConsoleLogger
{
    public static ConsoleLogger Instance => Nested.Instance;

    public bool EnableLog = true;
    
    public void Log(string message)
    {
        if (EnableLog)
        {
            Console.WriteLine(message);
        }
    }

    private class Nested
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Nested()
        {
        }

        internal static readonly ConsoleLogger Instance = new();
    }
}