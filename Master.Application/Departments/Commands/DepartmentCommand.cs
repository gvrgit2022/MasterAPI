using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Departments.Commands
{
    public class DepartmentCommand : IRequest<string>, INotification
    {
        public int HospDeptId { get; set; }
        public int HospitalId { get; set; }
        public int DepartmentId { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public DateTime? Moddate { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Name { get; set; }
        public int? ParentDeptId { get; set; }
        public string? Type { get; set; }
        public int? IsStore { get; set; }
        public string? Name2l { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class DepartmentCommandHandler : BaseHandler, IRequestHandler<DepartmentCommand, string>
        {
            public DepartmentCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(DepartmentCommand request, CancellationToken cancellationtoken)
            {
                var departmentype = new Infrastructure.Models.Master.Department();
                departmentype.HospDeptId = request.HospDeptId;
                departmentype.HospitalId = request.HospitalId;
                departmentype.DepartmentId = request.DepartmentId;
                departmentype.Code = request.Code;
                departmentype.Createdate = request.Createdate;
                departmentype.Enddate = request.Enddate;
                departmentype.Status = request.Status;
                departmentype.Blocked = request.Blocked;
                departmentype.Routid = request.Routid;
                departmentype.Userid = request.Userid;
                departmentype.Workstationid = request.Workstationid;
                departmentype.Name = request.Name;
                departmentype.ParentDeptId = request.ParentDeptId;
                departmentype.Type = request.Type;
                departmentype.IsStore = request.IsStore;
                departmentype.Name2l = request.Name2l;
                departmentype.Rowseq = request.Rowseq;
                departmentype.Dspk = request.Dspk;
                masterContext.Add(departmentype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
