using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Creational
{
    public class AbstractFactory : IDesignPattern
    {
        public void RunExample()
        {
            new FarmClient(new FarmFactory1()).ListProduce();
            new FarmClient(new FarmFactory2()).ListProduce();
        }
    }

    class FarmClient
    {
        private Vegatable _vegatable;
        private Fruit _fruit;

        public FarmClient(IFactory factory)
        {
            _vegatable = factory.CreateVegatable();
            _fruit = factory.CreateFruit();
        }

        public void ListProduce()
        {
            Console.WriteLine($"Farm produces {_vegatable.Name} and {_fruit.Name}");
        }
    }

    interface IFactory
    {
        public Vegatable CreateVegatable();
        public Fruit CreateFruit();
    }

    class FarmFactory1 : IFactory
    {
        public Fruit CreateFruit()
        {
            return new Apple();
        }

        public Vegatable CreateVegatable()
        {
            return new Potato();
        }
    }
    class FarmFactory2 : IFactory
    {
        public Fruit CreateFruit()
        {
            return new Orange();
        }

        public Vegatable CreateVegatable()
        {
            return new Carrot();
        }
    }

    abstract class Vegatable 
    {
        public abstract string Name { get; }
    }

    class Potato : Vegatable
    {
        public override string Name => "Potato";
    }

    class Carrot : Vegatable
    {
        public override string Name => "Carrot";
    }

    abstract class Fruit
    {
        public abstract string Name { get; }
    }

    class Apple : Fruit
    {
        public override string Name => "Apple";
    }

    class Orange : Fruit
    {
        public override string Name => "Orange";
    }
}