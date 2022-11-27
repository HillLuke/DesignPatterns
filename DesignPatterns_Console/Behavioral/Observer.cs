using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Behavioral;

public class Observer : IDesignPattern
{
    public void RunExample()
    {
        var pizzaStock = new PizzaStock();

        var stockManager = new StockManager();
        var menuManager = new MenuManager();

        pizzaStock.Attach(stockManager);
        pizzaStock.Attach(menuManager);

        pizzaStock.TakeOrder();
    }
}

public interface IObserver
{
    void Update(ISubject subject);
}

public interface ISubject
{
    void Attach(IObserver observer);

    void Detach(IObserver observer);
}

public class PizzaStock : ISubject
{
    public int Stock => _stock;

    private List<IObserver> _observers = new List<IObserver>();
    private int _stock = 1;

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine($"Subject: Attached observer {nameof(observer)} {observer.GetType().Name}");
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"Subject: Detached observer {nameof(observer)} {observer.GetType().Name}");
    }

    private void Notify()
    {
        Console.WriteLine("Subject: Notifying observers...");

        foreach (var item in _observers)
        {
            item.Update(this);
        }
    }

    public void TakeOrder()
    {
        _stock--;

        Notify();
    }
}

public class StockManager : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as PizzaStock).Stock == 0)
        {
            Console.WriteLine("Ordering more stock");
        }
    }
}

public class MenuManager : IObserver
{
    public void Update(ISubject subject)
    {
        if ((subject as PizzaStock).Stock == 0)
        {
            Console.WriteLine("Taking item off menu");
        }
    }
}