using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// This table contains the departments avaiable in each hospital
    /// </summary>
    public partial class Department
    {
        public int HospDeptId { get; set; }
        public int HospitalId { get; set; }
        public int DepartmentId { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public DateTime? Moddate { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Name { get; set; }
        public int? ParentDeptId { get; set; }
        public string? Type { get; set; }
        public int? IsStore { get; set; }
        public string? Name2l { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }
    }
}
