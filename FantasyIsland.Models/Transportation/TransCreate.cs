using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models.Transportation
{
    public class TransCreate
    {
        [Required]
        public string TransType { get; set; }
        [Required]
        public int DestId { get; set; }
    }
}
