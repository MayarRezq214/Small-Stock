using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.BL
{
    public class ChildStoreItemDto
    {
        public int CurrentNumberOfItems { get; set; }
        public int LimitedNumberOfItems { get; set; }
        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? MeasurmentUnit { get; set; }
    }
}
