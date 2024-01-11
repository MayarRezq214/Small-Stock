using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class StoreRepo : GenaricRepo<Store> , IStoreRepo
    {
        private readonly StockContext _stockContext;
        public StoreRepo(StockContext context) : base(context)
        {
            _stockContext = context;
        }
        public Store GetStoreByNameAndAddress(string name , string Address)
        {
            return _stockContext.Set<Store>().FirstOrDefault(S => S.Name == name &&  S.Address == Address)!;
        }
    }
}
