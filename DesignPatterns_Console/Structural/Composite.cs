using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural
{
    /// <summary>
    /// Lets you compose object in to tree structures and then work with these as if they were individual objects.
    /// </summary>
    class Composite : IDesignPattern
    {
        public void RunExample()
        {
            var box = new Box(0);
            var box1 = new Box(0);
            var box2 = new Box(0);

            box.Add(new Product(10));
            box.Add(new Product(10));
            box1.Add(new Product(10));
            box1.Add(new Product(10));
            box2.Add(new Product(10));
            box2.Add(new Product(10));
            box.Add(box1);
            box.Add(box2);

            Console.WriteLine(box.GetValue());
        }
    }

    interface IComponent
    {
        int GetValue();
        void Add(Component component);
        void Remove(Component component);
    }

    abstract class Component : IComponent
    {

        protected int _value;
        public Component(int value)
        {
            _value = value;
        }
        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { }
        public abstract int GetValue();
    }

    class Product : Component
    {
        public Product(int value) : base(value) { }
        public override int GetValue()
        {
            return _value;
        }
    }

    class Box : Component
    {
        private List<Component> _components;

        public Box(int value) : base(value) 
        {
            _components = new List<Component>();
        }

        public override int GetValue()
        {
            int value = 0;

            foreach (var item in _components)
            {
                value += item.GetValue();
            }

            return value;
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }


    }
}
