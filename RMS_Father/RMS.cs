using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public class Rms 
    {
        public static void Main(string[] args)
        {
            string entrance = "start";
            while (entrance != "exit")
            {
                Console.WriteLine("You have such options: ingredients, dishes, orders, employees, tables, customers " +
                                  "or exit to stop the application");
                Console.WriteLine("Choose your option:");
                entrance = Console.ReadLine();
                if (entrance == "ingredients")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_ingredient;
                    decimal Price_ingredient;
                    var x = Console.ReadLine();
                    // Create a new ingredient and add it to the list of ingredients.
                    Ingredient ingredient = new Ingredient();
                    manager.AddIngredient(ingredient);
                    // Display the list of ingredients.
                    List<Ingredient> ingredients = manager.GetIngredients();
                    while (x != "stop")
                    {

                        // Create a new instance of the RestaurantManager class.

                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Ingredient_Name:");
                        Name_ingredient = Console.ReadLine();
                        Console.WriteLine("Please Input Ingredient_Price:");
                        Price_ingredient = decimal.Parse(Console.ReadLine());
                        // Create a new ingredient and add it to the list of ingredients.
                        ingredient.Name = Name_ingredient;
                        ingredient.Price = Price_ingredient;
                        manager.AddIngredient(ingredient);
                        // Display the list of ingredients.
                        Console.WriteLine("Ingredients List:");
                        foreach (Ingredient i in ingredients)
                        {
                            Console.WriteLine($"Ingredient: {i.Name}");
                            Console.WriteLine($"Price: {i.Price}");
                        }

                        Console.WriteLine("If enough ingredients input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                if (entrance == "dishes")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_dish;
                    decimal Price_dish;
                    var x = Console.ReadLine();
                    // Create a new ingredient and add it to the list of ingredients.
                    Dish dish = new Dish();
                    manager.AddDish(dish);
                    // Display the list of ingredients.
                    List<Dish> dishes = manager.GetDishes();
                    while (x != "stop")
                    {

                        // Create a new instance of the RestaurantManager class.

                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Dish_Name:");
                        Name_dish = Console.ReadLine();
                        Console.WriteLine("Please Input Dish_Price:");
                        Price_dish = decimal.Parse(Console.ReadLine());
                        // Create a new dish and add it to the list of Dishes.
                        dish.Name = Name_dish;
                        dish.Price = Price_dish;
                        manager.AddDish(dish);
                        // Display the list of Dishes.
                        Console.WriteLine("Dishes List:");
                        foreach (Dish i in dishes)
                        {
                            Console.WriteLine($"Dish: {i.Name}");
                            Console.WriteLine($"Price: {i.Price}");

                        }
                        Console.WriteLine("If you chose the dishes input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                if (entrance == "dishes")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_dish;
                    decimal Price_dish;
                    var x = Console.ReadLine();
                    // Create a new ingredient and add it to the list of ingredients.
                    Dish dish = new Dish();
                    manager.AddDish(dish);
                    // Display the list of ingredients.
                    List<Dish> dishes = manager.GetDishes();
                    while (x != "stop")
                    {

                        // Create a new instance of the RestaurantManager class.

                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Dish_Name:");
                        Name_dish = Console.ReadLine();
                        Console.WriteLine("Please Input Dish_Price:");
                        Price_dish = decimal.Parse(Console.ReadLine());
                        // Create a new dish and add it to the list of Dishes.
                        dish.Name = Name_dish;
                        dish.Price = Price_dish;
                        manager.AddDish(dish);
                        // Display the list of Dishes.
                        Console.WriteLine("Dishes List:");
                        foreach (Dish i in dishes)
                        {
                            Console.WriteLine($"Dish: {i.Name}");
                            Console.WriteLine($"Price: {i.Price}");

                        }
                        Console.WriteLine("If you chose the dishes input stop triple time to approve, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                if (entrance == "dishes")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_dish;
                    decimal Price_dish;
                    var x = Console.ReadLine();
                    // Create a new ingredient and add it to the list of ingredients.
                    Dish dish = new Dish();
                    manager.AddDish(dish);
                    // Display the list of ingredients.
                    List<Dish> dishes = manager.GetDishes();
                    while (x != "stop")
                    {

                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Dish_Name:");
                        Name_dish = Console.ReadLine();
                        Console.WriteLine("Please Input Dish_Price:");
                        Price_dish = decimal.Parse(Console.ReadLine());
                        // Create a new dish and add it to the list of Dishes.
                        dish.Name = Name_dish;
                        dish.Price = Price_dish;
                        manager.AddDish(dish);
                        // Display the list of Dishes.
                        Console.WriteLine("Dishes List:");
                        foreach (Dish i in dishes)
                        {
                            Console.WriteLine($"Dish: {i.Name}");
                            Console.WriteLine($"Price: {i.Price}");

                        }
                        Console.WriteLine("If you chose the dishes input stop twice to approve, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                if (entrance == "orders")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_order;
                    decimal Price_order;
                    var x = Console.ReadLine();
                    // Create a new order and add it to the list of orders.
                    Order order = new Order();
                    manager.AddOrder(order);
                    // Display the list of orders.
                    List<Order> orders = manager.GetOrders();
                    while (x != "stop")
                    {
                        
                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Order_List:");
                        Name_order = Console.ReadLine();
                        Console.WriteLine("Please Input Order_Price:");
                        Price_order = decimal.Parse(Console.ReadLine());
                        // Create a new order and add it to the list of Orderss.
                        order.Name = Name_order;
                        order.TotalPrice = Price_order;
                        manager.AddOrder(order);
                        // Display the list of Orders.
                        Console.WriteLine("Orders List:");
                        foreach (Order i in orders)
                        {
                            Console.WriteLine($"Order: {i.Name}");
                            Console.WriteLine($"Price: {i.TotalPrice}");

                        }
                        Console.WriteLine("If you chose the order, input stop to approve, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                if (entrance == "employees")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_employee;
                    string Position_employee;
                    var x = Console.ReadLine();
                    // Hire a new employee and add it to the list of employees.
                    Employee employee = new Employee();
                    manager.AddEmployee(employee);
                    // Display the list of orders.
                    List<Employee> employees = manager.GetEmployees();
                    while (x != "stop")
                    {
                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Employee_Name:");
                        Name_employee = Console.ReadLine();
                        Console.WriteLine("Please Input Employee_Position:");
                        Position_employee = Console.ReadLine();
                        // Create a new order and add it to the list of Employees.
                        employee.Name = Name_employee;
                        employee.Position = Position_employee;
                        manager.AddEmployee(employee);
                        // Display the list of Employees.
                        Console.WriteLine("Employees List:");
                        foreach (Employee i in employees)
                        {
                            Console.WriteLine($"Name: {i.Name}");
                            Console.WriteLine($"Position: {i.Position}");

                        }
                        Console.WriteLine("If you added employee, input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                
                if (entrance == "tables")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Number_table;
                    string Seats_table;
                    var x = Console.ReadLine();
                    // Create a new table and add it to the list of tables.
                    Table table = new Table();
                    manager.AddTable(table);
                    // Display the list of orders.
                    List<Table> tables = manager.GetTables();
                    while (x != "stop")
                    {
                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Table_Number:");
                        Number_table = Console.ReadLine();
                        Console.WriteLine("Please Input Table_Seats:");
                        Seats_table = Console.ReadLine();
                        // Create a new table and add it to the list of tabless.
                        table.Number = Number_table;
                        table.Seats = Seats_table;
                        manager.AddTable(table);
                        // Display the list of Tables.
                        Console.WriteLine("Tables List:");
                        foreach (Table i in tables)
                        {
                            Console.WriteLine($"Name: {i.Number}");
                            Console.WriteLine($"Position: {i.Seats}");

                        }
                        Console.WriteLine("If you added table, input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
                if (entrance == "customers")
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    string Name_customer;
                    string PhoneNumber_customer;
                    var x = Console.ReadLine();
                    // Create a new table and add it to the list of tables.
                    Customer customer = new Customer();
                    manager.AddCustomer(customer);
                    // Display the list of orders.
                    List<Customer> customers = manager.GetCustomers();
                    while (x != "stop")
                    {
                        // Prompt the user to input information.
                        Console.WriteLine("Please Input Customer_Name:");
                        Name_customer = Console.ReadLine();
                        Console.WriteLine("Please Input Customer_PhoneNumber:");
                        PhoneNumber_customer = Console.ReadLine();
                        // Create a new table and add it to the list of tabless.
                        customer.Name = Name_customer;
                        customer.PhoneNumber = PhoneNumber_customer;
                        manager.AddCustomer(customer);
                        // Display the list of Customers.
                        Console.WriteLine("Tables List:");
                        foreach ( Customer i in customers)
                        {
                            Console.WriteLine($"Name: {i.Name}");
                            Console.WriteLine($"PhoneNumber: {i.PhoneNumber}");

                        }
                        Console.WriteLine("If you added customers, input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                }
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
        }

        // Create a struct to store information about an order.
        public struct Order
        {
            public string Name;
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
            public string Number;
            public string Seats;
        }

        // Create a struct to store information about a customer.
        public struct Customer
        {
            public string Name;
            public string PhoneNumber;
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