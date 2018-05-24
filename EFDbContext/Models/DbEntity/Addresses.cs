namespace EFDbContext.Models.DbEntity
{
    public partial class Addresses
    {
        public int ClientId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Clients Client { get; set; }
    }
}
