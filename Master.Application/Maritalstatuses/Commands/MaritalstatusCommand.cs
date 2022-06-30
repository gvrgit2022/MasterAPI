using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Maritalstatus.Commands
{
    public class MaritalstatusCommand : IRequest<string>, INotification
    {
        public int MaritalStatusId { get; set; }
        public string MarStatus { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? MarStatus2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class MaritalstatusCommandHandler : BaseHandler, IRequestHandler<MaritalstatusCommand, string>
        {
            public MaritalstatusCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(MaritalstatusCommand request, CancellationToken cancellationtoken)
            {
                var maritalstatustype = new Infrastructure.Models.Master.Maritalstatus();
                maritalstatustype.MaritalStatusId = request.MaritalStatusId;
                maritalstatustype.MarStatus = request.MarStatus;
                maritalstatustype.Code = request.Code;
                maritalstatustype.Createdate = request.Createdate;
                maritalstatustype.Enddate = request.Enddate;
                maritalstatustype.Status = request.Status;
                maritalstatustype.Blocked = request.Blocked;
                maritalstatustype.Userid = request.Userid;
                maritalstatustype.Routid = request.Routid;
                maritalstatustype.Workstationid = request.Workstationid;
                maritalstatustype.MarStatus2L = request.MarStatus2L;
                maritalstatustype.Rowseq = request.Rowseq;
                maritalstatustype.Dspk = request.Dspk;
                masterContext.Add(maritalstatustype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
