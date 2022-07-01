using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural;

/// <summary>
/// Provides a simplified interface to a library, framework or any other complex set of classes
/// </summary>
public class Facade : IDesignPattern
{
    public void RunExample()
    {
        System system = new System();
        system.Run();
    }
}

/// <summary>
/// Facade Knows which subsystem classes are responsible for a request, delegates request to
/// appropriate subsystem objects
/// </summary>
public class System
{
    private Subsystem1 subsystem1;
    private Subsystem2 subsystem2;

    public System()
    {
        subsystem1 = new Subsystem1();
        subsystem2 = new Subsystem2();
    }

    public void Run()
    {
        Console.WriteLine($"{subsystem1.DoThing()}{subsystem2.DoSomeThing()}");
    }
}

public class Subsystem1
{
    public string DoThing()
    {
        return "Subsystem1\n";
    }
}

public class Subsystem2
{
    public string DoSomeThing()
    {
        return "Subsystem2\n";
    }
}