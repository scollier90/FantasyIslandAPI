﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland.Models
{
    public class BookingDetail
    {
        
        public string UserId { get; set; }

        public int DestId { get; set; }
        public string DestName { get; set; }

        public int TransId { get; set; }
        public string TransType { get; set; }
    }
}
