using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class TrainerConsoleManager : ConsoleManager<ITrainerService, Trainer>, IConsoleManager<Trainer>
    {
        public TrainerConsoleManager(ITrainerService trainerService) : base(trainerService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllTrainersAsync },
                { "2", CreateTrainerAsync },
                { "3", UpdateTrainerAsync },
                { "4", DeleteTrainerAsync },
            };

            while (true)
            {
                Console.WriteLine("\nTrainer operations:");
                Console.WriteLine("1. Display all trainers");
                Console.WriteLine("2. Create a new trainer");
                Console.WriteLine("3. Update a trainer");
                Console.WriteLine("4. Delete a trainer");
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

        public async Task<Trainer> AddTrainer(Trainer trainer)
        {
            if (trainer == null)
            {
                throw new ArgumentNullException(nameof(trainer));
            }

            var existingTrainer =
                await _trainerRepository.GetTrainerByFullNameAsync(trainer.FirstName, trainer.LastName);

            if (existingTrainer != null)
            {
                throw new InvalidOperationException("Trainer with the same name already exists.");
            }

            return await base.AddAsync(trainer);
        }

        public async Task<List<Trainer>> GetTrainersBySpecialization(string specialization)
        {
            if (string.IsNullOrEmpty(specialization))
            {
                throw new ArgumentNullException(nameof(specialization));
            }

            return await _trainerRepository.GetTrainersBySpecializationAsync(specialization);
        }

        public async Task<List<Trainer>> GetAvailableTrainers(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            var allTrainers = await base.GetAllAsync();
            var availableTrainers = new List<Trainer>();

            foreach (var trainer in allTrainers)
            {
                if (trainer.AvailableDates.Contains(date))
                {
                    availableTrainers.Add(trainer);
                }
            }

            return availableTrainers;
        }

        public async Task<bool> CheckTrainerAvailability(Guid trainerId, DateTime date, TimeSpan startTime,
            TimeSpan endTime)
        {
            if (trainerId == null)
            {
                throw new ArgumentNullException(nameof(trainerId));
            }

            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            if (startTime == null)
            {
                throw new ArgumentNullException(nameof(startTime));
            }

            if (endTime == null)
            {
                throw new ArgumentNullException(nameof(endTime));
            }

            var trainer = await base.GetByIdAsync(trainerId);

            if (trainer == null)
            {
                throw new InvalidOperationException("Trainer with the specified ID was not found.");
            }

            if (!trainer.AvailableDates.Contains(date))
            {
                return false;
            }

            var occupiedSlots = await _trainerRepository.GetOccupiedTimeSlotsAsync(trainerId, date);

            return !occupiedSlots.Any(slot => (startTime >= slot.StartTime && startTime < slot.EndTime)
                                              || (endTime > slot.StartTime && endTime <= slot.EndTime));
        }

        public async Task AssignTrainerToClass(Guid trainerId, Guid classId)
        {
            if (trainerId == null)
            {
                throw new ArgumentNullException(nameof(trainerId));
            }

            if (classId == null)
            {
                throw new ArgumentNullException(nameof(classId));
            }

            var trainer = await base.GetByIdAsync(trainerId);

            if (trainer == null)
            {
                throw new InvalidOperationException("Trainer with the specified ID was not found.");
            }

            var classToAssign = await _trainerRepository.GetClassByIdAsync(classId);

            if (classToAssign == null)
            {
                throw new InvalidOperationException("Class with the specified ID was not found.");
            }

            if (!await CheckTrainerAvailability(trainerId, classToAssign.Date, classToAssign.StartTime,
                    classToAssign.EndTime))
            {
                throw new InvalidOperationException("Trainer is not available at the specified time.");
            }

            classToAssign.TrainerId = trainerId;

            await _trainerRepository.UpdateClassAsync(classToAssign);
        }
    }
}

}