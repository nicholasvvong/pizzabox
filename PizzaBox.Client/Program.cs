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

            clientStore = client.ChooseStore(StoreSingleton.Instance.Stores);
            Console.WriteLine(clientStore);

            Customer cust = new Customer();
            cust.StartOrderCheck(clientStore);
        }
    }
}
