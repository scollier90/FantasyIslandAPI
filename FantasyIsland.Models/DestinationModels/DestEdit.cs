using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models.DestinationModels
{
    public class DestEdit
    {
        public int DestId { get; set; }
        public string DestName { get; set; }
        public int GenreId { get; set; }
    }
}
