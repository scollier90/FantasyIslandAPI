using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models
{
    public class BookingEdit
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }

        public int DestId { get; set; }
        

        public int TransId { get; set; }
        
    }
}
