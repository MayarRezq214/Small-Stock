using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskCodeZone.DAL;

namespace TaskCodeZone.BL
{
    public class ItemInStoreDto : IValidatableObject
    {
        public int StoreId { get; set; }
        public int ItemId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Current number of items must be greater than or equal zero.")]

        public int CurrentNumberOfItems { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Limited number of items must be greater than zero.")]

        public int LimitedNumberOfItems { get; set; }
        public int Value {  get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Custom validation logic for CurrentNumberOfItems
            if (CurrentNumberOfItems < 0 || CurrentNumberOfItems > LimitedNumberOfItems)
            {
                yield return new ValidationResult("Current number of items must be greater than or equal to zero and less than Limited Number Of Items.",
                    new[] { nameof(CurrentNumberOfItems) });
            }

            // Custom validation logic for LimitedNumberOfItems
            if (LimitedNumberOfItems <= 0)
            {
                yield return new ValidationResult("Limited number of items must be greater than zero.",
                    new[] { nameof(LimitedNumberOfItems) });
            }
        }
    }
}
