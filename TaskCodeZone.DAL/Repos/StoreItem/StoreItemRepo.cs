using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class StoreItemRepo : GenaricRepo<StoreItem>, IStoreItemRepo
    {
        private readonly StockContext _stockContext;
        public StoreItemRepo(StockContext context):base(context) 
        {
            _stockContext = context;
        }

        public Store GetAllStoreItems(int id)
        {
            return _stockContext.Set<Store>()
                .Include(s => s.StoreItems)
                .ThenInclude(si => si.Item)
                .FirstOrDefault(s => s.Id == id)!;
        }
        public StoreItem GetStoreItem(int StoreId , int ItemId) 
        {
           return _stockContext.Set<StoreItem>()
                .AsNoTracking()
                .FirstOrDefault(si => si.ItemId == ItemId && si.StoreId == StoreId)!;
        }
    }
}

