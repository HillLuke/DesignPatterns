using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Behavioral;

/// <summary>
/// Allows you to pass a request along a chain of handlers.
/// Each handler decides either to process the request or to pass it to the nex handler in the chain.
/// </summary>
public class ChainOfResponsibility : IDesignPattern
{
    public void RunExample()
    {
        var h1 = new StringHandler("a");
        var h2 = new StringHandler("b");
        var h3 = new StringHandler("c");
        var h4 = new StringHandler("d");

        h1.SetNext(h2);
        h2.SetNext(h3);
        h3.SetNext(h4);

        Console.WriteLine("Test: a");
        h1.Handle(new() { Input = "a" });

        Console.WriteLine("Test: b");
        h1.Handle(new() { Input = "b" });

        Console.WriteLine("Test: c");
        h1.Handle(new() { Input = "c" });

        Console.WriteLine("Test: d");
        h1.Handle(new() { Input = "d" });

        Console.WriteLine("Test: e");
        h1.Handle(new() { Input = "e" });
    }
}

public class Request
{
    public string Input { get; set; }
}

public interface IHandler 
{
    void SetNext(IHandler handler);
    void Handle(Request request);
}

public class Handler : IHandler
{
    private IHandler _handler;

    public virtual void Handle(Request request)
    {
        if (_handler != null)
        {
            _handler.Handle(request);
        }
    }

    public void SetNext(IHandler handler)
    {
        _handler = handler;
    }
}

public class StringHandler : Handler
{
    private string _handles;

    public StringHandler(string handles)
    {
        _handles = handles;
    }

    public override void Handle(Request request)
    {
        if (request.Input.Contains(_handles))
        {
            Console.WriteLine("Complete");
        }
        else
        {
            Console.WriteLine("Pass");
            base.Handle(request);
        }
    }
}
