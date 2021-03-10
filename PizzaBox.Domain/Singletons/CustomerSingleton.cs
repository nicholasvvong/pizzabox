using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Domain.Singletons
{
    public class CustomerSingleton
    {
        private static CustomerSingleton _customerSingletone;
        public List<AStore> Stores { get; set; }
        public static CustomerSingleton Instance
        {
            get
            {
                if(_customerSingletone == null)
                {
                    _customerSingletone = new CustomerSingleton();
                }

                return _customerSingletone;
            }
        }

        private CustomerSingleton()
        {
            var fs = new FileStorage();
            
            if(Stores == null)
            {
                Stores = fs.ReadFromXml<AStore>().ToList();
            }
        }

        private void SeedStores()
        {
            var fs = new FileStorage();
            Stores = new List<AStore>();

            Stores.Add(new CaliforniaStore());
            Stores.Add(new ChicagoStore());
            Stores.Add(new FreddyStore());
            Stores.Add(new NewYorkStore());

            fs.WriteToXml<AStore>(Stores);
        }
    }
}