using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpPlayground
{
    class User
    {
        public static decimal CurrentDrinkPrice { get; set; }
        public static decimal Balance { get; set; }
        public static List<string> Inventory = new List<String>(); //inventory
    }
    class Sodas
    {
        public static decimal selectionPrice { get; set; }
        public IDictionary<int, string> DrinkList 
            = new Dictionary<int, string>()
        {
            {0,"Coca-Cola" },
            {1, "Sprite" },
            {2, "Mtn. Dew" },
            {3, "Dr. Pepper" }
        };
        public IDictionary<int, decimal> DrinkPrices 
            = new Dictionary<int, decimal>()
        {
            {0, 1.25m },//coke
            {1, 1.50m },//sprite
            {2, 2.00m },//mtn dew
            {3, 0.75m }//dr pepper
        };
    }
    class vendingMachine
    {
        /// <summary>
        /// greets user and prints all items in the Drink Dictionary
        /// prices as well
        /// </summary>
        public static void printHomeScreen()
        {
            var sodas = new Sodas();
            var user = new User();

            Console.WriteLine("Welcome to the Coke Machine.\nYour balance is: $"
                + User.Balance + "\n");

            if (User.Inventory.Count > 0)
            {
                Console.Write("Items that you have bought: ");
                foreach (string item in User.Inventory)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nPlease choose from the following:");

            //print all drinks in list
            for (int i = 0; i < sodas.DrinkList.Count; i++) 
            {
                Console.WriteLine("[{0}] " + sodas.DrinkList[i] +
                    " - ${1}", i, sodas.DrinkPrices[i]);
            }
        }

        public int Selection()
        {
            int selection;
            var sodas = new Sodas();
            
            while (true)
            {
                Console.Write("\nYour selection: ");
                string userInput = Console.ReadLine();
                int inputInt;
                if (int.TryParse(userInput, out inputInt)
                    && int.Parse(userInput) >= 0
                    && int.Parse(userInput) < 4)//checks if input is valid
                {
                    selection = inputInt;
                    break;
                }
                else
                {
                    Console.WriteLine("Try Again.... Fucking douche.");
                    continue;
                }
            }
            User.CurrentDrinkPrice = sodas.DrinkPrices[selection];
            Sodas.selectionPrice = sodas.DrinkPrices[selection];
            return selection;
        }
                
        public static void insertCash(int selection, decimal drinkPrice, decimal userBalance)
        {
            var sodas = new Sodas();
            var vendingmachine = new vendingMachine();
            //SETS PUBLIC PRICE VARIABLE
            decimal selectionPrice = sodas.DrinkPrices[selection];
            Console.WriteLine("\nYour selection was {0}",
                sodas.DrinkList[selection]);
            Console.WriteLine("Your current balance is ${0}",
                User.Balance);

            String drinkSelectionStr =
                sodas.DrinkList[selection];
            decimal inputDecimal;
            if (User.Balance >= selectionPrice)
            {
                cashFlow(selection);
            }
            while (true) //loop checks if input is valid
            {
                Console.WriteLine("Please insert ${0}",
                    (sodas.DrinkPrices[selection] - User.Balance));
                Console.Write("\n$");
                string inputString = Console.ReadLine();
                if (decimal.TryParse(inputString, out inputDecimal))
                    break;
                else
                {
                    Console.WriteLine("Try again dickhead");
                    continue;
                }
            }
            User.Balance += inputDecimal;
            cashFlow(selection);
        }

        public static void cashFlow(int drinkSelectionInt)
        {
            var user = new User();
            var sodas = new Sodas();
            var vendingmachine = new vendingMachine();
            decimal drinkPrice = Sodas.selectionPrice;
            decimal balance = User.Balance;
            Console.Clear();
            if (balance < drinkPrice) // ask for more cash!
            {
                insertCash(drinkSelectionInt, drinkPrice, User.Balance);
            }

            if (balance > drinkPrice) // give change
            {
                User.Balance -= drinkPrice;
                decimal change = (balance - drinkPrice);
                Console.WriteLine("Your change is ${0}." +
                    "\nEnjoy your {1}", change, sodas.DrinkList[drinkSelectionInt]);
                //back to main
            }

            if (balance == drinkPrice)
            {
                User.Balance -= drinkPrice;
                Console.WriteLine("\nEnjoy your {0}",
                    sodas.DrinkList[drinkSelectionInt]);
                //back to main
            }
            User.Inventory.Add(sodas.DrinkList[drinkSelectionInt]);//appends newly bought soda to user inventory
            //exit to main function
        }
    }
}

