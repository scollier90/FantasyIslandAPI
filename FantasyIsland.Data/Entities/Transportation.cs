﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Data
{

    public class Transportation
    {
        [Key]
        public int TransId { get; set; }

        [Required]
        public string TransType { get; set; }

        [ForeignKey(nameof(Destination))]
        public int DestId { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
