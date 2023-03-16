using System;

namespace Rsm
{
    public class Rms
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please Input Ingredient_Name:");
            Console.ReadLine();
        }

        public struct Ingredient
        {
            public string Name;
            public decimal Price;

        }

        public struct Dish
        {
            public string Name;
            public decimal Price;
            public List<Ingredient> Ingredients;
        }

        public struct Order
        {
            public List<Dish> Dishes;
            public decimal TotalPrice;
        }

        public struct Employee
        {
            public string Name;
            public string Position;
        }

        public struct Table
        {
            public int Number;
            public int Seats;
        }

        public struct Customer
        {
            public string Name;
            public int PhoneNumber;
        }
    }
}