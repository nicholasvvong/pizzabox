using System;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayWithStore();
        }

        public static void PlayWithStore()
        {
            //var storeSingleton = StoreSingleton.Instance;

            foreach(var s in StoreSingleton.Instance.Stores)
            {
                Console.WriteLine(s);
            }
        }
    }
}
