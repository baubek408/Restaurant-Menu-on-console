using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RestaurantMenu
{
    
    //############CREATING CLASSES (BASE, MEAT, VEGETABLES)########################

    class Product // Base class 
    {
        public string name { get; set; }
        public int number { get; set; }
        public int price { get; set; }
        public int alergie { get; set; }


        // ############  METHODS  ################################################


        public static void MenuProduct(int n, List<Product> filenames, string text = " ") // Method of sorting
        {

            List<int> empty = new List<int>();
            Console.Clear();
            Console.WriteLine(text);
            foreach (var b in filenames)
            {
                if (n != b.alergie)
                {
                    int time = 40 - b.name.Length;
                    List<int> corect = new List<int>();
                    corect.Add(b.number);
                    string tabs = new string('-', time);
                    Console.WriteLine("{0}) {1} {2} {3}Kč", b.number, b.name, tabs, b.price); // Allegie filtring
                    
                }

            }
            
            
        }

        //public List<int> AvailableNnumber()
        //{
        //    List<int> AvailableNumber = new List<int>;
        //    foreach
        //    return AvailableNumber;
        //}


        public static void ProductAdd(int n, List<Product> filenames, List<string> order, List<int> totalprice) // Method of Adding product and in a OrderList, counting price
        {
            foreach (var b in filenames)
            {
                if (n == b.number)
                {
                    order.Add(b.name);
                    totalprice.Add(b.price);

                }
               
            }
        }

        




    }

    class Priloha : Product
    {

    }
    class Meat : Product
    {

    }
    class Vegetables : Product
    {

    }
    class Souce : Product
    {

    }

    internal class Program
    {
        static int CorrectNumber(int min, int max)   // Method of checking correction of input number
        {
            int cislo;
            bool povedlose = true, minmax = true;
            do
            {
                if (!povedlose)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong char. Please try to choose a number from the list!!!");
                    Console.ResetColor();
                }
                else if (!minmax)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Out of range: {0}-{1}", min, max);
                    Console.ResetColor();
                }

                povedlose = int.TryParse(Console.ReadLine(), out cislo);

                if (povedlose)
                {
                    if (cislo >= min && cislo <= max)
                        minmax = true;
                    else
                        minmax = false;
                }
            } while (!povedlose || !minmax);

            return cislo;

        }

       


        public static void Cleaning()   // Declaration (Method of cleaning previous lines)
        {
            Console.WriteLine("\nPlease press any case to continue:");
            Console.ReadKey();
            Console.Clear();
        }
        public static int ShowMenu()  // Declaration (Welcome Menu)
        {
            
            string volba;
            Console.WriteLine("####################################################");
            Console.WriteLine("Hello! Welcome to our restaurant 'The Dragons Soul'.");
            Console.WriteLine("####################################################\n");

            Console.WriteLine("Whould you like to order something?:");
            Console.WriteLine("1) Yes");
            Console.WriteLine("2) No, thanks");
            volba = Console.ReadLine();
            switch (volba)//přečíst výběr
            {

                case "1":
                    
                    return 1;
                case "2":
                    
                    return 2;
                default:
                    int n = CorrectNumber(1, 2);

                    return n;
            }

        }
        public static int AlergieList() // List of Alergie
        {
            
            Console.Clear();
            Console.WriteLine("Please tell us if you are allergic to anything?:\n");
            Console.WriteLine("1) Wheat");
            Console.WriteLine("2) Eggs");
            Console.WriteLine("3) Fish (e.g., bass, flounder, cod)");
            Console.WriteLine("4) Crustacean shellfish (e.g., crab, lobster, shrimp)");
            Console.WriteLine("5) Tree nuts (e.g., almonds, walnuts, pecans)");
            Console.WriteLine("6) Peanuts");
            Console.WriteLine("7) Soybeans");
            Console.WriteLine("8) No, I don't have any allergie)");
            
            return CorrectNumber(1, 8);//Read a choice    
            
            
        }

        static void PMenu(List<Product> filenames, List<string> order, List<int> totalprice, int alergie) // Methods of Adding products and counting the price of order
        {
  
            Product.MenuProduct(alergie, filenames, "Ok. Let's choose your base:\n");
            //correct.Add = ;
            int number = CorrectNumber(1, 6);
            Priloha.ProductAdd(number, filenames, order, totalprice);
        }

        static void MMenu(List<Product> filenames, List<string> order, List<int> totalprice, int alergie)
        {
            Meat.MenuProduct(alergie, filenames, "Got it! And now Meat:\n");
            int number = CorrectNumber(1, 6);
            Meat.ProductAdd(number, filenames, order, totalprice);

        }
        static void VMenu(List<Product> filenames, List<string> order, List<int> totalprice, int alergie)
        {
            Vegetables.MenuProduct(alergie, filenames, "OK! Would you like a vegetables?:\n");
            int number = CorrectNumber(1, 6);
            Vegetables.ProductAdd(number, filenames, order, totalprice);

        }

        static void SMenu(List<Product> filenames, List<string> order, List<int> totalprice, int alergie)
        {
            Souce.MenuProduct(alergie, filenames, "And last one. Souce, please?:\n");
            int number = CorrectNumber(1, 5);
            Souce.ProductAdd(number, filenames, order, totalprice);
            Console.Clear();
            Console.WriteLine("Your order is: [" + (string.Join(", ", order)) + "]\n");     //Showing a order
            Console.WriteLine("Price is: " + totalprice.AsQueryable().Sum() + "Kč");        //Showing a price of order
            
            Cleaning();
        }

       


        static void Main(string[] args)
        {
            

            List<string> OrderList = new List<string>(); //Create a Order List for showing whats was choosen
            List<int> PriceList = new List<int>();
            List<Product> PList = new List<Product>(); // List of Bases
            List<int> AvailableNumber = new List<int>();

            PList.Add(new Priloha { name = "Egg noodles", number = 1, price = 75, alergie = 2 });
            PList.Add(new Priloha { name = "Rice noodles", number = 2, price = 75, alergie = 0 });
            PList.Add(new Priloha { name = "Whole-wheat noodles", number = 3, price = 70, alergie = 1 });
            PList.Add(new Priloha { name = "Udon noodles", number = 4, price = 80, alergie = 2 });
            PList.Add(new Priloha { name = "Fried jasmin rice", number = 5, price = 70, alergie = 0 });
            PList.Add(new Priloha { name = "Fried whole-wheat rice", number = 6, price = 80, alergie = 1 });
            

            List<Product> MList = new List<Product>(); // List of Meat
            MList.Add(new Meat { name = "Tofu", number = 1, price = 35, alergie = 7 });
            MList.Add(new Meat { name = "Beef", number = 2, price = 45, alergie = 0 });
            MList.Add(new Meat { name = "Chicken", number = 3, price = 35, alergie = 0 });
            MList.Add(new Meat { name = "Duck", number = 4, price = 45, alergie = 0 });
            MList.Add(new Meat { name = "Shrimps", number = 5, price = 50, alergie = 4 });
            MList.Add(new Meat { name = "Salmon", number = 6, price = 50, alergie = 3 });
            

            List<Product> VList = new List<Product>(); // List of Vegetables
            VList.Add(new Vegetables { name = "Mashrooms", number = 1, price = 15, alergie = 0 });
            VList.Add(new Vegetables { name = "Bell pepper", number = 2, price = 17, alergie = 0 });
            VList.Add(new Vegetables { name = "Broccoli", number = 3, price = 13, alergie = 0 });
            VList.Add(new Vegetables { name = "Green Beans", number = 4, price = 10, alergie = 0 });
            VList.Add(new Vegetables { name = "Corn", number = 5, price = 18, alergie = 0 });
            

            List<Product> SList = new List<Product>(); // List of Souces
            SList.Add(new Souce { name = "Teriyaki", number = 1, price = 10, alergie = 0 });
            SList.Add(new Souce { name = "Pad Thai", number = 2, price = 10, alergie = 0 });
            SList.Add(new Souce { name = "Sweet chilli & Soya souce", number = 3, price = 10, alergie = 0 });
            SList.Add(new Souce { name = "Peanut souce", number = 4, price = 10, alergie = 6 });
            SList.Add(new Souce { name = "Thai", number = 5, price = 10, alergie = 0 });
            

            bool exit = false;
            


            string filepath = @"/Users/mynbayevbaubek/Projects/RestaurantMenu/RestaurantMenu/orderlist.csv";
            using (StreamWriter writer = new StreamWriter(filepath)) // Creating sb

            do
            {
                OrderList.Clear();
                PriceList.Clear();
                int number = ShowMenu();                                //################## Question about ordering [y/n]###############
                switch (number)
                {
                    case 1:
                        int alergie = AlergieList();                    //################### START (LIST OF ALLERGENS)
                        PMenu(PList, OrderList, PriceList, alergie);    //################### TIME TO Base  #################################################
                        MMenu(MList, OrderList, PriceList, alergie);    //################### TIME TO Meat  #################################################
                        VMenu(VList, OrderList, PriceList, alergie);    //################### TIME TO Vegatables  #################################################
                        SMenu(SList, OrderList, PriceList, alergie);    //################### TIME TO Souce  #################################################
                        List<string> titles = new List<string>() { "Base", "Meat", "Vegatables", "Souce" };
                        for (var i = 0; i < OrderList.Count; i++)
                        {
                            writer.WriteLine("{0}: [{1}]", titles[i], OrderList[i]);   // Adding order items in csv file
                            
                        }
                        
                        writer.Write("Price: " + PriceList.AsQueryable().Sum() + "Kč");
                           
                        break;
                    case 2:
                        Console.WriteLine("Thank you! Good Bye! Have a nice day!!! Come back again!!!)))");
                        exit = true;
                        break;
                    default:
                        int n = CorrectNumber(1, 2);

                        break;

                }

               
            } while (!exit);

            
          

        }
    }
}
