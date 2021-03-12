using System;
using PizzaBox.Domain.Singletons;
using PizzaBox.Client;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

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

            client.PrintMenu();
            int userMenuChoice = client.ChooseMenu();
            if(userMenuChoice == 1)
            {

            }
            else if(userMenuChoice == 2)
            {
                clientStore = client.ChooseStore(StoreSingleton.Instance.Stores);

                Customer cust = new Customer();

                cust.StartOrder(clientStore);

                do
                {
                    client.PrintOrderOptions();
                    userMenuChoice = client.ChooseMenu();
                    switch(userMenuChoice)
                    {
                        case 0:
                            break;
                        case 1:
                            client.PrintCurrentOrder(cust);
                            break;
                        case 2:
                            client.PrintPizzaOptionsNoSize(clientStore);
                            userMenuChoice = client.ChooseMenu();
                            DoPizzaOption(client, userMenuChoice, clientStore, cust);
                            break;
                        case 3:
                            cust.CurrentOrder.DeletePizza(0);
                            break;
                        default:
                            userMenuChoice = 0;
                            break;
                    }
                }
                while(userMenuChoice != 0);
            }
        }

        public static void DoPizzaOption(ClientConsole client, int menuChoice, AStore store, Customer c)
        {
            if(menuChoice != store.PresetPizza.Count + 1) //Preset option
            {
                c.StartPresetPizza(store.PresetPizza[menuChoice - 1]);
                client.PrintSizes(store);
                int sizeChoice = client.ChooseMenu();
                c.CurrentOrder.CurrentPizza.AddSize(store.SizeList[sizeChoice - 1]);
                c.CurrentOrder.FinishPizza();
            }
            else
            {
                APizza custPizza = new CustomPizza();
                custPizza.AddDefaults();
                client.PrintSizes(store);
                //client.PrintCompInfo(store.SizeList);
                custPizza.AddSize(store.SizeList[client.ChooseMenu() - 1]);
                client.PrintCrusts(store);
                custPizza.AddCrust(store.CrustList[client.ChooseMenu() - 1]);
                
                do
                {
                    client.PrintToppings(store);
                    menuChoice = client.ChooseMenu();
                    if(menuChoice > store.ToppingsList.Count || custPizza.Toppings.Count >= custPizza.MaxToppings)
                    { 
                        break;
                        
                    }
                    else
                    {
                        custPizza.AddTopping(store.ToppingsList[menuChoice - 1]);
                    }

                }while(menuChoice <= store.ToppingsList.Count);

                c.CurrentOrder.AddPizza(custPizza);
            }
        }
    }
}
