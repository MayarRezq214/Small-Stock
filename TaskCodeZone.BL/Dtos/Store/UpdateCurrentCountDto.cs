using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskCodeZone.BL.Dtos.Store
{
    public class UpdateCurrentCountDto
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Current number of items must be greater than or equal zero.")]
        public int CurrentNumberOfItems { get; set; }

    }
}
