using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WashingMachine
{

    public class Machine
    {
        public int rpm;
        public int waterAmount;
        public int duration;
        private bool status = false;
        private bool programOn=false;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        public bool ProgramOn
        {
            get { return programOn; }
            set { programOn = value; }
        }
        public int setRpm
        {
            get { return rpm; }
            set { rpm = value; }
        }
        public int setDuration
        {
            get { return duration; }
            set { duration = value; }
        }
        public int setWaterAmount
        {
            get { return waterAmount; }
            set { waterAmount = value; }
        }
        public void turnOn()
        {
            status = true;
        }
        public void turnOff()
        {
            status = false;
            programOn= false;
        }
        public void turnProgramOn()
        {
            programOn = true;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Machine machine = new Machine();
            machine.turnOn();
            machine.setRpm = 500;
            machine.setWaterAmount = 5;
            machine.setDuration = 60;
            machine.turnProgramOn();
            Console.WriteLine("pyykkikoneen status: " + machine.Status);
            Console.WriteLine("Pesun kesto: " + machine.duration);
            Console.WriteLine("Kierrokset säädetty: " + machine.rpm + " kierrosta minuutissa");
            Console.WriteLine("veden määrä: " + machine.waterAmount + " Litraa");
            Console.WriteLine("Ohjelma päällä: " + machine.ProgramOn);
        }
    }
}