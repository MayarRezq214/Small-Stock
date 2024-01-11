using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.DAL
{
    public class StoreItem 
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Current number of items must be greater than or equal zero.")]
        
        public int CurrentNumberOfItems { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Limited number of items must be greater than zero.")]
        
        public int LimitedNumberOfItems { get; set; }
        [ForeignKey("StoreId")]
        public Store? store { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }

        
    }
}
