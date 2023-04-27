using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Abstractions.Interfaces;
using Core.Models;
using UI.Interfaces;

namespace UI.ConsoleManagers
{
    public class BookingConsoleManager : ConsoleManager<IBookingService, Booking>, IConsoleManager<Booking>
    {
        private readonly ClassConsoleManager _classConsoleManager;
        private readonly MemberConsoleManager _memberConsoleManager;
        private object _serviceBooking;

        public BookingConsoleManager(IBookingService bookingService, ClassConsoleManager classConsoleManager, MemberConsoleManager memberConsoleManager)
            : base(bookingService)
        {
            _classConsoleManager = classConsoleManager;
            _memberConsoleManager = memberConsoleManager;
        }

        public override async Task PerformOperationsAsync()
        {
            Dictionary<string, Func<Task>> actions = new Dictionary<string, Func<Task>>
            {
                { "1", DisplayAllBookingsAsync },
                { "2", CreateBookingAsync },
                { "3", UpdateBookingAsync },
                { "4", DeleteBookingAsync },
            };

            while (true)
            {
                Console.WriteLine("\nBooking operations:");
                Console.WriteLine("1. Display all bookings");
                Console.WriteLine("2. Create a new booking");
                Console.WriteLine("3. Update a booking");
                Console.WriteLine("4. Delete a booking");
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
        
        public async Task DisplayAllBookingsAsync()
        {
            List<Booking> bookings = await Service.GetAll();
            Console.WriteLine();
            
            foreach (Booking booking in bookings)
            {
                Console.WriteLine($"Booking Id: {booking.Id}");
                Console.WriteLine($"Class Id: {booking.Class.Id}");
                Console.WriteLine($"Member Id: {booking.Member.Id}");
                Console.WriteLine($"Booking IsConfirmed: {booking.IsConfirmed}");
                Console.WriteLine();
            }
        }
        public async Task CreateBookingAsync()
        {
            Console.WriteLine("\nCreating a new booking...");
    
            // Ask the user to enter the member ID and class ID
            Console.Write("Enter the member ID: ");
            string memberIdString = Console.ReadLine();
            Guid memberId;

            while (!Guid.TryParse(memberIdString, out memberId))
            {
                Console.WriteLine("Invalid member ID. Please enter a valid GUID.");
                Console.Write("Enter the member ID: ");
                memberIdString = Console.ReadLine();
            }

            Console.Write("Enter the class ID: ");
            string classIdString = Console.ReadLine();
            Guid classId;

            while (!Guid.TryParse(classIdString, out classId))
            {
                Console.WriteLine("Invalid class ID. Please enter a valid GUID.");
                Console.Write("Enter the class ID: ");
                classIdString = Console.ReadLine();
            }
    
            // Create the booking
            try
            {
                var booking = await Service.BookClass(memberId, classId);
                Console.WriteLine($"Booking created successfully. ID: {booking.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating booking: {ex.Message}");
            }
        }


        public async Task UpdateBookingAsync()
        {
                Console.WriteLine("\nUpdating a booking...");
    
                // Ask the user to enter the booking ID and confirmation status
                Console.Write("Enter the booking ID: ");
                string bookingIdString = Console.ReadLine();
                Guid bookingId;

                while (!Guid.TryParse(bookingIdString, out bookingId))
                {
                    Console.WriteLine("Invalid booking ID. Please enter a valid GUID.");
                    Console.Write("Enter the booking ID: ");
                    bookingIdString = Console.ReadLine();
                }

                Console.Write("Enter the confirmation status (confirmed, pending, cancelled): ");
                string confirmationStatus = Console.ReadLine();
    
                // Update the booking
                try
                {
                    await _serviceBooking.ConfirmBooking(bookingId);
                    Console.WriteLine($"Booking updated successfully. ID: {bookingId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating booking: {ex.Message}");
                }

        }
        
        public async Task DeleteBookingAsync()
        {
            Console.Write("Enter the ID of the booking to delete: ");
            Guid id = Guid.Parse(Console.ReadLine());

            try
            {
                await _serviceBooking.DeleteAsync(id);
                Console.WriteLine($"Booking with ID {id} has been deleted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting booking: {ex.Message}");
            }
        }

    }
}