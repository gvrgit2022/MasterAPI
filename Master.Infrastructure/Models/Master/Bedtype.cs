using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// This is used to specify the types of beds
    /// </summary>
    public partial class Bedtype
    {
        public int BedTypeId { get; set; }
        public string BedType1 { get; set; } = null!;
        public bool? IsMovable { get; set; }
        public string? ShortName { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public DateTime? Moddate { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public int PatientType { get; set; }
        public int ServiceId { get; set; }
        public decimal? AdvanceDeposit { get; set; }
        public string? BedType2l { get; set; }
        public DateTime Rowseq { get; set; }
        public int FacilityId { get; set; }
        public int? Dspk { get; set; }

        public virtual Service Service { get; set; } = null!;
    }
}
