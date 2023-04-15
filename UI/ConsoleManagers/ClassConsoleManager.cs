using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class ClassConsoleManager : ConsoleManager<IClassService, FitnessClass>, IConsoleManager<FitnessClass>
    {
        public ClassConsoleManager(IClassService classService) : base(classService)
        {
        
        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllClassesAsync },
                { "2", CreateClassAsync },
                { "3", UpdateClassAsync },
                { "4", DeleteClassAsync }
            };

            while (true)
            {
                Console.WriteLine("\nClass operations:");
                Console.WriteLine("1. Display all classes");
                Console.WriteLine("2. Create a new class");
                Console.WriteLine("3. Update a class");
                Console.WriteLine("4. Delete a class");
                Console.WriteLine("5. Exit");

                Console.Write("Enter the operation number: ");
                string input = Console.ReadLine();

                if (input == "5")
                {
                    break;
                }

                if (actions.ContainsKey(input))
                {
                    await actions[input]();
                }
                else
                {
                    Console.WriteLine("Invalid operation number.");
                }
            }
        }
        
        public async Task DisplayAllClassesAsync()
        {
            try
            {
                IEnumerable<FitnessClass> classes = await Service.GetAllAsync();
                foreach (var c in classes)
                {
                    Console.WriteLine($"Class ID: {c.Id}");
                    Console.WriteLine($"Class Type: {c.Type}");
                    Console.WriteLine($"Trainer ID: {c.TrainerId}");
                    Console.WriteLine($"Date and Time: {c.DateAndTime}");
                    Console.WriteLine($"Capacity: {c.Capacity}");
                    Console.WriteLine($"Attendees: {c.Attendees.Count}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DisplayAllClassesAsync: {ex.Message}");
            }
        }

        public async Task CreateClassAsync()
        {
            try
            {
                Console.WriteLine("Enter the class type: ");
                string type = Console.ReadLine();

                Console.WriteLine("Enter the trainer ID: ");
                Guid trainerId = Guid.Parse(Console.ReadLine());

                Console.WriteLine("Enter the date and time (yyyy-MM-dd HH:mm:ss): ");
                DateTime dateAndTime = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter the capacity: ");
                int capacity = int.Parse(Console.ReadLine());

                FitnessClass newClass = new FitnessClass
                {
                    Type = type,
                    TrainerId = trainerId,
                    DateAndTime = dateAndTime,
                    Capacity = capacity
                };

                await Service.Add(newClass);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateClassAsync: {ex.Message}");
            }
        }

        public async Task UpdateClassAsync()
        {
            try
            {
                Console.WriteLine("Enter the ID of the class you want to update: ");
                Guid id = Guid.Parse(Console.ReadLine());

                FitnessClass classToUpdate = await Service.GetById(id);

                Console.WriteLine("Enter the new class type (leave blank to keep current): ");
                string newType = Console.ReadLine();
                if (!string.IsNullOrEmpty(newType))
                {
                    classToUpdate.Type = newType;
                }

                Console.WriteLine("Enter the new trainer ID (leave blank to keep current): ");
                string newTrainerIdStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTrainerIdStr))
                {
                    classToUpdate.TrainerId = Guid.Parse(newTrainerIdStr);

                    Console.WriteLine(
                        "Enter the new date and time (yyyy-MM-dd HH:mm:ss) (leave blank to keep current): ");
                    string newDateAndTimeStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newDateAndTimeStr))
                    {
                        classToUpdate.DateAndTime = DateTime.Parse(newDateAndTimeStr);
                    }

                    Console.WriteLine("Enter the new capacity (leave blank to keep current): ");
                    string newCapacityStr = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newCapacityStr))
                    {
                        classToUpdate.Capacity = int.Parse(newCapacityStr);
                    }

                    await Service.Update(classToUpdate);
                }
                catch (Exception ex);
                {
                    Console.WriteLine($"Error in UpdateClassAsync: {ex.Message}");
                }
            }

            public async Task DeleteClassAsync()
            {
                try
                {
                    Console.WriteLine("Enter the ID of the class you want to delete: ");
                    Guid id = Guid.Parse(Console.ReadLine());

                    await Service.DeleteById(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in DeleteClassAsync: {ex.Message}");
                }
            }
        }
    }
}