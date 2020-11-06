using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models.DestinationModels
{
    public class DestCreate
    {
        [Required]
        public int DestId { get; set; }
        [Required]
        public string DestName { get; set; }
        [Required]
        public int GenreId { get; set; }
       
    }
}
