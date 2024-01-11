using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public interface IStoreItemRepo : IGenaricRepo<StoreItem>
    {
        public Store GetAllStoreItems(int id);
        public StoreItem GetStoreItem(int StoreId, int ItemId);
        


    }
}
