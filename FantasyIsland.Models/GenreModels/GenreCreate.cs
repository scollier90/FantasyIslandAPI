using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models.GenreModels
{
    public class GenreCreate
    {
        [Required]
        public string GenreType { get; set; }
        public int DestId { get; set; }
    }
}
