namespace ScoutX.Application.Players.DTOs
{
    public class AddPlayerDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Position { get; set; } = null!;
        public string Country { get; set; } = null!;
        public decimal MarketValue { get; set; }
        public int Score { get; set; }
    }
}
