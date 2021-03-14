using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    public class ClientConsole
    {
        string userInput = "";
        int userIntInput = 0;
        int maxMenuOptions = 2;
        public ClientConsole()
        {

        }


        /*
        -------------------------------------Print Methods----------------------------------------
        */

        public void GenericPrint(string text)
        {
            Console.WriteLine(text);
        }

        public void PrintInit()
        {
            maxMenuOptions = 2;
            Console.WriteLine("1. Store");
            Console.WriteLine("2. Customer");
        }

        private void PrintInvalid()
        {
            Console.WriteLine("Invalid input. Please put proper integer.");
        }

        public void PrintStore(List<AStore> stores)
        {
            PrintLine();
            for(int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("#{0}: {1}", i+1, stores[i]);
            }
        }

        public void PrintPizzaOptions(AStore curStore)
        {
            PrintLine();
            for(int i = 0; i < curStore.PresetPizza.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, curStore.PresetPizza[i]);
            }

            Console.WriteLine("{0}: Custom Pizza", curStore.PresetPizza.Count + 1);
        }

        public void PrintPizzaOptionsNoSize(AStore curStore)
        {
            PrintLine();
            for(int i = 0; i < curStore.PresetPizza.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, curStore.PresetPizza[i].PrintNoSize(true));
            }

            Console.WriteLine("{0}: Custom Pizza", curStore.PresetPizza.Count + 1);
        }

        private void PrintLine()
        {
            Console.WriteLine("------------------------------------------------------");
        }

        public void PrintMenu()
        {
            maxMenuOptions = 3;
            PrintLine();
            Console.WriteLine("1. View Order History");
            Console.WriteLine("2. Start New Order");
            Console.WriteLine("3. Exit");
        }

        public void PrintOrderOptions()
        {
            maxMenuOptions = 4;
            PrintLine();
            Console.WriteLine("1. View Current Order");
            Console.WriteLine("2. Add Another Pizza");
            Console.WriteLine("3. Delete Pizza From Order");
            Console.WriteLine("4. Finish Order");
        }

        public void PrintCurrentOrder(Order currentOrder)
        {
            maxMenuOptions = currentOrder.Pizzas.Count;
            PrintLine();
            Console.WriteLine("Name: " + currentOrder.Name + " - " + currentOrder.StoreName + " - " + currentOrder.OrderTime);
            for(int i = 0; i < currentOrder.Pizzas.Count; i++)
            {
                Console.WriteLine("{0} : {1}", i + 1, currentOrder.Pizzas[i]);
            }
            Console.WriteLine("Total: " + currentOrder.CurTotal);
        }

        public void PrintCompInfo(List<APizzaComponent> comp)
        {
            maxMenuOptions = comp.Count;
            PrintLine();
            for(int i = 0; i < comp.Count; i++)
            {
                Console.WriteLine("{0} : {1} - {2}", i + 1, comp[i].Name, comp[i].Price);
            }
        }

        public void PrintSizes(AStore store)
        {
            maxMenuOptions = store.SizeList.Count;
            PrintLine();
            for(int i = 0; i < store.SizeList.Count; i++)
            {
                Console.WriteLine("{0} : {1} - {2}", i + 1, store.SizeList[i].Name, store.SizeList[i].Price);
            }
        }

        public void PrintCrusts(AStore store)
        {
            maxMenuOptions = store.CrustList.Count;
            PrintLine();
            for(int i = 0; i < store.CrustList.Count; i++)
            {
                Console.WriteLine("{0} : {1} - {2}", i + 1, store.CrustList[i].Name, store.CrustList[i].Price);
            }
        }

        public void PrintToppings(AStore store)
        {
            maxMenuOptions = store.ToppingsList.Count + 1;
            PrintLine();
            for(int i = 0; i < store.ToppingsList.Count; i++)
            {
                Console.WriteLine("{0} : {1} - {2}", i + 1, store.ToppingsList[i].Name, store.ToppingsList[i].Price);
            }
            Console.WriteLine("{0} : Finish", store.ToppingsList.Count + 1);
        }

        public void PrintStoreOptions()
        {
            maxMenuOptions = 2;
            PrintLine();
            Console.WriteLine("1. View all orders");
            Console.WriteLine("2. View Sales");
        }

        public void PrintCustomersList(List<Customer> customers)
        {
            maxMenuOptions = customers.Count + 1;
            PrintLine();
            for(int i = 0; i < customers.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, customers[i].Name);
            }
            Console.WriteLine("{0}: New Customer", customers.Count + 1);
        }

        public void PrintStoreSales(AStore store)
        {
            //Console.WriteLine("----------------------");
            PrintLine();
            PrintStoreSalesDay(store, 7);
            Console.WriteLine("----------------------");
            PrintStoreSalesDay(store, 30);
            Console.WriteLine("----------------------");
            PrintStoreSalesDay(store, 90);
            Console.WriteLine("----------------------");
            PrintStoreTotalSales(store);
        }

        private void PrintStoreSalesDay(AStore store, int days)
        {
            Console.WriteLine("Last {0} days: ", days);
            Dictionary<string, int> count = store.GetPizzaCount(days);
            foreach(KeyValuePair<string, int> kvp in count)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("Last {0} days sales: " + store.GetTotalSales(days), days);
        }

        private void PrintStoreTotalSales(AStore store)
        {
            Console.WriteLine("Alltime: ");
            Dictionary<string, int> count = store.GetTotalPizzaCount();
            foreach(KeyValuePair<string, int> kvp in count)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("Total all time sales: " + store.GetTotalSales());
        }

        public void PrintStoreOrderOptions()
        {
            maxMenuOptions = 2;
            PrintLine();
            Console.WriteLine("1. View all store orders");
            Console.WriteLine("2. Search order by name");
        }


        /*
        -------------------------------------Chooose Methods----------------------------------------
        */
        public AStore ChooseStore(List<AStore> stores)
        {
            PrintStore(stores);
            Console.Write("Enter # for your store: ");
            GetValidInput(1, stores.Count);
            return stores[userIntInput - 1];
        }

        public void ChoosePizza(AStore store)
        {
            PrintPizzaOptions(store);
        }

        public int ChooseMenu()
        {
            Console.Write("Enter # for menu options: ");
            GetValidInput(1, maxMenuOptions);
            return userIntInput;
        }

        public string GetString(string output)
        {
            Console.Write(output);
            return Console.ReadLine();
        }

        /*
        -------------------------------------Input and Validation Methods----------------------------------------
        */
        private void GetValidInput(int min, int max)
        {
            GetUserInput();
            validIntCheck(min, max);
        }

        private void GetUserInput()
        {
            userInput = Console.ReadLine();
        }

        private void stringToIntCheck()
        {
            bool isInteger = false;
            do
            {
                if(int.TryParse(userInput, out userIntInput))
                {
                    isInteger = true;
                }
                else
                {
                    PrintInvalid();
                    GetUserInput();
                }
            }while(!isInteger);
        }

        private void validIntCheck(int minPos, int maxPos)
        {
            bool validInteger = false;
            do
            {
                stringToIntCheck();
                if(userIntInput > maxPos || userIntInput < minPos)
                {
                    PrintInvalid();
                    GetUserInput();
                }
                else
                {
                    validInteger = true;
                }
            }while(!validInteger);
        }
    }
}