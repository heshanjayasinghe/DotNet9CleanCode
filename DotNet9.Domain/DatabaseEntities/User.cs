using System;
using System.ComponentModel.DataAnnotations;

namespace DotNet9.Domain.DatabaseEntities
{
    public class User
    {
        [Key]
        public required string UserId { get; set; }
        public required string   Name { get; set; }
    }
}
