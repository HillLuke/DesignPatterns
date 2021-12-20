using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural
{
    /// <summary>
    /// Allows objects with incompatible interfaces to collaborate.
    /// </summary>
    public class Adapter : IDesignPattern
    {
        public void RunExample()
        {
            IHarvestable berryBush = new BerryBush();
            IHarvestable ironOre = new MinableAdapter(new Iron());

            Harvester harvester = new Harvester();

            harvester.Harvest(berryBush);
            harvester.Harvest(ironOre);
        }
    }

    interface IHarvestable
    {
        void Harvest();
    }

    class BerryBush : IHarvestable
    {
        public void Harvest()
        {
            Console.WriteLine("Harvesting berry bush");
        }
    }

    interface IMinable
    {
        void Mine();
    }

    class Iron : IMinable
    {
        public void Mine()
        {
            Console.WriteLine("Mining iron");
        }
    }

    class MinableAdapter : IHarvestable
    {
        private IMinable _minable;

        public MinableAdapter(IMinable minable)
        {
            _minable = minable;
        }

        public void Harvest()
        {
            _minable.Mine();
        }
    }

    class Harvester
    {
        public void Harvest(IHarvestable harvestable)
        {
            harvestable.Harvest();
        }
    }
}
