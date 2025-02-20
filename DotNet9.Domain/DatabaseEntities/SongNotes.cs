using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Domain.DatabaseEntities
{
    public class SongNotes
    {
        [Key]
        public required string Id { get; set; }

        public required string DetailName { get; set; }
        public required string Detail { get; set; }
        public required virtual Song Song{ get; set; }
    }
}
