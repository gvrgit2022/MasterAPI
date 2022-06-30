using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// Location type details will be avaliable
    /// </summary>
    public partial class Locationtype
    {
        public sbyte LocationtypeId { get; set; }
        public string? Location { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Modifydate { get; set; }
        public sbyte? Blocked { get; set; }
        public DateTime Rowseq { get; set; }
        public string? Workstationid { get; set; }
        public int? Dspk { get; set; }
    }
}
