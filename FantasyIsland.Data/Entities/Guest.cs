using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Data
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
<<<<<<< HEAD:FantasyIsland.Data/Guest.cs
=======

>>>>>>> 68b4f798ad41af0d8f2519c8355cd7f23a2bc990:FantasyIsland.Data/Entities/Guest.cs
    }
}
