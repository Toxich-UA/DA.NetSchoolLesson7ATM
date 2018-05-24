namespace EFDbContext.Models.DbEntity
{
    public class OperationDetails
    {
        public long ID { get; set; }
        
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        
        public virtual Cards Cards { get; set; }
        public Operations Operations { get; set; }
        public OperationsType OperationsType { get; set; }
    }
}
