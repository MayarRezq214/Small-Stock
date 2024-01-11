using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskCodeZone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockContext _stockContext;
        public IItemRepo ItemRepo { get; }
        public IStoreRepo StoreRepo { get; }
        public IStoreItemRepo StoreItemRepo { get; }
        public UnitOfWork(StockContext context,
           IItemRepo itemRepo,
           IStoreRepo storeRepo,
           IStoreItemRepo storeItemRepo)
        {
            _stockContext = context;
            ItemRepo = itemRepo;
            StoreRepo = storeRepo;
            StoreItemRepo = storeItemRepo;
        }
        public int SaveChanges()
        {
            return _stockContext.SaveChanges();
        }
    }
}
