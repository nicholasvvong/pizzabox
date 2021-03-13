using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
    public class StoreFront
    {
        AStore curStore;
        
        public StoreFront()
        {
            
        }

        public void Start(ClientConsole console)
        {
            curStore = console.ChooseStore(StoreSingleton.Instance.Stores);
            Action(console);

        }

        private void Action(ClientConsole console)
        {
            console.PrintStoreOptions();
            int userMenuChoice = console.ChooseMenu();

            switch(userMenuChoice)
            {
                case 1:
                    PrintOrders(console);
                    break;
                case 2:
                    PrintSales(console);
                    break;
                default:
                    break;
            }
        }

        private void PrintOrders(ClientConsole console)
        {
            for(int i = 0; i < curStore.Orders.Count; i++)
            {
                 console.PrintCurrentOrder(curStore.Orders[i]);
             }
        }
        
        private void PrintSales(ClientConsole console)
        {
            console.PrintStoreSales(curStore);
        }
    }
}