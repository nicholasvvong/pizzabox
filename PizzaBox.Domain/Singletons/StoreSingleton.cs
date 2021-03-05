using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Domain.Singletons
{
    public class StoreSingleton
    {
        private static StoreSingleton _storeSingleton;
        public List<AStore> Stores { get; set; }
        public static StoreSingleton Instance
        {
            get
            {
                if(_storeSingleton == null)
                {
                    _storeSingleton = new StoreSingleton();
                }

                return _storeSingleton;
            }
        }

        private StoreSingleton()
        {
            var fs = new FileStorage();

            if(Stores == null)
            {
                Stores = fs.ReadFromXml<AStore>() as List<AStore>;
            }
        }
    }
}