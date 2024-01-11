using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public interface IUnitOfWork
    {
        IItemRepo ItemRepo { get; }
        IStoreRepo StoreRepo { get; }
        IStoreItemRepo StoreItemRepo { get; }
        int SaveChanges();
    }
}
