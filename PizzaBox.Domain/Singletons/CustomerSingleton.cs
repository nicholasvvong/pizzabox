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
        public List<Customer> Customers { get; set; }
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
            var fs = new FileStorage(@"customer.xml");
            
            //SeedCustomers();

            if(Customers == null)
            {
                Customers = fs.ReadFromXml<Customer>().ToList();
            }
        }

        public void UpdateCustomers()
        {
            var fs = new FileStorage(@"customer.xml");
            fs.WriteToXml<Customer>(Customers);
        }

        private void SeedCustomers()
        {
            var fs = new FileStorage(@"customer.xml");
            Customers = new List<Customer>();

            Customers.Add(new Customer("Nick"));
            Customers.Add(new Customer("Chris"));
            Customers.Add(new Customer("Bob"));
            Customers.Add(new Customer("Bill"));

            fs.WriteToXml<Customer>(Customers);
        }
    }
}