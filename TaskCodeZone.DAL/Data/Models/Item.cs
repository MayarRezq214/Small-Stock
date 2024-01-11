using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string MeasurementUnit { get; set; } = string.Empty;
        public ICollection<StoreItem> StoreItems { get; set; } = new HashSet<StoreItem>();
    }
}
