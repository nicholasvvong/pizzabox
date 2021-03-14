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
            console.PrintStoreOrderOptions();
            int userMenuChoice = console.ChooseMenu();

            switch(userMenuChoice)
            {
                case 1:
                    PrintAllOrders(console);
                    break;
                case 2:
                    PrintUserOrders(console);
                    break;
                default:
                    break;
            }
            
        }

        private void PrintAllOrders(ClientConsole console)
        {
            for(int i = 0; i < curStore.Orders.Count; i++)
            {
                console.PrintCurrentOrder(curStore.Orders[i]);
            }
        }

        private void PrintUserOrders(ClientConsole console)
        {
            bool foundOne = false;
            string userName = console.GetString("Enter name to search: ");
            for(int i = 0; i < curStore.Orders.Count; i++)
            {
                if(curStore.Orders[i].Name == userName)
                {
                    console.PrintCurrentOrder(curStore.Orders[i]);
                    foundOne = true;
                }
            }

            if(!foundOne)
            {
                console.GenericPrint("Could not find any orders placed by " + userName);
            }
        }
        
        private void PrintSales(ClientConsole console)
        {
            console.PrintStoreSales(curStore);
        }
    }
}