using System;
using System.Data.Entity;
using EFDbContext.Models.DbEntity;

namespace EFDbContext
{
    public interface IBankContext : IDisposable
    {
        IDbSet<Clients> Clients { get; set; }
        IDbSet<Card> Cards { get; set; }
        IDbSet<Addresses> Addresseses { get; set; }
        IDbSet<Operations> Operations { get; set; }
        IDbSet<OperationsType> OperationsType { get; set; }
        IDbSet<OperationDetails> OperationDetails { get; set; }


        int Save();
        
    }
}