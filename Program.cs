namespace Tut3
{
    internal class Program
    {
        private static bool isShop = true;
        private static string shopName = "Ubisoft";
        private static string playerInput;
        //private static string[] gamesAvailable = new string[] { "GTA", "Assasins Creed" };
        private static int price = 50;
        private static List<string> shopItems = new List<string>();
        private static List<string> playerInventory = new List<string>();

        static void Main(string[] args)
        {
            fillShop();
            Store();
        }
        private static void fillShop()
        {
            shopItems.Add("Helmet");
            shopItems.Add("Chestplate");
            shopItems.Add("Leggings");
            shopItems.Add("Boots");
            shopItems.Add("Sword");
            shopItems.Add("Shield");
        }
        private static void Store()
        {
            Console.WriteLine($"Hello and welcome to {shopName}");

            while (isShop)
            {
                playerInput = Console.ReadLine();
                playerInput = playerInput.ToLower();
                if (playerInput == null || playerInput.Equals(""))
                {
                    Console.WriteLine("Please enter text!");
                }
                else if (playerInput.Equals("hi") || playerInput.Equals("hello"))
                {
                    Console.WriteLine($"Hello there! Welcome to {shopName}! Please input the item you're looking for!");
                }
                else if (playerInput.Contains("do you have") || playerInput.Contains("is the item") || playerInput.Contains("item"))
                {
                    if (CheckAvailability(playerInput))//means the game is available
                    {
                        Console.WriteLine($"Yes, this item is available! The cost is {price.ToString()}!\nAlso there are this items available!");
                        
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately this item is not available at the time, check back later!\nBut there are this items available!");
                    }
                    printList(shopItems);
                }
                else if (playerInput.Contains("1") || playerInput.Contains("2") || playerInput.Contains("2") || playerInput.Contains("3") || playerInput.Contains("4") || playerInput.Contains("5") || playerInput.Contains("6") || playerInput.Contains("7") || playerInput.Contains("8")|| playerInput.Contains("9"))
                {
                    buyItemByNumber(returnOnlyInt(playerInput));
                }
                else if(playerInput.Contains("buy")|| playerInput.Contains("purchase"))
                {
                    Console.WriteLine($"Please type the number from the item you wan to buy! The cost is {price.ToString()}!");
                }
                else if (playerInput.Contains("show") || playerInput.Contains("what") || playerInput.Contains("available"))
                {
                    printList(shopItems);
                }
                else if (playerInput.Contains("inventory") || playerInput.Contains("my") || playerInput.Contains("player") || playerInput.Contains("list"))
                {
                    Console.WriteLine("The player currently has:");
                    printList(playerInventory);
                }
                else if (playerInput.Contains("exit") || playerInput.Contains("leave") || playerInput.Contains("bye"))
                {
                    Console.WriteLine("Come back later!");
                    System.Threading.Thread.Sleep(3000);
                    isShop = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid command!");
                }
            }

        }
        private static bool CheckAvailability(string item)
        {

            foreach(string tempString in shopItems)
            {
                if (item.Contains(tempString,StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        private static int returnOnlyInt(string temp)
        {
            string final = "";
            foreach(char c in temp)
            {
                if(c =='1'|| c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    final += c;
                }
            }
            return int.Parse(final);
        }
        private static void buyItemByNumber(int numberToBuy)
        {
            Console.WriteLine("You have bought " + shopItems[numberToBuy]);
            playerInventory.Add(shopItems[numberToBuy]);
            shopItems.Remove(shopItems[numberToBuy]);
        }
        private static void printList(List<string> toPrint)
        {
            int i = 0;
            foreach (string tempString in toPrint)
            {
                Console.WriteLine(i+" "+tempString);
                i++;
            }
        }
    }
}