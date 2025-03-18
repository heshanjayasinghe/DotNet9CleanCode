using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Domain.DatabaseEntities
{
    public class FoodItems
    {
        [Key]
        public required string  FoodItemId { get; set; }
        public required string Name { get; set; }
    }
}
