using System;
using PizzaBox.Domain.Singletons;
using PizzaBox.Client;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //InitXML();
            ApplicationStart();
        }

        private static void InitXML()
        {
            List<Customer> initC = CustomerSingleton.Instance.Customers;
            List<AStore> initS = StoreSingleton.Instance.Stores;
        }

        public static void ApplicationStart()
        {
            ClientConsole client = new ClientConsole();

            client.PrintInit();
            int userMenuChoice = client.ChooseMenu();

            if(userMenuChoice == 1) //StoreFront
            {
                StoreFront store = new StoreFront();
                store.Start(client);
            }
            else if(userMenuChoice == 2) //CustomerFront
            {
                CustomerFront custFront = new CustomerFront();
                custFront.Start(client);
            }
        }
    }
}
