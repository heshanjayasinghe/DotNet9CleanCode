using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet9.Domain.DatabaseEntities
{
    public class Session
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }

        public virtual List<Song>? Songs { get; set; }

    }
}
