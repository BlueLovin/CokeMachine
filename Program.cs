using System;
using System.Data;
using CokeMachine;

namespace CokeMachine
{
    class Program
    {
        public static float userBalance, selectionPrice;
        public static string selectionID;
        static void Main(string[] args)
        {
            mainMenu(0f);
        }
        static void mainMenu(float balance)
        {
            DateTime date = DateTime.Now;
            Console.Clear();

            Console.WriteLine("Welcome to the Coke Machine.");
            Console.WriteLine("The date is: {0: MM/dd/yyyy HH:mm:ss}.", date);
            colorGreen();
            Console.WriteLine("\nYour current balance: ${0:F2}", balance);
            colorWhite();

            Console.WriteLine("\nHere are your options:");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[1]Coca-Cola - ${0:F2}", soda.cokePrice);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[2]Diet Coke - ${0:F2}", soda.dietCokePrice);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[3]Dr. Pepper - ${0:F2}", soda.drPepperPrice);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[4]Sprite - ${0:F2}", soda.spritePrice);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[5]Dasani Water - ${0:F2}", soda.dasaniPrice);
            bool okay = false;

            while (okay == false)
            {
                colorWhite();
                Console.WriteLine();
                Console.WriteLine("What will your selection be?");
                string selectionStr = Console.ReadLine();
                int selectionInt;
                if (int.TryParse(selectionStr, out selectionInt) && selectionInt < 6 && selectionInt > 0) // if value entered is acceptable
                {
                    insertCash(selectionInt, balance);
                    okay = true;
                }
                else
                    Console.WriteLine("Invalid selection! Try again.");
            }
        }
        public static void insertCash(int selection, float balance)
        {
            //
            //Setting values according to the selection that was passed to this method.
            //
            if (selection == 1)
            {
                selectionID = "Coca-Cola";
                selectionPrice = soda.cokePrice;
            }

            if (selection == 2)
            {
                selectionID = "Diet Coke";
                selectionPrice = soda.dietCokePrice;
            }

            if (selection == 3)
            {
                selectionID = "Dr. Pepper";
                selectionPrice = soda.drPepperPrice;
            }

            if (selection == 4)
            {
                selectionID = "Sprite";
                selectionPrice = soda.spritePrice;
            }

            if (selection == 5)
            { 
                selectionID = "Dasani";
                selectionPrice = soda.dasaniPrice;
            }
            ///
            ///
            ///
                if (selectionPrice > balance)
                {
                    Console.WriteLine("You chose {0}. Current balance: ${1:F2}" +
                        "\nPlease insert $" + (selectionPrice - balance), selectionID, balance);
                }
                if (balance >= selectionPrice)
                {
                    Console.WriteLine("Thank you. Enjoy your {0}", selectionID);
                    balance -= selectionPrice;
                    giveChange(balance);
                }
            try
            {
                do
                {
                    Console.Write("$");
                    balance += float.Parse(Console.ReadLine());
                    Console.WriteLine("Current Balance: ${0:F2}", (balance - selectionPrice).ToString("#.##"));
                } while (balance < selectionPrice);
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
                insertCash(selection, balance);
            }
                if (balance >= selectionPrice)
                {
                    float balanceLocal = balance - selectionPrice;
                    giveChange(balanceLocal);
                }
        }
        static void giveChange(float change)
        {
            Console.WriteLine("Would you like to buy another drink? [Y\\N]");
            string input = Console.ReadLine();
            if (input == "y")
                mainMenu(change);
            if (input == "n")
            {
                Console.WriteLine("Thanks. Your change is ${0}. Enjoy your {1:F2}", change, selectionID);
                //Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid input.");
                giveChange(change);
            }
            Console.ReadKey();
            Environment.Exit(0); // EXITS AT THE END OF giveChange FUNCTION

        }


        /// <summary>
        /// COLORS!!!
        /// </summary>
        static void colorWhite()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void colorGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void colorRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}