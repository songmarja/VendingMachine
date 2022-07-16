namespace VendingMachine
{
    internal class Program
    {
        // The app is in a way based on my personal picture of how a vending machine works. You can see all the items,
        // have an insert for different denominations, can get your product and change. I have also played around - a bit too much - with ConsolPositioning,
        //. It was an effort to make it somehow a bit more readable for user.. I have not deleted the alternatives with Console WriteLine instead.
        // The balance, is updated after every action, but maybe not the way you should do..?.
        // The list of products, is showed, when user decides to show it. It gets a bit confusing, when user not do so, and just want to purchase directly..
        // In EndTransaction method, I had changed it to use Money class instead of the specific amount, when calculating.
        // The tests I found rather difficult to build, as you want to test for example Insert, because I don't know how to do with user input in tests.
        // //I have not made so many tests...
        
        static void Main(string[] args)
        {
            //Console.Title = "Marys Vending machine";
            Vending vending = new Vending();
            vending.Run();
        }
    }
}