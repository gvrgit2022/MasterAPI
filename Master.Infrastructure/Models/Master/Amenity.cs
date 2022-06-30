using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// This is used to determine the type of aminities
    /// </summary>
    public partial class Amenity
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
