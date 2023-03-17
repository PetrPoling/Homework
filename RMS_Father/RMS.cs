using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Rms 
    {
        public static void Main(string[] args)
        {   // start
            Console.WriteLine("Please Input 1 to start the program:");
            var x = Console.ReadLine();
            while (x != "stop")
            {

                // Create a new instance of the RestaurantManager class.
                RestaurantManager manager = new RestaurantManager();

                // Prompt the user to input information.
                Console.WriteLine("Please Input Ingredient_Name:");
                string Name_ingredient = Console.ReadLine();
                Console.WriteLine("Please Input Ingredient_Price:");
                decimal Price_ingredient = decimal.Parse(Console.ReadLine());
                // Create a new ingredient and add it to the list of ingredients.
                Ingredient ingredient = new Ingredient();
                ingredient.Name = Name_ingredient;
                ingredient.Price = Price_ingredient;
                manager.AddIngredient(ingredient);
                // Display the list of ingredients.
                List<Ingredient> ingredients = manager.GetIngredients();
                Console.WriteLine("Ingredients List:");
                foreach (Ingredient i in ingredients)
                {
                    Console.WriteLine(i.Name);
                    Console.WriteLine(i.Price);
                }

                // decimal k = 1;
                //while (k <= ingredients.Count )
                // {  k += 1;
                //    Console.WriteLine("Name: " + ingredient.Name + ", Price: " + ingredient.Price);
                //}
                Console.WriteLine(manager.GetIngredients());

                    Console.WriteLine("If enough ingredients input stop:");
            x = Console.ReadLine();
            }
        }
        // Create a struct to store information about an ingredient.
        public struct Ingredient
        {
            public string Name;
            public decimal Price;
            
        }

        // Create a struct to store information about a dish.
        public struct Dish
        {
            public string Name;
            public decimal Price;
            public List<Ingredient> Ingredients;
        }

        // Create a struct to store information about an order.
        public struct Order
        {
            public List<Dish> Dishes;
            public decimal TotalPrice;
        }

        // Create a struct to store information about an employee.
        public struct Employee
        {
            public string Name;
            public string Position;
        }

        // Create a struct to store information about a table.
        public struct Table
        {
            public int Number;
            public int Seats;
        }

        // Create a struct to store information about a customer.
        public struct Customer
        {
            public string Name;
            public int PhoneNumber;
        }

        // Create a class to manage the restaurant.
        public class RestaurantManager
        {
            public List<Ingredient> Ingredients = new List<Ingredient>(); // добавили инициализацию
            public List<Dish> Dishes = new List<Dish>(); // добавили инициализацию
            public List<Employee> Employees = new List<Employee>(); // добавили инициализацию
            public List<Table> Tables = new List<Table>(); // добавили инициализацию
            public List<Customer> Customers = new List<Customer>(); // добавили инициализацию
            public List<Order> Orders = new List<Order>(); // добавили инициализацию

            // Add a dish to the list of dishes.
            public void AddDish(Dish dish)
            {
                Dishes.Add(dish);
            }

            // Add an ingredient to the list of ingredients.
            public void AddIngredient(Ingredient ingredient)
            {
                Ingredients.Add(ingredient);
            }

            // Add an employee to the list of employees.
            public void AddEmployee(Employee employee)
            {
                Employees.Add(employee);
            }

            // Add a table to the list of tables.
            public void AddTable(Table table)
            {
                Tables.Add(table);
            }

            // Add a customer to the list of customers.
            public void AddCustomer(Customer customer)
            {
                Customers.Add(customer);
            }

            // Add an order to the list of orders.
            public void AddOrder(Order order)
            {
                Orders.Add(order);
            }

            // Return the list of dishes.
            public List<Dish> GetDishes()
            {
                return Dishes;
            }

            // Return the list of ingredients.
            public List<Ingredient> GetIngredients()
            {
                return Ingredients;
            }

            // Return the list of employees.
            public List<Employee> GetEmployees()
            {
                return Employees;
            }

            // Return the list of tables.
            public List<Table> GetTables()
            {
                return Tables;
            }

            // Return the list of customers.
            public List<Customer> GetCustomers()
            {
                return Customers;
            }

            // Return the list of orders.
            public List<Order> GetOrders()
            {
                return Orders;
            }

           
        }
    }
}