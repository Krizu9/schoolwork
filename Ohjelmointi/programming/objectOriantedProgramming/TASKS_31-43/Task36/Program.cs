using System;
using System.Collections.Generic;
using System.Linq;

namespace Task36
{
    class Program
    {
        static void Main(string[] args)
        {
            List<InvoiceItem> items = new List<InvoiceItem>
            {
                new InvoiceItem("Milk", 1.75, 1),
                new InvoiceItem("Beer", 5.25, 1),
                new InvoiceItem("Butter", 2.50, 2)
            };

            Invoice invoice = new Invoice("Kirsi Kernel", items);

            Console.WriteLine(PrintInvoice(invoice));
        }

        private static string PrintInvoice(Invoice invoice)
        {
            string output = $"Customer {invoice.Customer}'s invoice:\n";
            output += "=====================================\n";

            foreach (var item in invoice.Items)
            {
                output += $"{item.Name} {item.Price.ToString("0.00e")} {item.Quantity} pieces {item.Total.ToString("0.00e")} total\n";
            }

            output += "=====================================\n";
            output += $"Total: {invoice.ItemsTogether} pieces {invoice.CountTotal().ToString("0.00e")}";

            return output;
        }
    }

    class InvoiceItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get { return Price * Quantity; } }

        public InvoiceItem(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    class Invoice
    {
        public string Customer { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public int ItemsCount { get { return Items.Count; } }
        public int ItemsTogether { get { return Items.Sum(x => x.Quantity); } }

        public Invoice(string customer, List<InvoiceItem> items)
        {
            Customer = customer;
            Items = items;
        }

        public double CountTotal()
        {
            return Items.Sum(x => x.Total);
        }
    }
}
