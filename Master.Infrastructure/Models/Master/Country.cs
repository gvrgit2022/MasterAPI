using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// This table is used to store the countires names
    /// </summary>
    public partial class Country
    {
        public int CountryId { get; set; }
        public string Country1 { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Country2L { get; set; }
        public DateTime Rowseq { get; set; }
        public DateTime? Moddate { get; set; }
        public int? Dspk { get; set; }
    }
}
