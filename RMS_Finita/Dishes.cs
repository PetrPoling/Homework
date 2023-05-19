using RMS_Finita;

namespace RMS_Finita
{
    public abstract class Dishes : RestaurantManager
    {
        public static void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }
    
        public static void DeleteDish()
        {
            const string filePath = "Dishes.txt";
            Console.WriteLine("Type dish you want to delete in such format (Dish, price):");
            var rem = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);
                            
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == rem)
                {
                    lines[i] = string.Empty; 
                }
            }
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Else dishes:");
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
    }
}