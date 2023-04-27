using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class UserConsoleManager : ConsoleManager<IUserService, User>, IConsoleManager<User>
    {
        public UserConsoleManager(IUserService userService) : base(userService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllUsersAsync },
                { "2", CreateUserAsync },
                { "3", UpdateUserAsync },
                { "4", DeleteUserAsync },
            };

            while (true)
            {
                Console.WriteLine("\nUser operations:");
                Console.WriteLine("1. Display all users");
                Console.WriteLine("2. Create a new user");
                Console.WriteLine("3. Update a user");
                Console.WriteLine("4. Delete a user");
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

        public async Task DisplayAllUsersAsync()
        {
            var users = await _service.GetAllAsync();
            Console.WriteLine($"{"Id",-10} {"Username",-20} {"Role",-15} {"Locked",-10}");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id,-10} {user.Username,-20} {user.Role,-15} {user.IsLocked,-10}");
            }
        }

        public async Task CreateUserAsync()
        {
            var user = new User();
            Console.Write("Enter username: ");
            user.Username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter user role (client, trainer, administrator): ");
            string roleString = Console.ReadLine();
            if (!Enum.TryParse<UserRole>(roleString, out UserRole role))
            {
                Console.WriteLine("Invalid role specified.");
                return;
            }

            user.Role = role;

            user = await _service.CreateAsync(user, password);
            Console.WriteLine($"User with ID {user.Id} has been created.");
        }

        public async Task UpdateUserAsync()
        {
            Console.Write("Enter user ID to update: ");
            string idString = Console.ReadLine();
            if (!Guid.TryParse(idString, out Guid id))
            {
                Console.WriteLine("Invalid ID specified.");
                return;
            }

            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found.");
                return;
            }

            Console.Write($"Enter new username (current: {user.Username}): ");
            string username = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(username))
            {
                user.Username = username;
            }

            Console.Write("Enter new password: ");
            string password = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(password))
            {
                await _service.UpdatePassword(id, password);
            }

            Console.Write($"Enter new user role (current: {user.Role}): ");
            string roleString = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(roleString))
            {
                if (!Enum.TryParse<UserRole>(roleString, out UserRole role))
                {
                    Console.WriteLine("Invalid role specified.");

                    return;
                }

                user.Role = role;
            }

            await _service.UpdateAsync(user);
            Console.WriteLine($"User with ID {id} has been updated.");
        }

        public async Task DeleteUserAsync()
        {
            Console.Write("Enter user ID to delete: ");
            string idString = Console.ReadLine();
            if (!Guid.TryParse(idString, out Guid id))
            {
                Console.WriteLine("Invalid ID specified.");
                return;
            }

            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                Console.WriteLine($"User with ID {id} not found.");
                return;
            }

            await _service.DeleteAsync(id);
            Console.WriteLine($"User with ID {id} has been deleted.");
        }
    }
}