using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heater
{

    public class Heater
    {
        public int temperature;
        public int humidy;
        private bool status = false;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public int setTemperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        public int setHumidy
        {
            get { return humidy; }
            set { humidy = value; }
        }
        public void turnOn()
        {
            status = true;
        }
        public void turnOff()
        {
            status = false;
        }
    }
    internal class Program
        {
            static void Main(string[] args)
            {
            Heater heater= new Heater();
            heater.turnOn();
            heater.setTemperature = 70;
            heater.setHumidy = 50;
            Console.WriteLine("kiukaan status: " + heater.Status +", Lämpötila säädetty: " + heater.temperature + "C, ja ilman kosteus säädetty: " + heater.humidy + "%");
            }    
        }
}