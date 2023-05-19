using RMS_Finita;

namespace RMS_Finita
{
    public abstract class Customers : RestaurantManager
    {
        // Add a customer to the list of customers.
        public static void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
        public static void DeleteCustomer()
        {
            const string filePath = "Customer.txt";
            Console.WriteLine("Type customer you want to get rid of in such format (Name, phone_number):");
            var ing = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
                            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == ing)
                {
                    lines[i] = string.Empty; 
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Else customers:");
            StreamReader cst_r = new StreamReader(filePath, true);
            //Read the first line of text
            var line = cst_r.ReadLine();
            //Continue to read until you reach end of f1ile
            while (line != null)
            {
                //write the lie to console window
                Console.WriteLine(line);
                //Read the next line
                line = cst_r.ReadLine();
            }
            //close the file
            cst_r.Close();
        }

    }
}