using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models
{
    public class BookingCreate
    {
        public string UserId { get; set; }
        [Required]
        public int DestId { get; set; }
        [Required]
        public int TransId { get; set; }
    }
}
