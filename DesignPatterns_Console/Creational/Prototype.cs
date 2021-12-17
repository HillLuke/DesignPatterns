using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Creational
{
    /// <summary>
    /// Lets you copy existing objects without making code that depends on their class.
    /// </summary>
    public class Prototype : IDesignPattern
    {
        public void RunExample()
        {
            // Test with constructor/public properties
            var knight1 = new Knight(new Sword(5));
            knight1.Name = "knight 1";
            var knight2 = knight1.ShallowCopy();
            knight2.Name = "knight 2";
            var knight3 = knight1.DeepCopy();
            knight3.Name = "knight 3";

            Console.WriteLine("----------------");
            Console.WriteLine("Original");
            Console.WriteLine("----------------");
            Console.WriteLine(knight1.ToString());
            Console.WriteLine(knight2.ToString());
            Console.WriteLine(knight3.ToString());

            knight1.Name = "new name";
            knight1.EquippedWeapon.Damage = 50;

            Console.WriteLine("\n----------------");
            Console.WriteLine("knight 1 altered | Name changed to 'new name' | weapon damage changed to 50");
            Console.WriteLine("----------------");
            Console.WriteLine(knight1.ToString());
            Console.WriteLine(knight2.ToString());
            Console.WriteLine(knight3.ToString());
        }

        public abstract class Weapon
        {
            public abstract string Name { get;}
            public int Damage { get; set; }

            protected Weapon(int damage)
            {
                Damage = damage;
            }
            public abstract Weapon ShallowCopy();
        }

        public class Sword : Weapon
        {
            public override string Name => "Sword";

            public Sword(int damage) : base(damage) { }

            public override Sword ShallowCopy()
            {
                return (Sword)this.MemberwiseClone();
            }
        }

        abstract class Character
        {
            public string Name;
            public Weapon EquippedWeapon { get; set; }

            protected Character(Weapon weapon)
            {
                EquippedWeapon = weapon;
            }

            public abstract Character ShallowCopy();
            public abstract Character DeepCopy();
        }

        class Knight : Character
        {
            public Knight(Weapon weapon) : base(weapon) { }

            public override Knight ShallowCopy()
            {
                return (Knight)this.MemberwiseClone();
            }

            public override Knight DeepCopy()
            {
                Knight clone = (Knight)this.MemberwiseClone();
                clone.Name = Name;
                clone.EquippedWeapon = EquippedWeapon.ShallowCopy();
                clone.EquippedWeapon.Damage = EquippedWeapon.Damage;
                return clone;
            }

            public override string ToString()
            {
                return $"Knight | Name: {Name} | Weapon {EquippedWeapon.Name} Damage {EquippedWeapon.Damage}";
            }
        }
    }
}
