using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Genders.Commands
{
    public class GenderCommand : IRequest<string>, INotification
    {
        public int GenderId { get; set; }
        public string Gender1 { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Gender2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class GenderCommandHandler : BaseHandler, IRequestHandler<GenderCommand, string>
        {
            public GenderCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(GenderCommand request, CancellationToken cancellationtoken)
            {
                var gendertype = new Infrastructure.Models.Master.Gender();
                gendertype.GenderId = request.GenderId;
                gendertype.Gender1 = request.Gender1;
                gendertype.Code = request.Code;
                gendertype.Createdate = request.Createdate;
                gendertype.Enddate = request.Enddate;
                gendertype.Status = request.Status;
                gendertype.Blocked = request.Blocked;
                gendertype.Routid = request.Routid;
                gendertype.Userid = request.Userid;
                gendertype.Workstationid = request.Workstationid;
                gendertype.Gender2L = request.Gender2L;
                gendertype.Rowseq = request.Rowseq;
                gendertype.Dspk = request.Dspk;
                masterContext.Add(gendertype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
