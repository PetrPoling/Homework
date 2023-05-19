using RMS_Finita;

namespace RMS_Finita
{
    public abstract class Ingredients : RestaurantManager
    {
        // Add an ingredient to the list of ingredients.
        public static void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public static void DeleteIngredient()
        {
            const string filePath = "Ingredient.txt";
            Console.WriteLine("Type ingredient you want to delete in such format (Name, price, amount):");
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
            Console.WriteLine("Else dishes:");
            StreamReader ing_r = new StreamReader(filePath, true);
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

    }
}