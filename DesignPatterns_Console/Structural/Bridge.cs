using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Console.Structural
{
    /// <summary>
    /// Split a lrge class in to two separate hierarchies, abstraction and implementation.
    /// </summary>
    class Bridge : IDesignPattern
    {
        public void RunExample()
        {
            IDevice tv1 = new TV();

            Remote remote = new Remote(tv1);
            AdvancedRemote advancedRemote = new AdvancedRemote(tv1);

            remote.GetVolume();
            advancedRemote.GetVolume();

            remote.VolumeUp();

            remote.GetVolume();
            advancedRemote.GetVolume();

            advancedRemote.Mute();
        }
    }

    class Remote
    {
        protected IDevice _device;

        public Remote(IDevice device)
        {
            _device = device;
        }

        public int GetVolume()
        {
            return _device.GetVolume();
        }

        public void VolumeUp()
        {
            _device.SetVolume(_device.GetVolume() + 1);
        }
        public void VolumeDown()
        {
            _device.SetVolume(_device.GetVolume() - 1);
        }

        public void TurnOff()
        {
            _device.TurnOff();
        }

        public void TurnOn()
        {
            _device.TurnOn();
        }
    }

    class AdvancedRemote : Remote
    {
        public AdvancedRemote(IDevice device) : base(device) { }

        public void Mute()
        {
            _device.SetVolume(0);
        }
    }

    interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetVolume(int volume);
        int GetVolume();
    }

    class TV : IDevice
    {
        private int _volume;

        public TV()
        {
            _volume = 0;
        }

        public int GetVolume()
        {
            Console.WriteLine($"TV get volume {_volume}");
            return _volume;
        }

        public void SetVolume(int volume)
        {
            _volume = volume;
            Console.WriteLine($"TV set volume {_volume}");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV turn off");
        }

        public void TurnOn()
        {
            Console.WriteLine("TV turn on");
        }
    }

}
