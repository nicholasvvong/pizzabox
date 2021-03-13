using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string password { get; set; }
        public int LastTimeOrdered { get; set; }
        public AStore LastStore { get; set; }
        public List<Order> OrderHistory { get; set; }
        //public Order CurrentOrder { get; protected set; }

        public Customer()
        {
            LastTimeOrdered = 0;
            OrderHistory = new List<Order>();
        }

        public Customer(string name) : this()
        {
            Name = name;
            password = name;
        }

        private bool CanOrder()
        {
            //Do a time check
            return true;
        }

        private bool CanChangeStore(AStore store)
        {
            if(LastStore == null)
            {
                LastStore = store;
                return true;
            }
            else
            {
                if(LastStore.Name == store.Name)
                    return false;
                else
                    return true;
            }
        }

        public bool StartOrderCheck(AStore store)
        {
            if(!CanOrder())
            {
                Console.WriteLine("Ordered in last 2 hours. Can't order again.");
                return false;
            }
            if(!CanChangeStore(store))
            {
                Console.WriteLine("Ordered from another store in last 24 hours. Can't order again.");
                return false;
            }
            LastStore = store;
            return true;
        }

        public void AddToOrderHistory(Order o)
        {
            OrderHistory.Add(o);
        }
    }
}