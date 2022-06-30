using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// No Info
    /// </summary>
    public partial class Service
    {
        public Service()
        {
            Bedtypes = new HashSet<Bedtype>();
            InverseServiceNavigation = new HashSet<Service>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public int ServiceTypeId { get; set; }
        public int PatientType { get; set; }
        public string DisplayName { get; set; } = null!;
        public bool IsHisRequired { get; set; }
        public int IsVisible { get; set; }
        public int IsParent { get; set; }
        public string HispriceType { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public DateTime? Moddate { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public int IsSingleSpeciality { get; set; }
        public bool HasItems { get; set; }
        public string SpecProfDependent { get; set; } = null!;
        public bool IssingleDomain { get; set; }
        public int? ParentServiceId { get; set; }
        public bool DependOnCategory { get; set; }
        public string? ItemHop { get; set; }
        public bool HasDoctorShare { get; set; }
        public string BillType { get; set; } = null!;
        public bool? DependOnBed { get; set; }
        public bool? IsSchedulable { get; set; }
        public string? SpcConfigurationKey { get; set; }
        public string? DomConfigurationKey { get; set; }
        public string? OrdConfigurationKey { get; set; }
        public string? ServiceName2L { get; set; }
        public int? PrintSequence { get; set; }
        public string? DisplayName2l { get; set; }
        public string? OrdCancelStatus { get; set; }
        public string? DoctorPayout { get; set; }
        public string? DoctorPayoutHope { get; set; }
        public int? CalSequence { get; set; }
        public byte Opedit { get; set; }
        public string? ServiceGroupName { get; set; }
        public bool? DependOnboth { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public virtual Service? ServiceNavigation { get; set; }
        public virtual ICollection<Bedtype> Bedtypes { get; set; }
        public virtual ICollection<Service> InverseServiceNavigation { get; set; }
    }
}
