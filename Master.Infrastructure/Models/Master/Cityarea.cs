using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// This table is used to specify the city
    /// </summary>
    public partial class Cityarea
    {
        public int CityAreaId { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public int? ZoneId { get; set; }
        public string? Area2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }
    }
}
