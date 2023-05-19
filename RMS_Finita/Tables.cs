using RMS_Finita;

namespace RMS_Finita
{
    public abstract class Tables : RestaurantManager
    {
        // Add a table to the list of tables.
        public static void AddTable(Table table)
        {
            Tables.Add(table);
        }
        public static void DeleteTable()
        {
            const string filePath = "Table.txt";
            Console.WriteLine("Type table you want to delete in such format (Name, seats):");
            var tbl = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
                            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == tbl)
                {
                    lines[i] = string.Empty; 
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Else tables:");
            StreamReader tbl_r = new StreamReader(filePath, true);
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
    }
}