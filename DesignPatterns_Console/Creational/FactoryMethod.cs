using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Creational
{
    /// <summary>
    /// 
    /// </summary>
    public class FactoryMethod : IDesignPattern
    {
        public void RunExample()
        {
            TreeFactory birchFactory = new BirchFactory(10);
            var birchTree = birchFactory.GetTree();

            TreeFactory mapleFactory = new MapleFactory(4);
            var mapleTree = mapleFactory.GetTree();

            Console.WriteLine($"{birchTree.Type} {birchTree.Height}");
            Console.WriteLine($"{mapleTree.Type} {mapleTree.Height}");

        }

        abstract class TreeFactory
        {
            public abstract Tree GetTree();
        }

        class BirchFactory : TreeFactory
        {
            private int _height;

            public BirchFactory(int height)
            {
                _height = height;
            }

            public override Tree GetTree()
            {
                return new Birch(_height);
            }
        }

        class MapleFactory : TreeFactory
        {
            private int _height;

            public MapleFactory(int height)
            {
                _height = height;
            }

            public override Tree GetTree()
            {
                return new Maple(_height);
            }
        }

        abstract class Tree
        {
            public abstract string Type { get; }
            public abstract int Height { get; }
        }

        class Birch : Tree
        {
            public override string Type => "Birch";

            public override int Height => _height;

            private int _height;

            public Birch(int height)
            {
                _height = height;
            }
        }
        class Maple : Tree
        {
            public override string Type => "Maple";

            public override int Height => _height;

            private int _height;

            public Maple(int height)
            {
                _height = height;
            }
        }
    }
}
