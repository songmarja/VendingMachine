using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class Vending : IVending
    {

        // List of the different values of money that is ok to insert in machine
        public Money[] moneys;
        // All products available in one list
        public List<Product> products;
        //Dictionary for showing the change properly to valid denominations for end user
        public Dictionary<string, int> getChange = new Dictionary<string, int>();

        public Vending()
        {
            moneys = GetDenominations();
            products = GetAllProducts();
        }
       
        //************************     Start method that runs the app and manage the user communication. RUN **********************************
        internal void Run()
        {
            Console.Clear();
            PrintHeader();
            int menuChoice;
            // Keep track of money left in vending machine
            int totalAmount = 0;
            bool run = true;
             
            while (run)
            {
                ConsolePositioning(65, 7, "Main Menu");
                ConsolePositioning(65, 8, "1. Insert money.");
                ConsolePositioning(65, 9, "2. Display all products.");
                ConsolePositioning(65, 10, "3. Purchase.");
                ConsolePositioning(65, 11, "4. End Transaction.");
                ConsolePositioning(65, 12, "5. Quit.");

                ConsolePositioning(85, 5, "Your balance: ");
                ConsolePositioning(100, 5, totalAmount.ToString());
                ConsolePositioning(65, 14, "Choose what to do: ");
               
                //Console.WriteLine();
                //Console.WriteLine("\t\tMain Menu");
                //Console.WriteLine("\t\t1. Insert money.");
                //Console.WriteLine("\t\t2. Display all products. ");
                //Console.WriteLine("\t\t3. Purchase.");
                //Console.WriteLine("\t\t4. End Transaction.");
                //Console.WriteLine("\t\t5. Quit.");

                //Console.Write("\tChoose what to do: ");

                while (!int.TryParse(Console.ReadLine(), out menuChoice) || menuChoice > 5 || menuChoice < 1)
                {
                    //Console.WriteLine("\nInvalid number. Try again!"); HS
                    ConsolePositioning(65, 14, "Invalid number. Try again : ");
                }

                switch (menuChoice)
                {
                    case 1:
                        totalAmount = InsertMoney( moneys,totalAmount);
                        break;
                    case 2:
                        ShowAll();
                        break;
                    case 3:
                        totalAmount = Purchase(totalAmount);
                        break;
                    case 4:
                        totalAmount = EndTransaction(totalAmount);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        // ***********************************************************    End of Run method           *************************************************************


        private string CheckValidYOrN(string? input)
        {
            bool notValid = true;
            while (notValid)
            {
                if (String.IsNullOrEmpty(input) || (input != "n" && input != "y"))
                {
                    ClearPartOfConsole(6, 21, 45, 21);
                    ConsolePositioning(6, 21, "Please enter: y (Yes) / n (No): ");
                    //Console.Write("Please enter: y (Yes) / n (No): \n ");
                    input = Console.ReadLine();
                }
                else
                {
                    notValid = false;
                }
            }
              return input;
        }

        /// <summary>
        /// Used to delete fields used for text messages before
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        private void ClearPartOfConsole(int x1, int y1, int x2, int y2)
        {
            for (int i = y1; i <= y2; i++)
            {
                Console.SetCursorPosition(x1, i);
                for (int j = x1; j <= x2; j++)
                {
                    Console.Write(" ");
                }
            }
        }


        /// <summary>
        /// Positioning messages for end user 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="textMessage"></param>
        private void ConsolePositioning(int x, int y, string textMessage)
        {
            int consoleWidth = 120;
            Console.SetCursorPosition(x, y);

            string blanks = "                                             "; // 45 characters, used to clean most old texta

            if (x + blanks.Length <= consoleWidth)
            {
                Console.Write(blanks);
            }
            else // 45 characters are too many
            {
                blanks = "";
                for (int i = 0; i < 120 - x; i++)
                {
                    blanks += " ";
                }
                Console.Write(blanks);
            }
            
            Console.SetCursorPosition(x, y);
            Console.Write(textMessage);
        }


        /// <summary>
        /// Summarize what customer has left in balance, and shows which denominations and how many in change
        /// </summary>
        /// <param name="totalLeft"></param>
        /// <returns></returns>
        public  int EndTransaction(int totalLeft)
        {
            int thousandCrowns = 0;
            int fiveHundredCrowns = 0;
            int hundredCrowns = 0;
            int fiftyCrowns = 0;
            int twentyCrowns = 0;
            int tenCrowns = 0;
            int fiveCrowns = 0;
            int oneCrown = 0;

            if (totalLeft == 0)
            {
                ClearPartOfConsole(6, 25, 80, 25);
               ConsolePositioning(65,25,"Your balance is 0.");
            }
            else
            {
                while (totalLeft > 0)
                {
                    if (totalLeft >= 1000)
                    {
                        thousandCrowns++;
                        totalLeft -= 1000;
                    }
                    else
                    {
                        if (totalLeft >= 500)
                        {
                            fiveHundredCrowns++;
                            totalLeft -= 500;
                        }
                        else
                        {
                            if (totalLeft >= 100)
                            {
                                hundredCrowns++;
                                totalLeft -= 100;
                            }
                            else
                            {
                                if (totalLeft >= 50)
                                {
                                    fiftyCrowns++;
                                    totalLeft -= 50;
                                }
                                else
                                {
                                    if (totalLeft >= 20)
                                    {
                                        twentyCrowns++;
                                        totalLeft -= 20;
                                    }
                                    else
                                    {
                                        if (totalLeft >= 10)
                                        {
                                            tenCrowns++;
                                            totalLeft -= 10;
                                        }
                                        else
                                        {
                                            if (totalLeft >= 5)
                                            {
                                                fiveCrowns++;
                                                totalLeft -= 5;
                                            }
                                            else
                                            {
                                                if (totalLeft >= 1)
                                                {
                                                    oneCrown++;
                                                    totalLeft -= 1;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Empty");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                getChange.Add("thousand bills", thousandCrowns);
                getChange.Add("fivehundred bills", fiveHundredCrowns);
                getChange.Add("hundred bills", hundredCrowns);
                getChange.Add("fifty bills", fiftyCrowns);
                getChange.Add("twenty bills", twentyCrowns);
                getChange.Add("ten crown/-s", tenCrowns);
                getChange.Add("five crown/-s", fiveCrowns);
                getChange.Add("one crown/-s", oneCrown);

                // Clear any old product information
                ClearPartOfConsole(6, 22, 90, 23); 
                int positionIndex = 18;
                foreach (KeyValuePair<string, int> kvp in getChange)
                {
                    if (kvp.Value > 0)
                    {
                        ConsolePositioning(65, positionIndex, $"Your change: {kvp.Value} {kvp.Key}");
                        positionIndex++;
                        //Console.WriteLine($"Your change: {kvp.Value} {kvp.Key}");
                    }
                }
            }
            return totalLeft;
        }


        /// <summary>
        /// Initializes the products in machine from start.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();
            products.Add(new Snack("Snack", "Chips", 40, "150 g. Original taste."));
            products.Add(new Snack("Snack", "French Nougat", 40, "50 g. Two pieces."));
            products.Add(new Snack("Snack", "Dark Chocolate", 40, "200 g. Marabou."));
            products.Add(new Drink("Drink", "Still water", 15, "37 cl. Non sparkling."));
            products.Add(new Drink("Drink", "Loka citron", 15, "37 cl. Sparkling."));
            products.Add(new Drink("Drink", "Coca Cola", 25, "35 cl. Pepsi. Lots of sugar!"));
            products.Add(new Fruit("Fruit", "Apple", 7, " Ca 50 g. Swedish fruit."));
            products.Add(new Fruit("Fruit", "Banana", 8, "Ca 60 g. Eco, from Costa Rica."));
            products.Add(new Fruit("Fruit", "Peach", 10, "Ca 45 g. From Spain."));
            // foreach(Product prod in )
            return products;
        }


        /// <summary>
        ///  Get the different denomination used in machine
        /// </summary>
        /// <returns></returns>
        private Money[] GetDenominations()
        {
            int[] denominations = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
            Money[] moneys = new Money[denominations.Length];
            for (int i = 0; i < denominations.Length; i++)
            {
                moneys[i] = (new Money(denominations[i], "SEK"));
            }
            return moneys;
        }


        //***************************************************************   INSERT    ***********************************************************************

        /// <summary>
        /// Customer insert of valid denominations
        /// </summary>
        /// <param name="moneys"></param>
        /// <param name="totalAmount"></param>
        /// <returns> totalAmount inserted</returns>
        public int InsertMoney(Money[] moneys, int totalAmount)
        {
            int totalDeposit = totalAmount;
            int amount = 0;
            bool goOn;
            string commaOrNot;
            int index = 16;
            ClearPartOfConsole(6, 20, 70, 20);
            ConsolePositioning(65, 16, "You can use: ");
            //Console.Write($"\nYou can use: ");

            for (int i = 0; i< moneys.Length; i++)
            {
                commaOrNot = i < moneys.Length - 1 ? ", " : "";
                ConsolePositioning(78, index, $"{moneys[i].Denomination} SEK{commaOrNot}");
                index++;
                //Console.WriteLine($"{moneys[i].Denomination} SEK{commaOrNot}");
            }
            Console.WriteLine();
            
            do
            {
                goOn = ReadInputValue(out amount);

                if (goOn == true)
                {
                    totalDeposit = UpdateDeposit (amount, totalDeposit);
                }
                ConsolePositioning(65, 26, $"Your deposit: {totalDeposit} kr");
                ConsolePositioning(100, 5, totalDeposit.ToString());
                //Console.WriteLine($" Your deposit: {totalDeposit} kr");
            } while (goOn);

            ClearPartOfConsole(65, 16, 90, 26);
            return totalDeposit;
        }


        private void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                         **************************************************");
            Console.WriteLine("\n                               Welcome to Mary's Vending machine!\n");
            Console.WriteLine("                         **************************************************");
            Console.ResetColor();
            
        }

        

        //***************************************************************************   PURCHASE    ****************************************************


        /// <summary>
        /// The custormers purchasing. Handle purchase and user balance left. 
        /// Shows also extra information, when user wants to use the product.
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public int Purchase(int balance)
        {
            bool goOn;
           
            ClearPartOfConsole(6, 20, 80, 20);
            ClearPartOfConsole(6, 21, 45, 21); // HS 
            ConsolePositioning(6, 20, "Take a look on the list what we can offer.");
            //Console.WriteLine("\t\tTake a look on the list what we can offer.");
            do
            {
                goOn = ReadInputValueForPurchasing(out int number);
                string? validYOrN; 
                if (goOn == true)
                {
                    foreach (Product prod in products)
                    {
                        if (prod.ID == number)
                        {
                            if (balance >= prod.Price)
                            {
                                ClearPartOfConsole(25, 25, 80, 25);
                                balance -= prod.Price;
                                ConsolePositioning(6, 22, $"You picked a: {prod.Name}, {prod.Price} SEK. You've got {balance:C} left to use");
                                ConsolePositioning(100, 5, balance.ToString());
                                //Console.WriteLine($"You picked a: {prod.Name}, {prod.Price} SEK");
                                //Console.WriteLine($"You've got {balance:C} left to use");
                                ConsolePositioning(6, 23, "Do you want to use your product? y (yes) n (no): ");
                                //Console.Write("Do you want to use your product? y (yes) n (no): ");
                                validYOrN = CheckValidYOrN(Console.ReadLine().ToLower());

                                if (validYOrN == "y")
                                {
                                    if (prod.Category == "Snack" || prod.Category == "Fruit" || prod.Category == "Drink")
                                    {
                                        ConsolePositioning(25, 25, prod.Use());
                                        //Console.WriteLine(prod.Use());
                                    }
                                }
                                else
                                {
                                    // Do nothing for no...
                                }
                            }
                            else
                            {
                                ConsolePositioning(6, 23, $"You can't buy this product due to current balance");
                                //Console.WriteLine($"You can't buy this product due to current balance");
                                goOn = false;
                            }
                        }
                    }
                }
                else
                {
                    goOn = false;
                }
            }
            while (balance > 0 && goOn);

            return balance;
        }


        //********************************************************************* READINPUTVALUE  ********************************************************************
        private bool ReadInputValue(out int amount)
        {
            bool validInput = false;
            bool goOn = true;
            amount = 0;
            do
            {
                ConsolePositioning(65, 25, "Insert value or press q to finish: ");
                //Console.Write("\t\tInsert value or press q to finish: ");
                string? insertedStringValue = Console.ReadLine();
                ClearPartOfConsole(65, 24, 105, 25);
                if (insertedStringValue == "q")
                {
                    goOn = false;
                    validInput = true;
                }
                else if (!int.TryParse(insertedStringValue, out amount))
                {
                    ConsolePositioning(65, 24, "Not valid.");
                    //Console.WriteLine("Not valid. ");
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);
            return goOn;
        }


        /// <summary>
        /// Tests the users input value for what to do - purchase or quit. Valid input?
        /// </summary>
        /// <param name="prodNum"></param>
        /// <returns></returns>
        private bool ReadInputValueForPurchasing(out int prodNum)
        {
            bool validInput = false;
            bool goOn = true;
            prodNum = 0;
            do
            {
                ClearPartOfConsole(6, 22, 85, 23);
                ConsolePositioning(6, 22, "Choose product number or press q to finish: ");
                //Console.Write("\t\tChoose product number or press q to finish: ");
                string? insertedStringValue = Console.ReadLine();
                if (insertedStringValue == "q")
                {
                    goOn = false;
                    validInput = true;
                }
                else if (!int.TryParse(insertedStringValue, out prodNum) || prodNum > products.Count)
                {
                    ConsolePositioning(6, 21, "Not valid number.");
                    //Console.WriteLine("Not valid number. ");
                }
                else
                {
                    validInput = true;
                }
            }
            while (!validInput);
            return goOn;

        }


        /// <summary>
        /// Shows all the products in machine
        /// It also can show some more details about product, if user wants to
        /// </summary>
        public void ShowAll()
        {
            string moreInfo;
            int prodChoice = 0;
            string formatted = String.Format("{0,-7} {1,-8} {2,-15} {3,-7}", "Number", "Product", "Name", "Price");
            ConsolePositioning(6, 7, formatted);
            //Console.WriteLine(formatted);
            //Console.WriteLine("---------------------------------------------------------------------------------");
            ConsolePositioning(6, 8, "------------------------------------------------");
            ClearPartOfConsole(6, 20, 70, 20);
            string prodInfo;
            int index = 10;
            foreach (Product prod in products)
            {
                prodInfo = String.Format("{0,-7} {1,-8} {2,-15} {3,-7}", prod.ID, prod.Category, prod.Name, prod.Price);
                ConsolePositioning(6, index, prodInfo);
                index++;
            }

            ConsolePositioning(6, index + 2, "More product info? y (yes)/ n (no): ");
            //Console.Write("More product info? y (yes)/ n (no): ");
            moreInfo = CheckValidYOrN(Console.ReadLine().ToLower());
            if(moreInfo == "y")
            {
                ClearPartOfConsole(6, 21, 45, 21);
                ConsolePositioning(6, index + 1, "Choose product by number in list: ");
                //Console.Write("Choose product by number in list: ");
                while (!int.TryParse(Console.ReadLine(), out prodChoice) || prodChoice > products.Count || prodChoice < 1)
                {
                    ConsolePositioning(6, index + 1, "Invalid number. Try again!: ");
                    //Console.Write("\nInvalid number. Try again!: ");
                }
                foreach(Product prod in products)
                {
                    if (prodChoice == prod.ID)
                    {
                        ConsolePositioning(6, index + 1, prod.Examine());
                        //Console.WriteLine($"Some more info: {prod.Name} - {prod.Description}  Price: {prod.Price:C}");
                    }
                }
            }
        }

        /// <summary>
        /// Updates the users insert values. Keep track of total for each denomination
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="totalDeposit"></param>
        /// <returns></returns>
        public int UpdateDeposit(int amount, int totalDeposit)
        {
            switch (amount)
            {
                case 1:
                    {
                        totalDeposit += 1;
                        break;
                    }
                case 5:
                    {
                        totalDeposit += 5;
                        break;
                    }
                case 10:
                    {
                        totalDeposit += 10;
                        break;
                    }
                case 20:
                    {
                        totalDeposit += 20;
                        break;
                    }
                case 50:
                    {
                        totalDeposit += 50;
                        break;
                    }
                case 100:
                    {
                        totalDeposit += 100;
                        break;
                    }
                case 500:
                    {
                        totalDeposit += 500;
                        break;
                    }
                case 1000:
                    {
                        totalDeposit += 1000;
                        break;
                    }
                default:
                    {
                        ConsolePositioning(65, 24, "That's not a valid denomination"); 
                        // Console.WriteLine("That's not a valid denomination");
                        break;
                    }
            }
            return totalDeposit;
        }
    }
}
