namespace EFDbContext.Models.DbEntity
{
    public class OperationsDetails
    {

        public long ID { get; set; }
        
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        public virtual Operations Operations { get; set; }
        public virtual OperationsType OperationsType { get; set; }
    }
}
