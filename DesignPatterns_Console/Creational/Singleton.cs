using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Creational
{
    /// <summary>
    /// Ensures that only one instance exists
    /// </summary>
    public class Singleton : IDesignPattern
    {
        public void RunExample()
        {
            GameManager s1 = GameManager.GetInstance();
            GameManager s2 = GameManager.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
        }
    }

    sealed class GameManager
    {
        private GameManager() { }

        private static GameManager _instance;

        public static GameManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }

            return _instance;
        }

        public void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }

    }
}
