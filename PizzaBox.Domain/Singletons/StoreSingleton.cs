using System.Collections.Generic;
using System.Linq;
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
            var fs = new FileStorage(@"store.xml");
            
            //SeedStores();
            
            if(Stores == null)
            {
                Stores = fs.ReadFromXml<AStore>().ToList();
            }
            
        }

        public void UpdateStores()
        {
            var fs = new FileStorage(@"store.xml");
            fs.WriteToXml<AStore>(Stores);
        }
        
        private void SeedStores()
        {
            var fs = new FileStorage(@"store.xml");
            Stores = new List<AStore>();

            Stores.Add(new CaliforniaStore());
            Stores.Add(new ChicagoStore());
            Stores.Add(new FreddyStore());
            Stores.Add(new NewYorkStore());

            fs.WriteToXml<AStore>(Stores);
        }
    }
}