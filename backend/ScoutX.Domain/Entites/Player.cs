namespace ScoutX.Domain.Entites
{
    public class Player
    {
        public Guid Id { get; set; } // Her oyuncunun benzersiz kimliği
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Position { get; set; } = null!;
        public string Country { get; set; } = null!;
        public decimal MarketValue { get; set; } // Transfer değeri (milyon euro gibi düşün)
        public int Score { get; set; } // Scout tarafından verilen performans skoru (0–100)
    }
}
