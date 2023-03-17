using System;

namespace ConsoleApp3
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

        public class RestaurantManager
        {
            public List<Dish> Dishes;
            public List<Ingredient> Ingredients;
            public List<Employee> Employees;
            public List<Table> Tables;
            public List<Customer> Customers;
            public List<Order> Orders;

            public void AddDish(Dish dish)
            {
                Dishes.Add(dish);
            }

            public void AddIngredient(Ingredient ingredient)
            {
                Ingredients.Add(ingredient);
            }

            public void AddEmployee(Employee employee)
            {
                Employees.Add(employee);
            }

            public void AddTable(Table table)
            {
                Tables.Add(table);
            }

            public void AddCustomer(Customer customer)
            {
                Customers.Add(customer);
            }

            public void AddOrder(Order order)
            {
                Orders.Add(order);
            }

            public List<Dish> GetDishes()
            {
                return Dishes;
            }

            public List<Ingredient> GetIngredients()
            {
                return Ingredients;
            }

            public List<Employee> GetEmployees()
            {
                return Employees;
            }

            public List<Table> GetTables()
            {
                return Tables;
            }

            public List<Customer> GetCustomers()
            {
                return Customers;
            }

            public List<Order> GetOrders()
            {
                return Orders;
            }

           
        }
    }
}