using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models
{
    public class GuestDetail
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //[Display(Name="Created")]
        //public DateTimeOffset CreatedUtc { get; set; }
        //[Display(Name = "Modified")]
        //public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
