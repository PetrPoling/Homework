using RMS_Finita;

namespace RMS_Finita
{
    public abstract class Orders : RestaurantManager
    {
        // Add an order to the list of orders.
        public static void AddOrder(Order order)
        {
            Orders.Add(order);
        }
        public static void DeleteOrder()
        {
            const string filePath = "Order.txt";
            Console.WriteLine("Type ingredient you want to delete in such format (Name, total_price):");
            var ordr = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
                            
            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i] == ordr)
                {
                    lines[i] = string.Empty; 
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Else dishes:");
            StreamReader ordr_r = new StreamReader(filePath, true);
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
    }
}