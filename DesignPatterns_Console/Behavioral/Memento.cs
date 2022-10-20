using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Behavioral;

/// <summary>
/// Memento is a behavioral design pattern that lets you save and restore the previous state of an object without revealing the details of its implementation.
/// </summary>
public class Memento : IDesignPattern
{
    public void RunExample()
    {
        var housePrice = new HousePrice();
        var caretaker = new HouseCaretaker(housePrice);

        housePrice.SetHousePrice(100);
        caretaker.Backup();
        Console.WriteLine(housePrice);

        housePrice.SetHousePrice(200);
        caretaker.Backup();
        Console.WriteLine(housePrice);

        housePrice.SetHousePrice(300);
        caretaker.Backup();
        Console.WriteLine(housePrice);


        caretaker.Undo();
        Console.WriteLine(housePrice);
        caretaker.Undo();
        Console.WriteLine(housePrice);
        caretaker.Undo();
        Console.WriteLine(housePrice);
    }
}

public interface ISavable<T,X> 
{
    public X CreateMomento();

    public void RestoreFromMomento(X momento);
}

public interface IMomento<T> where T : class
{

}

public class HousePrice : ISavable<HousePrice, HouseMomento>
{
    public int Value => _value;

    private int _value;

    public HouseMomento CreateMomento()
    {
        return new HouseMomento(this);
    }

    public void SetHousePrice(int x)
    {
        _value = x;
    }

    public void RestoreFromMomento(HouseMomento momento)
    {
        _value = momento.Value;
    }

    public override string ToString()
    {
        return $"House Value : {_value} ";
    }
}

public class HouseMomento : IMomento<HouseMomento>
{
    public int Value => _value;

    private int _value;

    public HouseMomento(HousePrice housePrice)
    {
        _value = housePrice.Value;
    }
}

public class HouseCaretaker
{
    private Queue<IMomento<HouseMomento>> _mementos = new Queue<IMomento<HouseMomento>>();
    private ISavable<HousePrice, HouseMomento> _savable;

    public HouseCaretaker(ISavable<HousePrice, HouseMomento> savable)
    {
        _savable = savable;
    }

    public void Backup()
    {
        _mementos.Enqueue(_savable.CreateMomento());
    }

    public void Undo()
    {
        var x = (HouseMomento)_mementos.Dequeue();
        _savable.RestoreFromMomento(x);
    }
}
