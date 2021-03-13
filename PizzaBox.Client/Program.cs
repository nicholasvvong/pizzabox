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
            //PlayWithStore();
            CreateClient();
        }

        public static void PlayWithStore()
        {
            //var storeSingleton = StoreSingleton.Instance;

            foreach(var s in StoreSingleton.Instance.Stores)
            {
                Console.WriteLine(s);
            }
        }

        public static void CreateClient()
        {
            ClientConsole client = new ClientConsole();
            AStore clientStore;

            client.PrintInit();
            int userMenuChoice = client.ChooseMenu();

            if(userMenuChoice == 1)
            {
                clientStore = client.ChooseStore(StoreSingleton.Instance.Stores);
                client.PrintStoreOptions();
                userMenuChoice = client.ChooseMenu();
                if(userMenuChoice == 1)
                {
                    for(int i = 0; i < clientStore.Orders.Count; i++)
                    {
                        client.PrintCurrentOrder(clientStore.Orders[i]);
                    }
                }
                else if(userMenuChoice == 2)
                {
                    Console.WriteLine("Total Sales: " + clientStore.GetTotalSales());
                }
            }
            else if(userMenuChoice == 2)
            {
                List<Customer> init = CustomerSingleton.Instance.Customers;

                client.PrintMenu();
                if(userMenuChoice == 1)
                {
                    Customer cust = init[0];
                    Console.WriteLine("Name: " + cust.Name);
                    for(int i = 0; i < cust.OrderHistory.Count; i++)
                    {
                        client.PrintCurrentOrder(cust.OrderHistory[i]);
                    }
                    
                }
                else if(userMenuChoice == 2)
                {
                    clientStore = client.ChooseStore(StoreSingleton.Instance.Stores);

                    Customer cust = init[2];
                    if(cust.StartOrderCheck(clientStore))
                    {
                        Order currentOrder = new Order(cust);

                        do
                        {
                            client.PrintOrderOptions();
                            userMenuChoice = client.ChooseMenu();
                            switch(userMenuChoice)
                            {

                                case 1:
                                    client.PrintCurrentOrder(currentOrder);
                                    break;
                                case 2:
                                    client.PrintPizzaOptionsNoSize(clientStore);
                                    userMenuChoice = client.ChooseMenu();
                                    DoPizzaOption(client, userMenuChoice, clientStore, currentOrder);
                                    break;
                                case 3:
                                    DeletePizza(client, currentOrder);
                                    break;
                                case 4:
                                    FinishOrder(client, cust, clientStore, currentOrder);
                                    break;
                                default:
                                    userMenuChoice = 4;
                                    break;
                            }
                        }
                        while(userMenuChoice != 4);
                    }

                    StoreSingleton.Instance.UpdateStores();
                    CustomerSingleton.Instance.UpdateCustomers();
                }
            }
        }

        private static void FinishOrder(ClientConsole client, Customer c, AStore store, Order o)
        {
            store.AddOrder(o);
            c.AddToOrderHistory(o);
            
        }

        public static void DeletePizza(ClientConsole client, Order o)
        {
            client.PrintCurrentOrder(o);
            int userChoice = client.ChooseMenu();
            o.DeletePizza(userChoice - 1);
        }   

        public static void DoPizzaOption(ClientConsole client, int menuChoice, AStore store, Order o)
        {
            if(menuChoice != store.PresetPizza.Count + 1) //Preset option
            {
                o.StartPresetPizza(store.PresetPizza[menuChoice - 1]);
                client.PrintSizes(store);
                int sizeChoice = client.ChooseMenu();
                o.CurrentPizza.AddSize(store.SizeList[sizeChoice - 1]);
                o.FinishPizza();
            }
            else
            {
                o.StartCustomPizza();
                o.CurrentPizza.AddDefaults();
                client.PrintSizes(store);
                //client.PrintCompInfo(store.SizeList);
                o.CurrentPizza.AddSize(store.SizeList[client.ChooseMenu() - 1]);
                client.PrintCrusts(store);
                o.CurrentPizza.AddCrust(store.CrustList[client.ChooseMenu() - 1]);
                
                do
                {
                    client.PrintToppings(store);
                    menuChoice = client.ChooseMenu();
                    if(menuChoice > store.ToppingsList.Count || o.CurrentPizza.Toppings.Count >= o.CurrentPizza.MaxToppings)
                    { 
                        break;
                    }
                    else
                    {
                        o.CurrentPizza.AddTopping(store.ToppingsList[menuChoice - 1]);
                    }

                }while(menuChoice <= store.ToppingsList.Count);

                o.FinishPizza();
            }
        }
    }
}
