public class Ticket
{
    public int Id { get; set; }
    public string PassengerName { get; set; }
    public decimal Price { get; set; }
    public DateTime TravelDate { get; set; }

    public int TrainId { get; set; }
    public Train Train { get; set; }

    public int StationId { get; set; }
    public Station Station { get; set; }
}