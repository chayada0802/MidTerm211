using System;
using System.Collections.Generic;
namespace Three
{
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";
            string selectFlower;
            FlowerStore flowerStore = new FlowerStore();
            do
            {
                flowerStore.Showlistmenu(flowerStore);
                selectFlower = Console.ReadLine();
                Addlistflower(flowerStore, selectFlower);
                decide = InputdecideFromKeyBoard(flowerStore, decide);
                Checkinputforexit(flowerStore, decide);
            }
            while (decide != "exit");
        }
        static string InputdecideFromKeyBoard(FlowerStore flowerStore, string decide)
        {
            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and press any key for continue");
            decide = Console.ReadLine();
            return decide;
        }
        static void Addlistflower(FlowerStore flowerStore, string selectFlower)
        {
            switch (selectFlower)
            {
                case "1":
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]);
                    break;
                case "2":
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;
                default:
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }
        static void Checkinputforexit(FlowerStore flowerStore, string decide)
        {
            if (decide == "exit")
            {
                Console.Write("Current my cart");
                flowerStore.showCart();
            }
        }
    }
    class FlowerStore
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();

        public FlowerStore()
        {
            flowerList.Add("Rose");

            flowerList.Add("Lotus");
        }
        public void addToCart(string name)
        {
            cart.Add(name);
        }

        public void showCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.WriteLine("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public void Showlistmenu(FlowerStore flowerStore)
        {
            Console.WriteLine("Select number for buy flower :");
            foreach (string i in flowerStore.flowerList)
            {
                Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                Console.WriteLine(i);
            }
        }
    }
}
