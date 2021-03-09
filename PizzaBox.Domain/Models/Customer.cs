using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public int LastTimeOrdered { get; protected set; }
        public AStore LastStore { get; protected set; }
        public List<Order> OrderHistory { get; protected set; }

        public Customer()
        {
            LastTimeOrdered = 0;
            OrderHistory = new List<Order>();
        }

        private bool CanOrder()
        {
            return true;
        }

        private bool CanChangeStore()
        {
            return true;
        }
    }
}