namespace Point72Library.Models
{
    public class Loan
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;

        public bool Returned { get; set; } = false;
    }
}
