using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Bedtypes.Model
{
    public class Bedtype
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


    }
}
