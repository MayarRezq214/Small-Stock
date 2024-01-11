using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public interface IItemRepo : IGenaricRepo<Item>
    {
        public Item GetItemByName(string name);
    }
}
