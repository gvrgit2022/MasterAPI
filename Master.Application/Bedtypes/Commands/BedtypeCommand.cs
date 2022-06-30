using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Bedtypes.Commands
{
    public class BedtypeCommand : IRequest<string>, INotification
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

        public class BedtypeCommandHandler : BaseHandler, IRequestHandler<BedtypeCommand, string>
        {
            public BedtypeCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(BedtypeCommand request, CancellationToken cancellationtoken)
            {
                var bedtype = new Infrastructure.Models.Master.Bedtype();
                bedtype.BedTypeId = request.BedTypeId;
                bedtype.BedType1 = request.BedType1;
                bedtype.IsMovable = request.IsMovable;
                bedtype.ShortName = request.ShortName;
                bedtype.Code = request.Code;
                bedtype.Createdate = request.Createdate;
                bedtype.Enddate = request.Enddate;
                bedtype.Status = request.Status;
                bedtype.Moddate = request.Moddate;
                bedtype.Blocked = request.Blocked;
                bedtype.Routid = request.Routid;
                bedtype.Userid = request.Userid;
                bedtype.Workstationid = request.Workstationid;
                bedtype.PatientType = request.PatientType;
                bedtype.ServiceId = request.ServiceId;
                bedtype.AdvanceDeposit = request.AdvanceDeposit;
                bedtype.BedType2l = request.BedType2l;
                bedtype.Rowseq = request.Rowseq;
                bedtype.FacilityId = request.FacilityId;
                bedtype.Dspk = request.Dspk;
                masterContext.Add(bedtype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
