using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Age.Commands
{
    public class AgeTypeCommand : IRequest<string>, INotification
    {
        public int AgeTypeId { get; set; }
        public string Agetypename { get; set; } = null!;
        public string Comments { get; set; } = null!;
        public DateTime? Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public DateTime? Moddate { get; set; }
        public int? Status { get; set; }
        public int? Blocked { get; set; }
        public int? Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }


        public class AgeTypeCommandHandler : BaseHandler, IRequestHandler<AgeTypeCommand, string>
        {
            public AgeTypeCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(AgeTypeCommand request, CancellationToken cancellationtoken)
            {
                var agetype = new Infrastructure.Models.Master.Agetype();
                agetype.AgeTypeId = request.AgeTypeId;
                agetype.Agetypename = request.Agetypename;
                agetype.Comments = request.Comments;
                agetype.Createdate = request.Createdate;
                agetype.Enddate = request.Enddate;
                agetype.Moddate = request.Moddate;
                agetype.Status = request.Status;
                agetype.Blocked = request.Blocked;
                agetype.Routid = request.Routid;
                agetype.Userid = request.Userid;
                agetype.Workstationid = request.Workstationid;
                agetype.Rowseq = request.Rowseq;
                agetype.Dspk = request.Dspk;
                masterContext.Add(agetype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
