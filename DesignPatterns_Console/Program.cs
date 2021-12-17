﻿using DesignPatterns_Console.Creational;
using System;

namespace DesignPatterns_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var Example = new AbstractFactory();
            //var Example = new FactoryMethod();
            //var Example = new Builder();

            Example.RunExample();
        }
    }
}
