using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural
{
    /// <summary>
    /// Lets you attach new behaviors to objects by placing these objects inside wrapper objects
    /// that contain the behaviours.
    /// </summary>
    public class Decorator : IDesignPattern
    {
        public void RunExample()
        {
            var simple = new ConcreteLogger();
            var decorator1 = new Logger1(simple);
            var decorator2 = new Logger2(decorator1);

            decorator2.Log();
        }
    }

    public abstract class Logger
    {
        public abstract void Log();
    }

    public class ConcreteLogger : Logger
    {
        public override void Log()
        {
            Console.WriteLine("ConcreteLogger");
        }
    }

    public class LoggerDecorator : Logger
    {
        protected Logger _logger;

        public LoggerDecorator(Logger logger)
        {
            _logger = logger;
        }

        public void SetLogger(Logger logger)
        {
            _logger = logger;
        }

        public override void Log()
        {
            _logger.Log();
        }
    }

    public class Logger1 : LoggerDecorator
    {
        public Logger1(Logger logger) : base(logger)
        {
        }

        public override void Log()
        {
            base.Log();
            Console.WriteLine("Logger1");
        }
    }

    public class Logger2 : LoggerDecorator
    {
        public Logger2(Logger logger) : base(logger)
        {
        }

        public override void Log()
        {
            base.Log();
            Console.WriteLine("Logger2");
        }
    }
}