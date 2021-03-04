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
            var storeSingleton = new StoreSingleton();

            foreach(var s in storeSingleton.Stores)
            {
                Console.WriteLine(s);
            }
        }
    }
}
