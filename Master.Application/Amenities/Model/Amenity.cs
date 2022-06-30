﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Amenities.Model
{
    public class Amenity
    {
        public int AmenitieId { get; set; }
        public string? Amenitie { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Amenitie2L { get; set; }
        public DateTime Rowseq { get; set; }
        public DateTime Moddate { get; set; }
        public int? Dspk { get; set; }
    }
}