using RMS_Finita;

namespace RMS_Finita
{
    public abstract class Employees : RestaurantManager
    {
        // Add an employee to the list of employees.
        public static void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public static void DeleteEmployee()
        {
            const string filePath = "Employee.txt";
            Console.WriteLine("Type employee you want to fire in such format (Name, position):");
            var emp = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
                            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == emp)
                {
                    lines[i] = string.Empty; 
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Else employees:");
            StreamReader emp_r = new StreamReader(filePath, true);
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

    }
}