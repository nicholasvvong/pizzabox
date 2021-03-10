using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Client
{
    public class ClientConsole
    {
        string userInput = "";
        int userIntInput = 0;
        public ClientConsole()
        {

        }

        private void PrintInvalid()
        {
            Console.WriteLine("Invalid input. Please put proper integer.");
        }

        public void PrintStore(List<AStore> stores)
        {
            for(int i = 0; i < stores.Count; i++)
            {
                Console.WriteLine("#{0}: {1}", i+1, stores[i]);
            }
        }

        public void PrintPizzaOptions(AStore curStore)
        {
            foreach(APizza p in curStore.PresetPizza)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("{0}: Custom Pizza", curStore.PresetPizza.Count + 1);
        }

        public void PrintMenu(AStore curStore)
        {

        }

        public AStore ChooseStore(List<AStore> stores)
        {
            PrintStore(stores);
            Console.Write("Enter # for your store: ");
            GetValidInput(1, stores.Count);
            return stores[userIntInput - 1];
        }

        public void ChoosePizza(AStore store)
        {
            PrintPizzaOptions(store);
        }

        private void GetValidInput(int min, int max)
        {
            GetUserInput();
            validIntCheck(min, max);
        }

        private void GetUserInput()
        {
            userInput = Console.ReadLine();
        }

        private void stringToIntCheck()
        {
            bool isInteger = false;
            do
            {
                if(int.TryParse(userInput, out userIntInput))
                {
                    isInteger = true;
                }
                else
                {
                    PrintInvalid();
                    GetUserInput();
                }
            }while(!isInteger);
        }

        private void validIntCheck(int minPos, int maxPos)
        {
            bool validInteger = false;
            do
            {
                stringToIntCheck();
                if(userIntInput > maxPos || userIntInput < minPos)
                {
                    PrintInvalid();
                    GetUserInput();
                }
                else
                {
                    validInteger = true;
                }
            }while(!validInteger);
        }
    }
}