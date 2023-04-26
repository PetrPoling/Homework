using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class SubscriptionConsoleManager : ConsoleManager<ISubscriptionService, Subscription>,
        IConsoleManager<Subscription>
    {
        private readonly MemberConsoleManager _memberConsoleManager;

        public SubscriptionConsoleManager(ISubscriptionService subscriptionService,
            MemberConsoleManager memberConsoleManager) : base(subscriptionService)
        {
            _memberConsoleManager = memberConsoleManager;
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllSubscriptionsAsync },
                { "2", CreateSubscriptionAsync },
                { "3", UpdateSubscriptionAsync },
                { "4", DeleteSubscriptionAsync },
            };

            while (true)
            {
                Console.WriteLine("\nSubscription operations:");
                Console.WriteLine("1. Display all subscriptions");
                Console.WriteLine("2. Create a new subscription");
                Console.WriteLine("3. Update a subscription");
                Console.WriteLine("4. Delete a subscription");
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

        public async Task DisplayAllSubscriptionsAsync()
        {
            var subscriptions = await _subscriptionService.GetAllAsync();

            if (subscriptions.Count == 0)
            {
                Console.WriteLine("There are no subscriptions to display.");
                return;
            }

            Console.WriteLine("Subscriptions:");
            Console.WriteLine("ID\tName\t\t\tPrice\tDuration");

            foreach (var subscription in subscriptions)
            {
                Console.WriteLine(
                    $"{subscription.Id}\t{subscription.Name}\t\t${subscription.Price}\t{subscription.DurationInMonths} months");
            }
        }


        public async Task CreateSubscriptionAsync()
        {
            // Get all members to display to the user
            var members = await _memberService.GetAllAsync();

            // Display members to the user and ask for member ID
            Console.WriteLine("\nCreate a new subscription");
            Console.WriteLine("Enter the ID of the member:");
            foreach (var member in members)
            {
                Console.WriteLine($"{member.Id}. {member.Name}");
            }

            // Get the selected member
            int memberId;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out memberId))
                {
                    var selectedMember = await _memberService.GetByIdAsync(memberId);
                    if (selectedMember != null)
                    {
                        // Create a new subscription
                        var subscription = new Subscription
                        {
                            Member = selectedMember
                        };

                        // Get the subscription duration
                        Console.WriteLine("Enter the subscription duration in months:");
                        while (true)
                        {
                            input = Console.ReadLine();
                            DateTime duration;
                            if (!int.TryParse(input, out duration) || duration <= 0)
                            {
                                subscription.EndDate = duration;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid duration. Please enter a positive integer.");
                            }
                        }

                        // Save the new subscription
                        await _subscriptionService.CreateAsync(subscription);
                        Console.WriteLine($"Subscription created with ID {subscription.Id}.");
                        break;
                    }
                }

                Console.WriteLine("Invalid member ID. Please enter a valid ID.");
            }
        }


        public async Task UpdateSubscriptionAsync()
{
    Console.Write("Enter the ID of the subscription to update: ");
    string idString = Console.ReadLine();

    if (Guid.TryParse(idString, out Guid id))
    {
        Subscription subscription = await _subscriptionService.GetByIdAsync(id);

        if (subscription != null)
        {
            Console.WriteLine($"Current subscription: {subscription}");

            Guid memberId = await GetMemberIdAsync();
            SubscriptionType type = await GetSubscriptionTypeAsync();
            DateTime startDate = await GetStartDateAsync();
            DateTime endDate = await GetEndDateAsync();

            Subscription updatedSubscription = new Subscription
            {
                Id = subscription.Id,
                Member = await _memberService.GetByIdAsync(memberId),
                Type = type,
                StartDate = startDate,
                EndDate = endDate,
                IsActive = subscription.IsActive
            };

            await _subscriptionService.UpdateAsync(updatedSubscription);

            Console.WriteLine("Subscription updated successfully.");
        }
        else
        {
            Console.WriteLine("Subscription not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid subscription ID format.");
    }
}

private async Task<Guid> GetMemberIdAsync()
{
    Guid memberId;

    do
    {
        Console.Write("Enter the ID of the member to associate with this subscription: ");
        string memberIdString = Console.ReadLine();

        if (Guid.TryParse(memberIdString, out memberId))
        {
            Member member = await _memberService.GetByIdAsync(memberId);

            if (member != null)
            {
                return memberId;
            }
            else
            {
                Console.WriteLine("Member not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid member ID format.");
        }
    } while (true);
}

private async Task<SubscriptionType> GetSubscriptionTypeAsync()
{
    SubscriptionType type;

    do
    {
        Console.Write("Enter the subscription type (Monthly, Quarterly, or Annual): ");
        string typeString = Console.ReadLine();

        if (Enum.TryParse<SubscriptionType>(typeString, out type))
        {
            return type;
        }
        else
        {
            Console.WriteLine("Invalid subscription type.");
        }
    } while (true);
}

private async Task<DateTime> GetStartDateAsync()
{
    DateTime startDate;

    do
    {
        Console.Write("Enter the start date (MM/DD/YYYY): ");
        string startDateString = Console.ReadLine();

        if (DateTime.TryParse(startDateString, out startDate))
        {
            return startDate;
        }
        else
        {
            Console.WriteLine("Invalid start date format.");
        }
    } while (true);
}

private async Task<DateTime> GetEndDateAsync()
{
    DateTime endDate;

    do
    {
        Console.Write("Enter the end date (MM/DD/YYYY): ");
        string endDateString = Console.ReadLine();

        if (DateTime.TryParse(endDateString, out endDate))
        {
            return endDate;
        }
        else
        {
            Console.WriteLine("Invalid end date format.");
        }
    } while (true);
}


        public async Task DeleteSubscriptionAsync()
        {
            Console.Write("Enter the ID of the subscription to delete: ");
            string idString = Console.ReadLine();

            if (Guid.TryParse(idString, out Guid id))
            {
                Subscription subscription = await _subscriptionService.GetByIdAsync(id);

                if (subscription != null)
                {
                    await _subscriptionService.DeleteAsync(subscription);

                    Console.WriteLine("Subscription deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Subscription not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid subscription ID format.");
            }
        }

    }
}