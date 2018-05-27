namespace EFDbContext.Models.DbEntity
{
    public class OperationsDetails
    {
        public OperationsDetails()
        {
            Operations = new Operations();
            Card = new Card();
        }

        public long ID { get; set; }
        
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        public Card Card { get; set; }
        public Operations Operations { get; set; }
        public virtual OperationsType OperationsType { get; set; }
    }
}
