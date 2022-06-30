using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Religions.Commands
{
    public class ReligionCommand : IRequest<string>, INotification
    {
        public int ReligionId { get; set; }
        public string Religion1 { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Religion2L { get; set; }
        public int? ReligionGroupId { get; set; }
        public DateTime? Moddate { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class ReligionCommandHandler : BaseHandler, IRequestHandler<ReligionCommand, string>
        {
            public ReligionCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(ReligionCommand request, CancellationToken cancellationtoken)
            {
                var religiontype = new Infrastructure.Models.Master.Religion();
                religiontype.ReligionId = request.ReligionId;
                religiontype.Religion1 = request.Religion1;
                religiontype.Code = request.Code;
                religiontype.Createdate = request.Createdate;
                religiontype.Enddate = request.Enddate;
                religiontype.Status = request.Status;
                religiontype.Blocked = request.Blocked;
                religiontype.Userid = request.Userid;
                religiontype.Routid = request.Routid;
                religiontype.Workstationid = request.Workstationid;
                religiontype.Religion2L = request.Religion2L;
                religiontype.ReligionGroupId = request.ReligionGroupId;
                religiontype.Rowseq = request.Rowseq;
                religiontype.Dspk = request.Dspk;
                masterContext.Add(religiontype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
