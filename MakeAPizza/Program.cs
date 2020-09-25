using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;

namespace MakeAPizza
{
    public class Pizza
    {
        public string Size;
        public string Crust;
        public string Sauce;
        public string Cheese;
        public List<string> Toppings;

        public Pizza(string size, string crust, string sauce, string cheese, List<string> toppings)
        {
            Size = size;
            Crust = crust;
            Sauce = sauce;
            Cheese = cheese;
            Toppings = toppings;
        }
    }
    class Program
    {
        public static List<Pizza> AllPizzas = new List<Pizza>();
        static void Main(string[] args)
        {
            Order();
        }

        public static void Order()
        {
            string[] sizeOptions = { "small", "medium", "large", "xl", "xxl", "xxxl" };
            string[] crustOptions = { "thin", "pan", "original" };
            string[] sauceOptions = { "tomato", "alfredo", "bbq", "ranch", "honey mustard", "ketchup" };
            string[] cheeseOptions = { "cheez whiz", "gouda", "havarti", "string" };
            string[] toppingOptions = { "no extra toppings", "anchovies", "mushrooms", "pepperoni", "sausage", "bell peppers" };

            string selectedSize;
            string selectedCrust;
            string selectedSauce;
            string selectedCheese;
            List<string> selectedToppings = new List<string>();

            // getSize(sizeOptions);
            Console.WriteLine("Let's start your pizza. What size would you like? ({0})", string.Join(", ", sizeOptions));
            bool validSize = false;
            do
            {
                selectedSize = Console.ReadLine();
                int intSelectedSize = Array.IndexOf(sizeOptions, selectedSize);
                if (intSelectedSize > -1)
                {
                    validSize = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose from the list of choices.");
                };
            }
            while (validSize == false);
            Console.WriteLine("Great. Which type of crust do you want? ({0})", string.Join(", ", crustOptions));
            bool validCrust = false;
            do
            {
                selectedCrust = Console.ReadLine();
                int intSelectedCrust = Array.IndexOf(crustOptions, selectedCrust);
                if (intSelectedCrust > -1)
                {
                    validCrust = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose from the list of choices.");
                };
            }
            while (validCrust == false);
            Console.WriteLine("Fkn right. Which type of sauce do you want? ({0})", string.Join(", ", sauceOptions));
            bool validSauce = false;
            do
            {
                selectedSauce = Console.ReadLine();
                int intSelectedSauce = Array.IndexOf(sauceOptions, selectedSauce);
                if (intSelectedSauce > -1)
                {
                    validSauce = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose from the list of choices.");
                };
            }
            while (validSauce == false);
            Console.WriteLine("Ooooahh my GOD, you have good taste! Which type of cheese do you want to melt IN YOUR MOUTH? ({0})", string.Join(", ", cheeseOptions));
            bool validCheese = false;
            do
            {
                selectedCheese = Console.ReadLine();
                int intSelectedCheese = Array.IndexOf(cheeseOptions, selectedCheese);
                if (intSelectedCheese > -1)
                {
                    validCheese = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose from the list of choices.");
                };
            }
            while (validCheese == false);

            int toppingCounter = 0;
 
            do
            {
                Console.WriteLine("Fantastic. Which toppings do you want? Select up to three toppings, just choose one at a time and click 'enter'. ({0})", string.Join(", ", toppingOptions));
                bool validTopping = false;
                do
                {
                    string thisTopping = Console.ReadLine();
                    if (toppingOptions.Contains(thisTopping))
                    {
                        switch (thisTopping)
                        {
                            case "anchovies":
                                validTopping = true;
                                selectedToppings.Add(thisTopping);
                                toppingCounter += 1;
                                break;
                            case "mushrooms":
                                validTopping = true;
                                selectedToppings.Add(thisTopping);
                                toppingCounter += 1;
                                break;
                            case "sausage":
                                validTopping = true;
                                selectedToppings.Add(thisTopping);
                                toppingCounter += 1;
                                break;
                            case "pepperoni":
                                validTopping = true;
                                selectedToppings.Add(thisTopping);
                                toppingCounter += 1;
                                break;
                            case "bell peppers":
                                validTopping = true;
                                selectedToppings.Add(thisTopping);
                                toppingCounter += 1;
                                break;
                            case "no extra toppings":
                                validTopping = true;
                                selectedToppings.Add("no extra");
                                toppingCounter += 3;
                                break;
                            default:
                                break;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Choose from the list of choices.");
                    };
                }
                while (validTopping == false);
            } while (toppingCounter < 3 || selectedToppings.Contains("no extra toppings"));

           var thisPizza = new Pizza(selectedSize, selectedCrust, selectedSauce, selectedCheese, selectedToppings);
            AllPizzas.Add(thisPizza);
            string toppingString = string.Join(", ", selectedToppings);
            string pizzaString = AllPizzas.Count() > 1 ? "pizzas" : "pizza";

            Console.WriteLine("Alright, you've ordered " + AllPizzas.Count() + " " + pizzaString + ". Would you like to order another? (yes or no)");
            bool validAnswer = false;
            do
            {
                string wantsAnother = Console.ReadLine();
                if ( wantsAnother == "yes" | wantsAnother == "no")
                {
                    validAnswer = true;
                    if (wantsAnother == "yes")
                    {
                        Order();
                    } else {
                        validAnswer = false;
                        foreach (Pizza pizza in AllPizzas) { Console.WriteLine("You have a " + pizza.Size + " pizza with " + pizza.Crust + " crust, " + pizza.Sauce + " sauce, " + pizza.Cheese + " cheese, and " + toppingString + " toppings."); }
                    };
                }
                else
                {
                    Console.WriteLine("Invalid choice. Choose from the list of choices.");
                };
            }
            while (validAnswer == false);
            
        }

    }
}
