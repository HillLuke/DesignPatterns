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
            var DesertBiomeFactory = new DesertBiomeFactory();
            var DesertBiome = DesertBiomeFactory.MakeBiome();
            Console.WriteLine($"Biome type {DesertBiome.GetBiomeName()}");

            var ForestBiomeFactory = new ForestBiomeFactory();
            var ForestBiome = ForestBiomeFactory.MakeBiome();
            Console.WriteLine($"Biome type {ForestBiome.GetBiomeName()}");
        }
    }

    abstract class BiomeFactory 
    { 
        public abstract Biome MakeBiome();
    }

    class DesertBiomeFactory : BiomeFactory
    {
        public override Biome MakeBiome()
        {
            return new DesertBiome();
        }
    }
    class ForestBiomeFactory : BiomeFactory
    {
        public override Biome MakeBiome()
        {
            return new ForestBiome();
        }
    }

    abstract class Biome
    {
        public abstract string GetBiomeName();
    }

    class ForestBiome : Biome
    {
        public override string GetBiomeName()
        {
            return "Forest";
        }
    }
    class DesertBiome : Biome
    {
        public override string GetBiomeName()
        {
            return "Desert";
        }
    }


}
