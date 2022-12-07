using CustumerOrder.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CustumerOrder.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrdemItem> Items { get; set; } = new List<OrdemItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrdemItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrdemItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.00;

            foreach(OrdemItem items in Items)
            {
                sum += items.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd/MM/yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order Items: ");

            foreach(OrdemItem item in Items)
            {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Price);
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $");
                sb.AppendLine(item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.Append("Total price: $");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
