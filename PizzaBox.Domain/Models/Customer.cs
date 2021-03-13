using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string password { get; set; }
        public DateTime LastTimeOrdered { get; set; }
        public AStore LastStore { get; set; }
        public List<Order> OrderHistory { get; set; }
        //public Order CurrentOrder { get; protected set; }

        public Customer()
        {
            LastTimeOrdered = DateTime.MinValue;
            OrderHistory = new List<Order>();
        }

        public Customer(string name) : this()
        {
            Name = name;
            password = name;
        }

        private bool CanOrder()
        {

            if(DateTime.UtcNow.Subtract(LastTimeOrdered).TotalHours > 2) //If it has been more than 2 hours since last order
            {
                return true;
            }
            else
            { 
                return false;
            }
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
                if(LastStore.Name != store.Name)
                {
                    if(DateTime.UtcNow.Subtract(LastTimeOrdered).TotalHours > 24) //If it has been 24 hours(1day) since last order
                    {
                        return true;
                    }
                    else
                    { 
                        return false;
                    }
                }
                else
                    return true;
            }
        }

        public bool StartOrderCheck(AStore store)
        {
            if(!CanChangeStore(store))
            {
                Console.WriteLine("Ordered from another store in last 24 hours. Can't order again.");
                return false;
            }
            if(!CanOrder())
            {
                Console.WriteLine("Ordered in last 2 hours. Can't order again.");
                return false;
            }
            LastStore = store;
            LastTimeOrdered = DateTime.UtcNow;
            return true;
        }

        public void AddToOrderHistory(Order o)
        {
            OrderHistory.Add(o);
        }

        public bool PasswordCheck(string checkPw)
        {
            return (password == checkPw);
        }
    }
}