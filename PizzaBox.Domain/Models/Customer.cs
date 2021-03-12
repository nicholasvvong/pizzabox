using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string password { get; set; }
        public int LastTimeOrdered { get; protected set; }
        public AStore LastStore { get; protected set; }
        public List<Order> OrderHistory { get; protected set; }
        public Order CurrentOrder { get; protected set; }

        public Customer()
        {
            LastTimeOrdered = 0;
            OrderHistory = new List<Order>();
        }

        private bool CanOrder()
        {
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

        private void StartOrderCheck(AStore store)
        {
            if(!CanOrder())
            {
                Console.WriteLine("Ordered in last 2 hours. Can't order again.");
            }
            if(!CanChangeStore(store))
            {
                Console.WriteLine("Ordered from another store in last 24 hours. Can't order again.");
            }
            LastStore = store;
        }

        public void StartOrder(AStore store)
        {
            StartOrderCheck(store);
            //if(CurrentOrder == null)
            CurrentOrder = new Order();
            
        }

        public bool isOrderStarted()
        {
            if(CurrentOrder == null)
                return false;
            else
                return true;
        }

        public void StartPizza()
        {
            if(!isOrderStarted())
            {
                Console.WriteLine("Order not started. Start an order first.");
                return;
            }

            CurrentOrder.CreatePizza();
        }

        
        public void StartPresetPizza(APizza pizza)
        {
            StartPizza();
            CurrentOrder.CurrentPizza.CopyPizza(pizza);
        }
        
        protected void PlaceOrder()
        {
            LastStore.AddOrder(CurrentOrder);
            OrderHistory.Add(CurrentOrder);       
        }

        /// <summary>
        /// Type determines type of pizza ordered(custom vs preset)
        /// 0 = custom
        /// 1 = meat
        /// 2 = vegan
        /// </summary>
        /// <param name="type"></param>
        public void CreatePizza(int type)
        {
            switch(type)
            {
                case 0:
                    CreateCustomPizza();
                    break;
                case 1:
                    AddMeatPizza();
                    break;
                case 2:
                    AddVeganPizza();
                    break;
                default:
                    break;
            }
        }

        public void CreateCustomPizza()
        {
            APizza customPizza = new CustomPizza();
            CustomerGetSize(customPizza);
            CustomerGetCrust(customPizza);
            CustomerGetToppings(customPizza);
            CurrentOrder.FinishPizza();
        }
        private void CustomerGetSize(APizza customPizza)
        {
            customPizza.Size = LastStore.SizeList[0] as Size;
        }
        private void CustomerGetCrust(APizza customPizza)
        {
            customPizza.Crust = LastStore.CrustList[0] as Crust;
        }
        private void CustomerGetToppings(APizza customPizza)
        {
            customPizza.Toppings.Add(LastStore.ToppingsList[0] as Topping);
            customPizza.Toppings.Add(LastStore.ToppingsList[2] as Topping);
            customPizza.Toppings.Add(LastStore.ToppingsList[4] as Topping);
            customPizza.Toppings.Add(LastStore.ToppingsList[6] as Topping);
        }
        public void AddMeatPizza()
        {
            MeatPizza meatPizza = new MeatPizza();
            meatPizza.Size = LastStore.SizeList[0] as Size;
            meatPizza.Crust = LastStore.CrustList[0] as Crust;
            meatPizza.AddToppings(LastStore);
        }
        public void AddVeganPizza()
        {
            CurrentOrder.FinishPizza();
        }
    }
}