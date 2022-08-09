using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Behavioral;

/// <summary>
/// Turns a request in to a stand alone object that contains all information about the request. 
/// This lets ou pass requests as method arguments, delay, or queue a requests execution.
/// </summary>
public class Command : IDesignPattern
{
    public void RunExample()
    {
        var commandHistory = new CommandHistory();

        commandHistory.AddCommand(new SayCommand("hello"));
        commandHistory.AddCommand(new YellCommand("world"));

        var reaplyComplete = false;
        while (!reaplyComplete)
        {
            var command = commandHistory.PopCommand();
            if (command == null) { reaplyComplete = true; continue; }
            command.Execute();
        }
    }    
}

public class CommandHistory
{
    Stack<ICommand> _commands;

    public CommandHistory()
    {
        _commands = new Stack<ICommand>();
    }

    public void AddCommand(ICommand command)
    {
        _commands.Push(command);
    }

    public ICommand PopCommand()
    {
        return _commands.Pop();
    }
}

public interface ICommand
{
    void Execute();
}

public class SayCommand : ICommand
{
    private string _input;

    public SayCommand(string input)
    {
        _input = input.ToLower();
    }

    public void Execute()
    {
        Console.WriteLine(_input);
    }
}

public class YellCommand : ICommand
{
    private string _input;

    public YellCommand(string input)
    {
        _input = input.ToUpper();
    }

    public void Execute()
    {
        Console.WriteLine(_input);
    }
}

