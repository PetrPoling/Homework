using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RMS_Finita;

public class Rms
{
    public static void Main(string[] args)
    {
        string entrance = "start";
        while (entrance != "exit")
        {
            Console.WriteLine(
                "You have such options: ingredients-1, dishes-2, orders-3, employees-4, tables-5, customers-6 " +
                "or exit to stop the application");
            Console.WriteLine("Choose your option:");
            entrance = Console.ReadLine();
            switch (entrance)
            {
                case "1":
                {
                    // start
                    var manager = new RestaurantManager();
                    var x = "start";
                    // Create a new ingredient and add it to the list of ingredients.
                    var ingredient = new Ingredient();
                    // Display the list of ingredients.
                    var ingredients = manager.GetIngredients();

                    while (x != "stop")
                    {
                        Console.WriteLine("Chose the option: add-1, observe-2, remove-3");
                        x = Console.ReadLine();
                        if (x == "1")
                        {
                            // Prompt the user to input information.
                            Console.WriteLine("Please Input Ingredient_Name:");
                            string Name_ingredient = Console.ReadLine();
                            Console.WriteLine("Please Input Ingredient_Price:");
                            string Price_ingredient = Console.ReadLine();
                            Console.WriteLine("Please Input Ingredient_Amount:");
                            string Amount_ingredient = Console.ReadLine();

                            // Create a new ingredient and add it to the list of ingredients.
                            Ingredient.name = Name_ingredient;
                            Ingredient.price = Price_ingredient;
                            Ingredient.amount = Amount_ingredient;
                            Ingredients.AddIngredient(ingredient);
                            string directoryPath = @"D:\Git Hub\Homework\RMS_Finita\bin\Debug\net6.0";
                            if (System.IO.Directory.Exists(directoryPath))
                            {
                                StreamWriter ing_w = new StreamWriter("Ingredient.txt", true);
                                ing_w.WriteLine((Ingredient.name, Ingredient.price, Ingredient.amount).ToString());

                                ing_w.Dispose();
                                //Pass the file path and file name to the StreamReader constructor
                                StreamReader ing_r = new StreamReader("Ingredient.txt", true);
                                //Read the first line of text
                                var line = ing_r.ReadLine();
                                //Continue to read until you reach end of f1ile
                                while (line != null)
                                {
                                    //write the lie to console window
                                    Console.WriteLine(line);
                                    //Read the next line
                                    line = ing_r.ReadLine();
                                }

                                //close the file
                                ing_r.Close();
                            }
                            else
                            {
                                throw new Exception("error ingredient");
                            }

                        }

                        if (x == "2")
                        {
                            StreamReader ing_r = new StreamReader("Ingredient.txt", true);
                            //Read the first line of text
                            var line = ing_r.ReadLine();
                            //Continue to read until you reach end of f1ile
                            while (line != null)
                            {
                                //write the lie to console window
                                Console.WriteLine(line);
                                //Read the next line
                                line = ing_r.ReadLine();
                            }

                            //close the file
                            ing_r.Close();
                        }

                        if (x == "3")
                        {
                            Ingredients.DeleteIngredient();
                        }

                        // Display the list of ingredients.
                        
                        Console.WriteLine("If enough ingredients input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }

                    break;
                }
                case "2":
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    var x = "start";
                    // Create a new ingredient and add it to the list of dishes.
                    Dish dish = new Dish();
                    // Display the list of dishes.
                    var dishes = manager.GetDishes();

                    while (x != "stop")
                    {
                        Console.WriteLine("Chose the option: add-1, observe-2, remove-3");
                        x = Console.ReadLine();
                        if (x == "1")
                        {
                            Console.WriteLine("Please Input Dish_Name:");
                            var Name_dish = Console.ReadLine();
                            Console.WriteLine("Please Input Dish_Price:");
                            var Price_dish = Console.ReadLine();
                            // Create a new dish and add it to the list of Dushes.
                            Dish.name = Name_dish;
                            Dish.price = Price_dish;
                            Dishes.AddDish(dish);
                            const string directoryPath = @"D:\Git Hub\Homework\RMS_Finita\bin\Debug\net6.0";
                            if (System.IO.Directory.Exists(directoryPath))
                            {
                                StreamWriter dish_w = new StreamWriter("Dishes.txt", true);
                                dish_w.WriteLine((Dish.name, Dish.price).ToString());

                                dish_w.Dispose();
                                Console.WriteLine("Dishes List:");
                                //Pass the file path and file name to the StreamReader constructor
                                StreamReader dish_r = new StreamReader("Dishes.txt", true);
                                //Read the first line of text
                                var line = dish_r.ReadLine();
                                //Continue to read until you reach end of f1ile
                                while (line != null)
                                {
                                    //write the lie to console window
                                    Console.WriteLine(line);
                                    //Read the next line
                                    line = dish_r.ReadLine();
                                }

                                //close the file
                                dish_r.Close();
                            }
                            else
                            {
                                throw new Exception("error dishes");
                            }

                        }

                        if (x == "2")
                        {
                            Console.WriteLine("Dishes List:");
                            StreamReader dish_r = new StreamReader("Dishes.txt", true);
                            //Read the first line of text
                            var line = dish_r.ReadLine();
                            //Continue to read until you reach end of f1ile
                            while (line != null)
                            {
                                //write the lie to console window
                                Console.WriteLine(line);
                                //Read the next line
                                line = dish_r.ReadLine();
                            }

                            //close the file
                            dish_r.Close();
                        }

                        if (x == "3")
                        {
                            Dishes.DeleteDish();
                        }

                        Console.WriteLine("If you chose the dishes input stop to approve, if you want to continue " +
                                          "press enter:");
                        x = Console.ReadLine();
                    }

                    break;
                }
                case "3":
                {
                    // start.
                    RestaurantManager manager = new RestaurantManager();
                    var x = "start";
                    // Create a new order and add it to the list of orders.
                    Order order = new Order();
                    Orders.AddOrder(order);
                    // Display the list of orders.
                    List<Order> orders = manager.GetOrders();
                    while (x != "stop")
                    {
                        Console.WriteLine("Chose the option: add-1, observe-2, remove-3");
                        x = Console.ReadLine();
                        switch (x)
                        {
                            case "1":
                            {
                                // Prompt the user to input information.
                                Console.WriteLine("Please Input Order_List:");
                                var Name_order = Console.ReadLine();
                                Console.WriteLine("Please Input Order_Price:");
                                var Price_order = Console.ReadLine();
                                // Create a new order and add it to the list of Orders.
                                Order.name = Name_order;
                                Order.totalprice = Price_order;
                                Orders.AddOrder(order);
                                // Display the list of Orders.
                                const string directoryPath = @"D:\Git Hub\Homework\RMS_Finita\bin\Debug\net6.0";
                                if (System.IO.Directory.Exists(directoryPath))
                                {
                                    StreamWriter ordr_w = new StreamWriter("Order.txt", true);
                                    ordr_w.WriteLine((Order.name, Order.totalprice).ToString());

                                    ordr_w.Dispose();
                                    Console.WriteLine("Orders List:");
                                    //Pass the file path and file name to the StreamReader constructor
                                    StreamReader ordr_r = new StreamReader("Order.txt", true);
                                    //Read the first line of text
                                    var line = ordr_r.ReadLine();
                                    //Continue to read until you reach end of f1ile
                                    while (line != null)
                                    {
                                        //write the lie to console window
                                        Console.WriteLine(line);
                                        //Read the next line
                                        line = ordr_r.ReadLine();
                                    }

                                    //close the file
                                    ordr_r.Close();
                                }
                                else
                                {
                                    throw new Exception("error orders");
                                }

                                break;
                            }
                            case "2":
                            {
                                Console.WriteLine("Orders List:");
                                //Pass the file path and file name to the StreamReader constructor
                                StreamReader ordr_r = new StreamReader("Order.txt", true);
                                //Read the first line of text
                                var line = ordr_r.ReadLine();
                                //Continue to read until you reach end of f1ile
                                while (line != null)
                                {
                                    //write the lie to console window
                                    Console.WriteLine(line);
                                    //Read the next line
                                    line = ordr_r.ReadLine();
                                }

                                //close the file
                                ordr_r.Close();
                                break;
                            }
                            case "3":
                                Orders.DeleteOrder();
                                break;
                        }

                        Console.WriteLine("If you chose the order, input stop to approve, if you want to continue " +
                                          "press enter:");
                        x = Console.ReadLine();
                    }

                    break;
                }
                case "4":
                {
                    // Hire a new employee and add it to the list of employees.
                    RestaurantManager manager = new RestaurantManager();
                    // start
                    var x = "start";
                    // Create a new order and add it to the list of Employees.
                    Employee employee = new Employee();
                    Employees.AddEmployee(employee);
                    // Display the list of Employees.
                    List<Employee> employees = manager.GetEmployees();
                    while (x != "stop")
                    {
                        Console.WriteLine("Chose the option: add-1, observe-2, remove-3");
                        x = Console.ReadLine();
                        switch (x)
                        {
                            case "1":
                            {
                                // Prompt the user to input information.
                                Console.WriteLine("Please Input Employee_Name:");
                                var Name_employee = Console.ReadLine();
                                Console.WriteLine("Please Input Employee_Position:");
                                var Position_employee = Console.ReadLine();
                                // Create a new order and add it to the list of Employees.
                                Employee.name = Name_employee;
                                Employee.position = Position_employee;
                                Employees.AddEmployee(employee);
                                // Display the list of Employees.
                                const string directoryPath = @"D:\Git Hub\Homework\RMS_Finita\bin\Debug\net6.0";
                                if (System.IO.Directory.Exists(directoryPath))
                                {
                                    StreamWriter emp_w = new StreamWriter("Employee.txt", true);
                                    emp_w.WriteLine((Employee.name, Employee.position).ToString());
                                    
                                    emp_w.Dispose();
                                    Console.WriteLine("Employees List:");
                                    //Pass the file path and file name to the StreamReader constructor
                                    StreamReader emp_r = new StreamReader("Employee.txt", true);
                                    //Read the first line of text
                                    var line = emp_r.ReadLine();
                                    //Continue to read until you reach end of f1ile
                                    while (line != null)
                                    {
                                        //write the lie to console window
                                        Console.WriteLine(line);
                                        //Read the next line
                                        line = emp_r.ReadLine();
                                    }

                                    //close the file
                                    emp_r.Close();
                                }
                                else
                                {
                                    throw new Exception("error employee");
                                }

                                break;
                            }
                            case "2":
                            {
                                Console.WriteLine("Employees List:");
                                //Pass the file path and file name to the StreamReader constructor
                                StreamReader emp_r = new StreamReader("Employee.txt", true);
                                //Read the first line of text
                                var line = emp_r.ReadLine();
                                //Continue to read until you reach end of f1ile
                                while (line != null)
                                {
                                    //write the lie to console window
                                    Console.WriteLine(line);
                                    //Read the next line
                                    line = emp_r.ReadLine();
                                }

                                //close the file
                                emp_r.Close();
                                break;
                            }
                            case "3":
                                Employees.DeleteEmployee();
                                break;
                        }
                        Console.WriteLine("If you added employee, input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }
                    break;
                }

                case "5":
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    var x = "start";
                    // Create a new table and add it to the list of tables.
                    Table table = new Table();
                    Tables.AddTable(table);
                    // Display the list of orders.
                    List<Table> tables = manager.GetTables();

                    while (x != "stop")
                    {
                        Console.WriteLine("Chose the option: add-1, observe-2, remove-3");
                        x = Console.ReadLine();
                        switch (x)
                        {
                            case "1":
                            {
                                // Prompt the user to input information.
                                Console.WriteLine("Please Input Table_Number:");
                                var Table_number = Console.ReadLine();
                                Console.WriteLine("Please Input Table_Position:");
                                var Table_seat = Console.ReadLine();
                                // Create a new order and add it to the list of Employees.
                                Table.number = Table_number;
                                Table.seats = Table_seat;
                                Tables.AddTable(table);
                                // Display the list of Employees.
                                const string directoryPath = @"D:\Git Hub\Homework\RMS_Finita\bin\Debug\net6.0";
                                if (System.IO.Directory.Exists(directoryPath))
                                {
                                    StreamWriter emp_w = new StreamWriter("Table.txt", true);
                                    emp_w.WriteLine((Table.number, Table.seats).ToString());
                                    
                                    emp_w.Dispose();
                                    Console.WriteLine("Table List:");
                                    //Pass the file path and file name to the StreamReader constructor
                                    StreamReader tbl_r = new StreamReader("Table.txt", true);
                                    //Read the first line of text
                                    var line = tbl_r.ReadLine();
                                    //Continue to read until you reach end of f1ile
                                    while (line != null)
                                    {
                                        //write the lie to console window
                                        Console.WriteLine(line);
                                        //Read the next line
                                        line = tbl_r.ReadLine();
                                    }

                                    //close the file
                                    tbl_r.Close();
                                }
                                else
                                {
                                    throw new Exception("error table");
                                }

                                break;
                            }
                            case "2":
                            {
                                Console.WriteLine("Tables List:");
                                //Pass the file path and file name to the StreamReader constructor
                                StreamReader tbl_r = new StreamReader("Table.txt", true);
                                //Read the first line of text
                                var line = tbl_r.ReadLine();
                                //Continue to read until you reach end of f1ile
                                while (line != null)
                                {
                                    //write the line to console window
                                    Console.WriteLine(line);
                                    //Read the next line
                                    line = tbl_r.ReadLine();
                                }

                                //close the file
                                tbl_r.Close();
                                break;
                            }
                            case "3":
                                Tables.DeleteTable();
                                break;
                        }
                        Console.WriteLine("If you added table, input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }

                    break;
                }

                case "6":
                {
                    // start
                    RestaurantManager manager = new RestaurantManager();
                    var x = "start";
                    // Create a new table and add it to the list of tables.
                    Customer customer = new Customer();
                    Customers.AddCustomer(customer);
                    // Display the list of orders.
                    List<Customer> customers = manager.GetCustomers();

                    while (x != "stop")
                    {
                        Console.WriteLine("Chose the option: add-1, observe-2, remove-3");
                        x = Console.ReadLine();
                        switch (x)
                        {
                            case "1":
                            {
                                // Prompt the user to input information.
                                Console.WriteLine("Please Input Customer_name:");
                                var Customer_name = Console.ReadLine();
                                Console.WriteLine("Please Input Customer_phone_number:");
                                var Customer_phone_number = Console.ReadLine();
                                // Create a new order and add it to the list of Customers.
                                Customer.name = Customer_name;
                                Customer.phoneNumber = Customer_phone_number;
                                Customers.AddCustomer(customer);
                                // Display the list of Customers.
                                const string directoryPath = @"D:\Git Hub\Homework\RMS_Finita\bin\Debug\net6.0";
                                if (System.IO.Directory.Exists(directoryPath))
                                {
                                    StreamWriter cst_w = new StreamWriter("Customer.txt", true);
                                    cst_w.WriteLine((Customer.name, Customer.phoneNumber).ToString());
                                    
                                    cst_w.Dispose();
                                    
                                    Console.WriteLine("Customers List:");
                                    //Pass the file path and file name to the StreamReader constructor
                                    StreamReader cst_r = new StreamReader("Customer.txt", true);
                                    //Read the first line of text
                                    var line = cst_r.ReadLine();
                                    //Continue to read until you reach end of f1ile
                                    while (line != null)
                                    {
                                        //write the line to console window
                                        Console.WriteLine(line);
                                        //Read the next line
                                        line = cst_r.ReadLine();
                                    }

                                    //close the file
                                    cst_r.Close();
                                }
                                else
                                {
                                    throw new Exception("error table");
                                }

                                break;
                            }
                            case "2":
                            {
                                Console.WriteLine("Customers List:");
                                //Pass the file path and file name to the StreamReader constructor
                                StreamReader cst_r = new StreamReader("Customer.txt", true);
                                //Read the first line of text
                                var line = cst_r.ReadLine();
                                //Continue to read until you reach end of f1ile
                                while (line != null)
                                {
                                    //write the line to console window
                                    Console.WriteLine(line);
                                    //Read the next line
                                    line = cst_r.ReadLine();
                                }

                                //close the file
                                cst_r.Close();
                                break;
                            }
                            case "3":
                                Customers.DeleteCustomer();
                                break;
                        }
                        Console.WriteLine("If you added customer, input stop, if you want to continue press enter:");
                        x = Console.ReadLine();
                    }

                    break;
                }
            }
        }
    }

// Create a struct to store information about an ingredient.
    public struct Ingredient
    {
        public string Name  { get; }
        public string Price { get; }
        public string Amount { get; }
        
        public Ingredient(string name, string price, string amount)
        {
            this.Price = price;
            this.Name = name;
            this.Amount = amount;
        }

        public static string name { get; set; }
        public static string price { get; set; }
        public static string amount { get; set; }

    }
    // Create a struct to store information about a dish.
    public struct Dish
    {
        public string Name { get; }
        public string Price { get; }

        public Dish(string name, string price)
        {
            this.Price = price;
            this.Name = name;
        }

        public static string name { get; set; }
        public static string price { get; set; }

    }

    // Create a struct to store information about an order.
    public struct Order
    {
        public string Name { get; }
        public string TotalPrice { get; }
        
        public Order(string name, string totalprice)
        {
            this.Name = name;
            this.TotalPrice = totalprice;
        }

        public static string name { get; set; }
        public static string totalprice { get; set; } }
    }

    // Create a struct to store information about an employee.
    public struct Employee
    {
        public string Name { get; }
        public string Position { get; }
        
        public Employee (string name, string position)
        {
            this.Name = name;
            this.Position = position;
        }

        public static string name { get; set; }
        public static string position { get; set; }
    }

    // Create a struct to store information about a table.
    public struct Table
    {
        public string Number { get; }
        public string Seats { get; }
        
        public Table(string number, string seats)
        {
            this.Number = number;
            this.Seats = seats;
        }

        public static string number { get; set; }
        public static string seats { get; set; }
    }

    // Create a struct to store information about a customer.
    public struct Customer
    {
        public string Name { get; }
        public string PhoneNumber { get; }
        public Customer(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public static string name { get; set; }
        public static string phoneNumber { get; set; }
    }
    