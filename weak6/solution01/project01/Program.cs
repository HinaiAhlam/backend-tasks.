using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using project01;

using (var db = new AppDbContext())
{
    if (!db.Stations.Any())
    {
        var s1 = new Station { Name = "Ramses", Location = "Cairo" };
        var s2 = new Station { Name = "Attaba", Location = "Cairo" };
        var t1 = new Train { Number = "T1", Capacity = 100 };
        var t2 = new Train { Number = "T2", Capacity = 150 };

        db.Stations.AddRange(s1, s2);
        db.Trains.AddRange(t1, t2);
        db.SaveChanges();

        db.Tickets.AddRange(
            new Ticket { PassengerName = "Ahmed", Price = 25, Train = t1, Station = s1, TravelDate = DateTime.Now },
            new Ticket { PassengerName = "Sara", Price = 15, Train = t2, Station = s2, TravelDate = DateTime.Now },
            new Ticket { PassengerName = "Ali", Price = 30, Train = t1, Station = s2, TravelDate = DateTime.Now },
            new Ticket { PassengerName = "Mona", Price = 22, Train = t2, Station = s1, TravelDate = DateTime.Now },
            new Ticket { PassengerName = "Omar", Price = 10, Train = t1, Station = s1, TravelDate = DateTime.Now }
        );
        db.SaveChanges();
    }

    Console.WriteLine("==========================================");
    Console.WriteLine("       Metro Ticket Booking System        ");
    Console.WriteLine("==========================================\n");

    var allTickets = db.Tickets.Include(t => t.Train).Include(t => t.Station).ToList();
    foreach (var t in allTickets)
    {
        Console.WriteLine($"Passenger: {t.PassengerName,-8} | Train: {t.Train.Number,-3} | Station: {t.Station.Name,-7} | Price: {t.Price:C}");
    }

    Console.WriteLine("\n--- LINQ Queries Results ---");

    var expensiveCount = db.Tickets.Count(t => t.Price > 20);
    Console.WriteLine($"Tickets with price > 20:   {expensiveCount}");

    var firstAhmed = db.Tickets.FirstOrDefault(t => t.PassengerName == "Ahmed");
    Console.WriteLine($"First ticket for Ahmed:    {(firstAhmed != null ? firstAhmed.Price.ToString("C") : "Not Found")}");

    Console.WriteLine($"Total number of tickets:   {db.Tickets.Count()}");

    var highestPrice = db.Tickets.Max(t => t.Price);
    Console.WriteLine($"Highest ticket price:      {highestPrice:C}");

    Console.WriteLine("\n---  Results ---");

    var ticketsPerTrain = db.Trains.Select(t => new { t.Number, Count = t.Tickets.Count }).ToList();
    foreach (var item in ticketsPerTrain)
        Console.WriteLine($"Train {item.Number}: {item.Count} tickets booked");

    var cheapest = db.Tickets.OrderBy(t => t.Price).FirstOrDefault();
    var expensiveTicket = db.Tickets.OrderByDescending(t => t.Price).FirstOrDefault();

    Console.WriteLine($"Cheapest Ticket: {cheapest?.Price:C}");
    Console.WriteLine($"Most Expensive:  {expensiveTicket?.Price:C}");

    Console.WriteLine("\n==========================================");
}