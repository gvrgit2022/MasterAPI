using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Nationalities.Commands
{
    public class NationalityCommand : IRequest<string>, INotification
    {
        public int NationalityId { get; set; }
        public string Nationality1 { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Nationality2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class NationalityCommandHandler : BaseHandler, IRequestHandler<NationalityCommand, string>
        {
            public NationalityCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(NationalityCommand request, CancellationToken cancellationtoken)
            {
                var nationalitytype = new Infrastructure.Models.Master.Nationality();
                nationalitytype.NationalityId = request.NationalityId;
                nationalitytype.Nationality1 = request.Nationality1;
                nationalitytype.Code = request.Code;
                nationalitytype.Createdate = request.Createdate;
                nationalitytype.Enddate = request.Enddate;
                nationalitytype.Status = request.Status;
                nationalitytype.Blocked = request.Blocked;
                nationalitytype.Userid = request.Userid;
                nationalitytype.Routid = request.Routid;
                nationalitytype.Workstationid = request.Workstationid;
                nationalitytype.Nationality2L = request.Nationality2L;
                nationalitytype.Rowseq = request.Rowseq;
                nationalitytype.Dspk = request.Dspk;
                masterContext.Add(nationalitytype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
