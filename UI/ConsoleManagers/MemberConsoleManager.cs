using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class MemberConsoleManager : ConsoleManager<IMemberService, Member>, IConsoleManager<Member>
    {
        public MemberConsoleManager(IMemberService memberService) : base(memberService)
        {
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllMembersAsync },
                { "2", AddMemberAsync },
                { "3", UpdateMemberAsync },
                { "4", DeleteMemberAsync },
            };

            while (true)
            {
                Console.WriteLine("\nMember operations:");
                Console.WriteLine("1. Display all members");
                Console.WriteLine("2. Add a new member");
                Console.WriteLine("3. Update a member");
                Console.WriteLine("4. Delete a member");
                Console.WriteLine("5. Exit");

                Console.Write("Enter the operation number: ");
                var input = Console.ReadLine();

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

        public async Task DisplayAllMembersAsync()
        {
            var members = await _serviceMember.GetAllAsync();
            Console.WriteLine("All Members:");
            foreach (var member in members)
            {
                Console.WriteLine($"ID: {member.Id}, Name: {member.Name}, Email: {member.Email}");
            }
        }

        public async Task AddMemberAsync()
        {
            Console.Write("Enter the member name: ");
            var name = Console.ReadLine();

            Console.Write("Enter the member email: ");
            var email = Console.ReadLine();

            var member = new Member { Name = name, Email = email };
            await _serviceMember.AddAsync(member);

            Console.WriteLine($"New member with ID {member.Id} has been added.");
        }

        public async Task UpdateMemberAsync()
        {
            Console.Write("Enter the member ID: ");
            var id = Guid.Parse(Console.ReadLine());

            var member = await _serviceMember.GetByIdAsync(id);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.WriteLine($"Current name: {member.Name}, Current email: {member.Email}");

            Console.Write("Enter the new name (or press enter to keep the current value): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                member.Name = name;
            }

            Console.Write("Enter the new email (or press enter to keep the current value): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email))
            {
                member.Email = email;
            }

            await _serviceMember.Member.UpdateAsync(id, member);

            Console.WriteLine($"Member with ID {id} has been updated.");
        }

        public async Task DeleteMemberAsync()
        {
            Console.Write("Enter the member ID: ");
            var id = Guid.Parse(Console.ReadLine());

            var member = await _serviceMember.GetByIdAsync(id);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            await _serviceMember.DeleteAsync(id);

            Console.WriteLine($"Member with ID {id} has been deleted.");
        }
    }
}