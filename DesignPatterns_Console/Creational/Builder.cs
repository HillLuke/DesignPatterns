using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Creational
{
    /// <summary>
    /// Seperates the construction of a complex object from its represenation
    /// Builders
    /// ConcreteBuilder
    /// Director
    /// Product
    /// </summary>
    public class Builder : IDesignPattern
    {
        public void RunExample()
        {
            PizzaBuilder pizzaBuilder;        
            Oven oven = new Oven();

            pizzaBuilder = new HawaiianPizzaBuilder();
            oven.MakePizza(pizzaBuilder);
            Console.WriteLine(pizzaBuilder.Pizza.GetPizza());

            pizzaBuilder = new CheesePizzaBuilder();
            oven.MakePizza(pizzaBuilder);
            Console.WriteLine(pizzaBuilder.Pizza.GetPizza());
        }
    }

    class Oven
    {
        public void MakePizza(PizzaBuilder pizzaBuilder)
        {
            pizzaBuilder.AddToppings();
        }
    }

    abstract class PizzaBuilder
    {
        protected Pizza _pizza;

        public Pizza Pizza => _pizza;

        public abstract void AddToppings();
    }

    class HawaiianPizzaBuilder : PizzaBuilder
    {
        public HawaiianPizzaBuilder()
        {
            _pizza = new Pizza("Hawaiian");
        }

        public override void AddToppings()
        {
            _pizza.AddTopping("Cheese");
            _pizza.AddTopping("Ham");
            _pizza.AddTopping("Pineapple");
        }
    }
    class CheesePizzaBuilder : PizzaBuilder
    {
        public CheesePizzaBuilder()
        {
            _pizza = new Pizza("Cheese");
        }

        public override void AddToppings()
        {
            _pizza.AddTopping("Cheese");
        }
    }

    class Pizza
    {
        public string Type;
        public string Base;
        public List<string> Toppings = new List<string>();

        public Pizza(string type)
        {
            Type = type;
        }

        public void AddTopping(string topping)
        {
            Toppings.Add(topping);
        }

        public string GetPizza()
        {
            return $"Pizza type: {Type} \nToppings: {string.Join(',',Toppings)}";
        }
    }
}
