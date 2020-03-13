﻿using System;
using System.Data;
using CokeMachine;

namespace CokeMachine
{
    class CokeMachine2
    {
        public static float userBalance, selectionPrice;
        public static string selectionID;
        public static void mainMenu(float balance)
        {

            coke Coke = new coke();
            dietCoke dietCoke = new dietCoke();
            sprite Sprite = new sprite();
            drPepper DrPepper = new drPepper();
            dasani Dasani = new dasani();
            DateTime date = DateTime.Now;

            Console.WriteLine("Welcome to the Coke Machine.");
            Console.WriteLine("The date is: {0: MM/dd/yyyy HH:mm:ss}.", date);

            colorWhite();
            Console.WriteLine("\nHere are your options:");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[1]Coca-Cola - ${0}", coke.price);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[2]Diet Coke - ${0}", dietCoke.price);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[3]Dr. Pepper - ${0}", drPepper.price);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[4]Sprite - ${0}", sprite.price);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[5]Dasani Water - ${0}", dasani.price);
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
                selectionPrice = coke.price;
            }

            if (selection == 2)
            {
                selectionID = "Diet Coke";
                selectionPrice = dietCoke.price;
            }

            if (selection == 3)
            {
                selectionID = "Dr. Pepper";
                selectionPrice = drPepper.price;
            }

            if (selection == 4)
            {
                selectionID = "Sprite";
                selectionPrice = sprite.price;
            }

            if (selection == 5)
            { 
                selectionID = "Dasani";
                selectionPrice = dasani.price;
            }
            Console.WriteLine("You chose {0}. Current balance: {1}" +
                "\nPlease insert $" +  (selectionPrice - balance), selectionID, balance);
            while (balance < selectionPrice)
            {
                balance += float.Parse(Console.ReadLine());
                Console.WriteLine("Current Balance: " + (balance - selectionPrice));
            }

            if(balance > selectionPrice)
            {
                float balanceLocal = userBalance - selectionPrice;
                giveChange(balanceLocal);
            }
        }
        static void giveChange(float change)
        {
            Console.WriteLine("Would you like to buy another drink?");
            bool yesOrNo;
            string input = Console.ReadLine();
            if (input == "y")
                mainMenu(change);
            if (input == "n")
                Console.WriteLine("Thanks. Your change is {0}. Enjoy your {1}", change, selectionID);
            else
            {
                Console.WriteLine("Invalid input.");
                giveChange(change);
            }

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