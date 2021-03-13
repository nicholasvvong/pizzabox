using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Order
    {
        public string Name { get; set; }
        public int MaxPrice { get; set; }
        public int MaxPizzas { get; set; }
        public decimal CurTotal { get; set; }
        public APizza CurrentPizza { get; set; }
        public List<APizza> Pizzas { get; set; }

        public Order()
        {
            Pizzas = new List<APizza>();
            MaxPrice = 250;
            MaxPizzas = 50;
            CurTotal = 0;
        }

        public Order(Customer c) : this()
        {
            Name = c.Name;
        }

        private Order(int maxPrice, int maxPizzas) : this()
        {
            MaxPrice = maxPrice;
            MaxPizzas = maxPizzas;
        }

        public void AddPizza(APizza pizza)
        {
            if(Pizzas.Count >= MaxPizzas)
                Console.WriteLine("Invalid. Too Many Pizzas ({0} MaxPizzas Per Order)", MaxPizzas);
            if((CurTotal + pizza.CalculatePrice()) >= MaxPrice)
                Console.WriteLine("Invalid. Order excesses price limit (${0}).", MaxPrice);
            Pizzas.Add(pizza);
            CurTotal += pizza.CalculatePrice();
        }

        public void StartPresetPizza(APizza pizza)
        {
            StartCustomPizza();
            CurrentPizza.CopyPizza(pizza);
        }
        
        public void DeletePizza(int index)
        {
            CurTotal -= Pizzas[index].CalculatePrice();
            Pizzas.RemoveAt(index);
        }

        public override string ToString()
        {
            string orderList = "";
            for(int i = 0; i < Pizzas.Count; i++)
            {
                orderList += "#" + i + " : " + Pizzas[i] + "\n";
            }

            return orderList;
        }

        public void StartCustomPizza()
        {
            CurrentPizza = new CustomPizza();
        }

        public void FinishPizza()
        {
            AddPizza(CurrentPizza);
            CurrentPizza = null;
        }

        private bool isPizzaStarted()
        {
            if(CurrentPizza == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}