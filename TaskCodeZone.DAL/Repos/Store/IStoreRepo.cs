using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public interface IStoreRepo : IGenaricRepo<Store>
    {
        public Store GetStoreByNameAndAddress(string name, string Address);
    }
}
