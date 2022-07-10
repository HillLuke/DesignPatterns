using DesignPatterns_Console.Creational;
using DesignPatterns_Console.Structural;
using System;

namespace DesignPatterns_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var Example = new AbstractFactory();
            //var Example = new FactoryMethod();
            //var Example = new Builder();
            //var Example = new Prototype();
            //var Example = new Singleton();

            //var Example = new Adapter();
            //var Example = new Bridge();
            //var Example = new Composite();
            //var Example = new Decorator();
            //var Example = new Facade();
            //var Example = new Flyweight();
            var Example = new Proxy();

            Example.RunExample();
        }
    }
}