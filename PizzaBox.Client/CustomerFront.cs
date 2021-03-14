using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singletons;

namespace PizzaBox.Client
{
    public class CustomerFront
    {
        Customer curCust;
        
        public CustomerFront()
        {
            
        }

        public void Start(ClientConsole console)
        {
            console.PrintCustomersList(CustomerSingleton.Instance.Customers);
            int userMenuChoice = console.ChooseMenu();
            bool validUser = false;

            if(userMenuChoice > CustomerSingleton.Instance.Customers.Count)
            {
                curCust = new Customer(console.GetString("Enter name: "));
                CustomerSingleton.Instance.Customers.Add(curCust);
                validUser = true;
            }
            else
            {
                curCust = CustomerSingleton.Instance.Customers[userMenuChoice - 1];
                if(curCust.PasswordCheck(console.GetString("Enter password: ")))
                {
                    validUser = true;
                }
            }

            if(validUser)
            {
                Action(console);
            }
            else
            {
                console.GenericPrint("Invalid password.");
            }
        }

        private void Action(ClientConsole console)
        {
            int userMenuChoice = 0;

            do
            {
                console.PrintMenu();
                userMenuChoice = console.ChooseMenu();
                switch(userMenuChoice)
                {
                    case 1:
                        PrintOrderHistory(console);
                        break;
                    case 2:
                        StartOrder(console);
                        userMenuChoice = 3;
                        break;
                    case 3:
                        break;
                    default:
                        userMenuChoice = 3;
                        break;
                }
            }while(userMenuChoice != 3);
        }

        private void PrintOrderHistory(ClientConsole console)
        {
            for(int i = 0; i < curCust.OrderHistory.Count; i++)
            {
                console.PrintCurrentOrder(curCust.OrderHistory[i]);
            }
        }

        private void StartOrder(ClientConsole console)
        {
            AStore clientStore = console.ChooseStore(StoreSingleton.Instance.Stores);
            int userMenuChoice = 0;

            if(curCust.StartOrderCheck(clientStore))
            {
                Order currentOrder = new Order(curCust, clientStore);
                do
                {
                    console.PrintOrderOptions();
                    userMenuChoice = console.ChooseMenu();
                    switch(userMenuChoice)
                    {

                        case 1:
                            console.PrintCurrentOrder(currentOrder);
                            break; 
                        case 2:
                            console.PrintPizzaOptionsNoSize(clientStore);
                            userMenuChoice = console.ChooseMenu();
                            DoPizzaOption(console, userMenuChoice, clientStore, currentOrder);
                            break;
                        case 3:
                            DeletePizza(console, currentOrder);
                            break;
                        case 4:
                            FinishOrder(console, curCust, clientStore, currentOrder);
                            break;
                        default:
                            userMenuChoice = 4;
                            break;
                    }
                }while(userMenuChoice != 4);
            }
        }

        private void DoPizzaOption(ClientConsole client, int menuChoice, AStore store, Order o)
        {
            if(menuChoice != store.PresetPizza.Count + 1) //Preset option
            {
                o.StartPresetPizza(store.PresetPizza[menuChoice - 1]);
                client.PrintSizes(store);
                int sizeChoice = client.ChooseMenu();
                o.CurrentPizza.AddSize(store.SizeList[sizeChoice - 1]);
                o.FinishPizza();
            }
            else
            {
                o.StartCustomPizza();
                o.CurrentPizza.AddDefaults();
                client.PrintSizes(store);
                //client.PrintCompInfo(store.SizeList);
                o.CurrentPizza.AddSize(store.SizeList[client.ChooseMenu() - 1]);
                client.PrintCrusts(store);
                o.CurrentPizza.AddCrust(store.CrustList[client.ChooseMenu() - 1]);
                
                do
                {
                    client.PrintToppings(store);
                    menuChoice = client.ChooseMenu();
                    if(menuChoice > store.ToppingsList.Count || o.CurrentPizza.Toppings.Count >= o.CurrentPizza.MaxToppings)
                    { 
                        break;
                    }
                    else
                    {
                        o.CurrentPizza.AddTopping(store.ToppingsList[menuChoice - 1]);
                    }

                }while(menuChoice <= store.ToppingsList.Count);

                o.FinishPizza();
            }
        }
        private void FinishOrder(ClientConsole client, Customer c, AStore store, Order o)
        {
            store.AddOrder(o);
            c.AddToOrderHistory(o);
            
            StoreSingleton.Instance.UpdateStores();
            CustomerSingleton.Instance.UpdateCustomers();
        }

        private void DeletePizza(ClientConsole client, Order o)
        {
            client.PrintCurrentOrder(o);
            int userChoice = client.ChooseMenu();
            o.DeletePizza(userChoice - 1);
        }   
    }
}