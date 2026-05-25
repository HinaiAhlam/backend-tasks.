using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingSystem
{
    public class Room
    {
        public int Id { get; set; }
        public required string RoomNumber { get; set; }
        public required string Type { get; set; }
        public double PricePerNight { get; set; }
        public bool IsBooked { get; set; }
        public int Floor { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>
            {
                new Room { Id = 1, RoomNumber = "101", Type = "Single", PricePerNight = 500, IsBooked = false, Floor = 1 },
                new Room { Id = 2, RoomNumber = "102", Type = "Double", PricePerNight = 800, IsBooked = true, Floor = 1 },
                new Room { Id = 3, RoomNumber = "201", Type = "Suite", PricePerNight = 1500, IsBooked = false, Floor = 2 },
                new Room { Id = 4, RoomNumber = "202", Type = "Single", PricePerNight = 550, IsBooked = true, Floor = 2 },
                new Room { Id = 5, RoomNumber = "301", Type = "Double", PricePerNight = 900, IsBooked = false, Floor = 3 },
                new Room { Id = 6, RoomNumber = "302", Type = "Suite", PricePerNight = 1700, IsBooked = true, Floor = 3 },
                new Room { Id = 7, RoomNumber = "401", Type = "Single", PricePerNight = 600, IsBooked = false, Floor = 4 },
                new Room { Id = 8, RoomNumber = "402", Type = "Double", PricePerNight = 950, IsBooked = false, Floor = 4 }
            };


            Console.WriteLine("Available Rooms:");

            var availableRooms = rooms.Where(r => !r.IsBooked).Select(r => r.RoomNumber);
            foreach (var num in availableRooms) Console.WriteLine(num);

            Console.WriteLine($"\nBooked Rooms Count: {rooms.Count(r => r.IsBooked)}");

            Console.WriteLine($"Average Price: {rooms.Average(r => r.PricePerNight)}");

            var mostExpensive = rooms.OrderByDescending(r => r.PricePerNight).FirstOrDefault();
            if (mostExpensive != null) Console.WriteLine($"Most Expensive Room: Room {mostExpensive.RoomNumber}");


            int floorNum = 2;
            Console.WriteLine($"\nRooms on Floor {floorNum}:");
            foreach (var r in rooms.Where(r => r.Floor == floorNum)) Console.WriteLine(r.RoomNumber);

            string typeSearch = "Single";
            Console.WriteLine($"\nRooms of type {typeSearch}:");
            foreach (var r in rooms.Where(r => r.Type == typeSearch)) Console.WriteLine(r.RoomNumber);

            Console.WriteLine("\nRooms grouped by Type:");
            foreach (var group in rooms.GroupBy(r => r.Type))
            {
                Console.WriteLine($"Type: {group.Key}");
                foreach (var r in group) Console.WriteLine($"- {r.RoomNumber}");
            }

            Console.WriteLine("\nAvailable rooms sorted by price:");
            foreach (var r in rooms.Where(r => !r.IsBooked).OrderBy(r => r.PricePerNight))
                Console.WriteLine($"{r.RoomNumber} - {r.PricePerNight}");

            var cheapest = rooms.OrderBy(r => r.PricePerNight).FirstOrDefault();
            if (cheapest != null) Console.WriteLine($"\nCheapest room: {cheapest.RoomNumber}");

            Console.WriteLine("\nRooms with price > 1000:");
            foreach (var r in rooms.Where(r => r.PricePerNight > 1000))
                Console.WriteLine($"{r.RoomNumber} ({r.Type})");
        }
    }
}