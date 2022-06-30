using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Services.Commands
{
    public class ServiceCommand : IRequest<string>, INotification
    {
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

        public class ServiceCommandHandler : BaseHandler, IRequestHandler<ServiceCommand, string>
        {
            public ServiceCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(ServiceCommand request, CancellationToken cancellationtoken)
            {
                var servicetype = new Infrastructure.Models.Master.Service();
                servicetype.ServiceId = request.ServiceId;
                servicetype.ServiceName = request.ServiceName;
                servicetype.ServiceTypeId = request.ServiceTypeId;
                servicetype.PatientType = request.PatientType;
                servicetype.DisplayName = request.DisplayName;
                servicetype.IsHisRequired = request.IsHisRequired;
                servicetype.IsVisible = request.IsVisible;
                servicetype.IsParent = request.IsParent;
                servicetype.HispriceType = request.HispriceType;
                servicetype.Moddate = request.Moddate;
                servicetype.IsSingleSpeciality = request.IsSingleSpeciality;
                servicetype.HasItems = request.HasItems;
                servicetype.SpecProfDependent = request.SpecProfDependent;
                servicetype.IssingleDomain = request.IssingleDomain;
                servicetype.ParentServiceId = request.ParentServiceId;
                servicetype.DependOnCategory = request.DependOnCategory;
                servicetype.ItemHop = request.ItemHop;
                servicetype.HasDoctorShare = request.HasDoctorShare;
                servicetype.BillType = request.BillType;
                servicetype.DependOnBed = request.DependOnBed;
                servicetype.IsSchedulable = request.IsSchedulable;
                servicetype.SpcConfigurationKey = request.SpcConfigurationKey;
                servicetype.DomConfigurationKey = request.DomConfigurationKey;
                servicetype.OrdConfigurationKey = request.OrdConfigurationKey;
                servicetype.ServiceName2L = request.ServiceName2L;
                servicetype.PrintSequence = request.PrintSequence;
                servicetype.DisplayName2l = request.DisplayName2l;
                servicetype.OrdCancelStatus = request.OrdCancelStatus;
                servicetype.DoctorPayout = request.DoctorPayout;
                servicetype.DoctorPayoutHope = request.DoctorPayoutHope;
                servicetype.CalSequence = request.CalSequence;
                servicetype.Opedit = request.Opedit;
                servicetype.ServiceGroupName = request.ServiceGroupName;
                servicetype.DependOnboth = request.DependOnboth;
                servicetype.Code = request.Code;
                servicetype.Createdate = request.Createdate;
                servicetype.Enddate = request.Enddate;
                servicetype.Status = request.Status;
                servicetype.Blocked = request.Blocked;
                servicetype.Userid = request.Userid;
                servicetype.Routid = request.Routid;
                servicetype.Workstationid = request.Workstationid;
                servicetype.Rowseq = request.Rowseq;
                servicetype.Dspk = request.Dspk;
                masterContext.Add(servicetype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
