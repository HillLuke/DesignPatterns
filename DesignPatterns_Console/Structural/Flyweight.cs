using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural;

/// <summary>
/// Lets you fit more objects into the available amount of RAM by sharing common parts of state
/// between multiple objects.
/// </summary>
public class Flyweight : IDesignPattern
{
    public void RunExample()
    {
        var forest = new Forest();
        for (int i = 0; i < 10000; i++)
        {
            forest.PlantTree(1, 1, "oaks");
        }

        var forestTest = new ForestTest();
        for (int i = 0; i < 10000; i++)
        {
            forestTest.PlantTree(1, 1, "oaks");
        }

        Console.ReadKey();
    }
}

public class Tree
{
    public int X { get; init; }
    public int Y { get; init; }
    public TreeType Type { get; init; }
}

public class TreeType
{
    public string type { get; set; }

    public void DoThing(Tree tree)
    {
        // do a thing with the extrinsic data (data that can change)
    }
}

public class TreeFactory
{
    public List<TreeType> TreeTypes;

    public TreeFactory()
    {
        TreeTypes = new List<TreeType>();
    }

    public TreeType GetTreeType(string type)
    {
        var returnType = TreeTypes.FirstOrDefault(t => t.type == type);

        if (returnType == null)
        {
            var treeType = new TreeType() { type = type };
            TreeTypes.Add(treeType);
            returnType = treeType;
        }

        return returnType;
    }
}

public class Forest
{
    public TreeFactory TreeFactory { get; set; }
    public List<Tree> Trees;

    public Forest()
    {
        TreeFactory = new TreeFactory();
        Trees = new List<Tree>();
    }

    public void PlantTree(int x, int y, string type)
    {
        var treeType = TreeFactory.GetTreeType(type);
        Trees.Add(new Tree
        {
            X = x,
            Y = y,
            Type = treeType
        });
    }

    public void DoThing()
    {
        Console.WriteLine(Trees.Count);
    }
}

public class TreeTest
{
    public int X { get; init; }
    public int Y { get; init; }
    public string Type { get; init; }
}

public class ForestTest
{
    public List<TreeTest> Trees;

    public ForestTest()
    {
        Trees = new List<TreeTest>();
    }

    public void PlantTree(int x, int y, string type)
    {
        Trees.Add(new TreeTest
        {
            X = x,
            Y = y,
            Type = type
        });
    }

    public void DoThing()
    {
        Console.WriteLine(Trees.Count);
    }
}