using static RMS_Finita.Rms.Ingredient;

namespace RMS_Finita
{
    // Create a new instance of the RestaurantManager class.

    public class RestaurantManager : Rms
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>();
        public static List<Dish> Dishes = new List<Dish>();
        public static List<Employee> Employees = new List<Employee>();
        public static List<Table> Tables = new List<Table>();
        public static List<Customer> Customers = new List<Customer>();
        public static List<Order> Orders = new List<Order>();
    
        
        // Return the list of ingredients.
        public List<Ingredient> GetIngredients()
        {
            return Ingredients;
        }
        
        // Return the list of dishes.
        public List<Dish> GetDishes()
        {
            return Dishes;
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