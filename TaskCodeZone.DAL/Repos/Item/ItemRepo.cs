using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class ItemRepo : GenaricRepo<Item> , IItemRepo
    {
        private readonly StockContext _stockContext;
        public ItemRepo(StockContext context) :base(context) 
        {
            _stockContext = context;
        }
        public Item GetItemByName(string name)
        {
            return _stockContext.Set<Item>().FirstOrDefault(i => i.Name == name)!;
        }
    }
}
