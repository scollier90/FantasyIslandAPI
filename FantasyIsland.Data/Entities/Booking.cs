using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Data
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }
        public virtual Guest Guest { get; set; }
        [Required]
        [ForeignKey(nameof(Destination))]
        public int DestId { get; set; }
        public virtual Destination Destination { get; set; }
        [Required]
        [ForeignKey(nameof(Transportation))]
        public int TransId { get; set; }
        public virtual Transportation Transportation { get; set; }
    }
}
