namespace Bank.Domain.Entites
{
    public class User
    {
        public long Id { get; set; }
        public string FirstaName { get; set; }
        public string LastaName { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
