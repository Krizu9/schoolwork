using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Televisio
{
    public class TV
    {
        public int Channel { get; set; }
        private int volume;
        public int Brightness { get; set; }
        public int Volume
        {
            get { return volume; }
            set { volume = Math.Min(value, 100); }
        }
        
        private bool mute = false;
        private bool tvPower = false;

        public bool Mute
        {
            get { return mute; }
            set { mute = value; }
        }
        public bool TvPower
        {
            get { return tvPower; }
            set { tvPower = value; }
        }

        public void turnOn()
        {
            TvPower = true;
        }

        public void turnOff()
        {
            TvPower = false;
        }

        public void muteOn()
        {
            mute = true;
        }

        public void muteOff()
        {
            mute = false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TV tv = new TV();
            tv.turnOn();
            tv.muteOff();
            tv.Volume = 86;
            tv.Channel = 3;
            tv.Brightness = 60;
            Console.WriteLine("Power: " + tv.TvPower);
            Console.WriteLine("Mute: " + tv.Mute);
            Console.WriteLine("Brightness: " + tv.Brightness);
            Console.WriteLine("Channel: " + tv.Channel);
            Console.WriteLine("Volume: " + tv.Volume);
        }
    }
}