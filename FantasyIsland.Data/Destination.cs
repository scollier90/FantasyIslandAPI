using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Data
{
    public class Destination
    {
        [Key]
        public int DestId { get; set; }
        [Required]
        public string DestName { get; set; }
        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
