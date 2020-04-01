using System; 

namespace CSharpPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new vendingMachine();
            var sodas = new Sodas();
            var user = new User();

            while (true)
            {
                Console.Clear();
                vendingMachine.printHomeScreen();

                int selection = vendingMachine.Selection();
                if (User.Balance >= User.CurrentDrinkPrice)
                {
                    vendingMachine.cashFlow(selection);
                }
                else
                {
                    vendingMachine.insertCash(selection,
                        sodas.DrinkPrices[selection],
                        User.Balance);
                }

                Console.WriteLine("Would you like to buy another drink? [y/n]");

                string input = Console.ReadLine();
                if (input.ToLower() == "y" || input.ToLower() == "y ")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
