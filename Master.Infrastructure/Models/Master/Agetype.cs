using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// This table is used for the type of age like years , months and days
    /// </summary>
    public partial class Agetype
    {
        public int AgeTypeId { get; set; }
        public string Agetypename { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public DateTime? Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Moddate { get; set; }
        public int? Status { get; set; }
        public int? Blocked { get; set; }
        public int? Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }
    }
}
