using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Designations.Commands
{
    public class DesignationCommand : IRequest<string>, INotification
    {
        public int DesignationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public bool IsMedical { get; set; }
        public string? Name2l { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class DesignationCommandHandler : BaseHandler, IRequestHandler<DesignationCommand, string>
        {
            public DesignationCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(DesignationCommand request, CancellationToken cancellationtoken)
            {
                var designationtype = new Infrastructure.Models.Master.Designation();
                designationtype.DesignationId = request.DesignationId;
                designationtype.Name = request.Name;
                designationtype.Code = request.Code;
                designationtype.Createdate = request.Createdate;
                designationtype.Enddate = request.Enddate;
                designationtype.Status = request.Status;
                designationtype.Blocked = request.Blocked;
                designationtype.Routid = request.Routid;
                designationtype.Userid = request.Userid;
                designationtype.Workstationid = request.Workstationid;
                designationtype.IsMedical = request.IsMedical;
                designationtype.Name2l = request.Name2l;
                designationtype.Rowseq = request.Rowseq;
                designationtype.Dspk = request.Dspk;
                masterContext.Add(designationtype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
