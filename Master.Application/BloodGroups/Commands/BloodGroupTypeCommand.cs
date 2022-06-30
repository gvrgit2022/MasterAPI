using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.BloodGroups.Commands
{
    public class BloodGroupCommand : IRequest<string>, INotification
    {
        public int BloodGroupId { get; set; }
        public string? Bloodgroup1 { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? BloodGroup2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class BloodGroupTypeCommandHandler : BaseHandler, IRequestHandler<BloodGroupCommand, string>
        {
            public BloodGroupTypeCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(BloodGroupCommand request, CancellationToken cancellationtoken)
            {
                var bloodGroup = new Infrastructure.Models.Master.Bloodgroup();
                bloodGroup.BloodGroupId = request.BloodGroupId;
                bloodGroup.Bloodgroup1 = request.Bloodgroup1;
                bloodGroup.Code = request.Code;
                bloodGroup.Createdate = request.Createdate;
                bloodGroup.Enddate = request.Enddate;
                bloodGroup.Status = request.Status;
                bloodGroup.Blocked = request.Blocked;
                bloodGroup.Routid = request.Routid;
                bloodGroup.Userid = request.Userid;
                bloodGroup.Workstationid = request.Workstationid;
                bloodGroup.Rowseq = request.Rowseq;
                bloodGroup.Dspk = request.Dspk;
                bloodGroup.BloodGroup2L = request.BloodGroup2L;
                masterContext.Add(bloodGroup);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
