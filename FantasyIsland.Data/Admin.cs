using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Data
{
    public class Admin : Guest
    {
        [Key]
        public int AdminId { get; set; }
        
    }
}
