using MasterAPI.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Admission.Model
{
    public  class AdmissionType: BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Name2l { get; set; }
        public DateTime Rowseq { get; set; }
        public int FacilityId { get; set; }
        public int? Dspk { get; set; }
    }
}
