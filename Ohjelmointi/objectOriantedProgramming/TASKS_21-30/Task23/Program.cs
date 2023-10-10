using System;
using System.Collections.Generic;

namespace CheckoutQueueExample
{
    public class CheckoutQueue
    {
        private Queue<string> _queue = new Queue<string>();

        public void goToQueue(string customerName)
        {
            _queue.Enqueue(customerName);
            Console.WriteLine($"Jonossa on nyt {_queue.Count} asiakasta:");
            foreach (var customer in _queue)
            {
                Console.WriteLine(customer);
            }
        }

        public void exitQueue()
        {
            if (_queue.Count == 0)
            {
                Console.WriteLine("Jonossa ei ole yhtään asiakasta.");
            }
            else
            {
                Console.WriteLine($"\nPoistetaan jonon ensimmäinen asiakas: {_queue.Dequeue()}");
                Console.WriteLine($"Jonossa on nyt {_queue.Count} asiakasta:");
                foreach (var customer in _queue)
                {
                    Console.WriteLine(customer);
                }
            }
        }

        public int Length { get { return _queue.Count; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var checkoutQueue = new CheckoutQueue();

            string customerName;
            do
            {
                Console.Write("\nAnna jonoon tulevan asiakkaan nimi (enter lopettaa): ");
                customerName = Console.ReadLine();
                if (customerName != "")
                {
                    Console.WriteLine("");
                    checkoutQueue.goToQueue(customerName);
                }
            } while (customerName != "");

            while (checkoutQueue.Length > 0)
            {   
                Console.WriteLine("\n----- palvellaan jonon ensimmäistä asiakasta -------");
                checkoutQueue.exitQueue();
            }

            Console.WriteLine("Kaikki asiakkaat palveltu");
        }
    }
}
