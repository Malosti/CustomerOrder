using CustumerOrder.Entities;
using CustumerOrder.Entities.Enums;
using System;
using System.Globalization;

namespace CustumerOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            //Instanciou e amrmazenou as informações do cliente em Client
            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order?  ");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string nameProd = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(nameProd, price);
                OrdemItem item = new OrdemItem(quantity, price, product);
                order.AddItem(item);
            }
            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY");
            Console.WriteLine();
            Console.WriteLine(order.ToString());
        }
    }
}
